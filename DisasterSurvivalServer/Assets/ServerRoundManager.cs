using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using LambWorks.Networking.Server;
using UnityEngine.SceneManagement;

public class ServerRoundManager : MonoBehaviour
{
    public float roundTime;
    public List<string> playersAlive;
    

    public bool isWarmup = true;

    void Start() {
        StartCycle();
    }

    public void StartCycle() {
        StartCoroutine(RoundCycle());
    }

    private IEnumerator RoundCycle() {
        while(true) {
        NetworkManager.instance.chatManager.Send("Welcome to the server!");
        RespawnAllPlayers();
        isWarmup = true;
        for (roundTime = -30; roundTime < 0; roundTime++) {
            yield return new WaitForSeconds(1);
            Tick();
        }

        RespawnAllPlayers();
        playersAlive.Clear();
        foreach (var item in Server.clients.Values) {
            if(item.player == null) continue;
            playersAlive.Add(item.player.username);
        }

        NetworkManager.instance.chatManager.Send("Game Start!");
        isWarmup = false;

        for (roundTime = 300; roundTime >= 0; roundTime--) {
            yield return new WaitForSeconds(1);
            Tick();
        }
        NetworkManager.instance.chatManager.Send("The game has finished! The winners are:");
        
        foreach (var item in playersAlive) { 
            NetworkManager.instance.chatManager.Send(item);
        }

        foreach (var item in Server.clients.Values) {
            if(item.player == null) continue;
            item.player.GetComponent<BajtixPlayerController>().Teleport(new Vector3(15 + Random.Range(-4,4),4,68 + Random.Range(-4,4)),Quaternion.identity);
        }
        yield return new WaitForSeconds(5);
        NetworkManager.instance.chatManager.Send("The server will restart in 10 seconds.");
        yield return new WaitForSeconds(10);
        NetworkManager.instance.chatManager.Send("Server restart go brrr..");
        
        AssetBundleLoader.instance.UnloadMap();
        NetworkManager.instance.chatManager.Send("Unloaded!");
        yield return new WaitForSeconds(0.5f);
        AssetBundleLoader.instance.LoadMap();

        yield return new WaitForSeconds(2);
        }

        
    }

    public void HandleDeath(BajtixPlayerController player) {
        player.GetComponent<Player>().health = 100;
        if(isWarmup) {
            //respawn on map
            NetworkManager.instance.chatManager.Send($"{player.GetComponent<Player>().username} died");
            var sp = NetworkManager.instance.GetRandomPlayerSpawn();
            player.Teleport(sp.position,sp.rotation);
        } else {
            //lobby room
            if(playersAlive.Contains(player.GetComponent<Player>().username))
                playersAlive.Remove(player.GetComponent<Player>().username);

            if(playersAlive.Count <= 1) roundTime = 0;
            NetworkManager.instance.chatManager.Send($"{player.GetComponent<Player>().username} died (elimination)");
            player.Teleport(new Vector3(15,4,68),Quaternion.identity);
        }

    }

    private void Tick() {
        SendRoundtime();
    }

    public void RespawnAllPlayers() {
       
        List<GameObject> spawns = GameObject.FindGameObjectsWithTag("PlayerSpawn").ToList();
        Debug.Log($"Player respawn! Found {spawns.Count} spawns!");
        foreach (var item in Server.clients) {
            int rsp = Random.Range(0,spawns.Count);
            if(item.Value.player == null) continue;

            item.Value.player.GetComponent<BajtixPlayerController>().Teleport(spawns[rsp].transform.position, spawns[rsp].transform.rotation);
            item.Value.player.health = 100;
            spawns.RemoveAt(rsp);
        }

    }

    public void SendRoundtime() {
        ServerSend.RoundTime(roundTime);
    }
}
