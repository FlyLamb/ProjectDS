using System.Collections.Generic;
using UnityEngine;
using System.Collections;

namespace LambWorks.Networking.Server {
    public class NetworkManager : MonoBehaviour {
        public static NetworkManager instance;

        public GameObject playerPrefab;

        public ServerRoundManager roundtimeManager;
        public ChatHandler chatManager;

        private void Awake() {
            if (instance == null) {
                instance = this;
            } else if (instance != this) {
                Debug.Log("Instance already exists, destroying object!");
                Destroy(this);
            }
        }

        private void Start() {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 30;

            Server.Start(50, 26950);
        }

        private void OnApplicationQuit() {
            Server.Stop();
        }

        public Transform GetRandomPlayerSpawn() {
            GameObject[] spawns = GameObject.FindGameObjectsWithTag("PlayerSpawn");
            if(spawns.Length == 0) return transform;
            return spawns[Random.Range(0,spawns.Length)].transform;
        }

        public Player InstantiatePlayer() {
            UnityEngine.SceneManagement.SceneManager.SetActiveScene(UnityEngine.SceneManagement.SceneManager.GetSceneAt(0));
            Transform playerSpawn = GetRandomPlayerSpawn();
            if(instance.roundtimeManager.isWarmup)
                return Instantiate(playerPrefab, playerSpawn.position, playerSpawn.rotation).GetComponent<Player>();
            else 
                return Instantiate(playerPrefab, new Vector3(15 + Random.Range(-4,4),4,68 + Random.Range(-4,4)),Quaternion.identity).GetComponent<Player>();
                
        }

        /// <summary>This is called when a player joins</summary>
        public void OnPlayerJoin(int id) {
            foreach (var item in Server.entities.Values) {
                ServerSend.SpawnEntity(item, id);
                
            }
            NetworkManager.instance.chatManager.Send($"{Server.clients[id].player.username} has joined");
        }

        /// <summary>Needs to be called by the entity in order to be registered</summary>
        /// <param name="e">The entity to register</param>
        public void RegisterEntity(Entity e) {

            List<uint> keys = new List<uint>(Server.entities.Keys);
            //Get first free ID
            uint i;
            for (i = 0; i < keys.Count + 1; i++) {
                if (!keys.Contains(i))
                    break;
            }
            //Send an EntitySpawn packet to all
            e.id = i;
            ServerSend.SpawnEntity(e);

            //Add it to the server registry
            Server.entities.Add(i, e);
        }

        /// <summary>Destroys the entity for the client</summary>
        /// <param name="e">The entity to destroy</param>
        public void DestroyEntity(Entity e) {
            if (!Server.entities.ContainsKey(e.id)) return;
            ServerSend.DestroyEntity(e);

            Server.entities.Remove(e.id);
        }
    }
}