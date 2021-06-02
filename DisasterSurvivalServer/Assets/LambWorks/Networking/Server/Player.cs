using UnityEngine;

namespace LambWorks.Networking.Server {
    public class Player : MonoBehaviour {
        public int id;
        public string username;
        

        public short health = 100;

        

        public void Initialize(int id) {
            this.id = id;
        }


        public void SetInput(Vector3 input, Quaternion rotation) {
            GetComponent<BajtixPlayerController>().SetInput(input);
            transform.rotation = rotation;
        }

        private void FixedUpdate() {
            ServerSend.PlayerPosition(this);
            ServerSend.PlayerRotation(this);
        }

    }
}