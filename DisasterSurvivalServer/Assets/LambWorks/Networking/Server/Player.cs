using UnityEngine;

namespace LambWorks.Networking.Server {
    public class Player : MonoBehaviour {
        public int id;
        public string username;
        

        public short health = 100;

        

        public void Initialize(int id) {
            this.id = id;
        }


        public void SetInput(Vector3 input, Quaternion rotation, Quaternion camRotation) {
            GetComponent<BajtixPlayerController>().SetInput(input);
            transform.rotation = rotation;
            transform.Find("Camera").rotation = camRotation;
        }

        private void FixedUpdate() {
            ServerSend.PlayerPosition(this);
            ServerSend.PlayerRotation(this);

            if(health <= 0) {
                transform.position = NetworkManager.instance.GetRandomPlayerSpawn();
                health = 100;
            }
  
        }


        void OnCollisionEnter(Collision cd) {
            if(cd.relativeVelocity.magnitude > 20) {
                health -= (short)(cd.relativeVelocity.magnitude / 2);
            }    
        }

    }
}