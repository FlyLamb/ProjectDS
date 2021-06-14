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

            if(transform.position.y < -20) health = 0;

            if(health <= 0) {
                NetworkManager.instance.roundtimeManager.HandleDeath(GetComponent<BajtixPlayerController>());
            }
  
        }


        void OnCollisionEnter(Collision cd) {
            float impactMass = GetComponent<Rigidbody>().mass;
            if(cd.rigidbody != null) impactMass += cd.rigidbody.mass;

            float impact = impactMass * cd.relativeVelocity.magnitude;
            float dmg = Mathf.Pow(Mathf.Max(0,impact - 35), 1.1f);
            health -= (short)dmg;
        }

    }
}