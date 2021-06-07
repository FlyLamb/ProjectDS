using UnityEngine;

namespace LambWorks.Networking.Client {
    public class PlayerManager : MonoBehaviour {
        public int id;
        public string username;
        [HideInInspector]
        public Vector3 targetPosition;
        public float lerpSpeed= 1;

        public short health; // maybe it should be a *byte* instead? Not sure what value range I'll want 

        public void Initialize(int id, string username) {
            this.id = id;
            this.username = username;

            if(transform.Find("Canvas") != null)
                transform.Find("Canvas").Find("Username").GetComponent<TMPro.TextMeshProUGUI>().text = username; // TODO: idk what the fuck i should be studying now

            
        }

        private void Update() {
            transform.position = Vector3.Lerp(transform.position, targetPosition, lerpSpeed * Time.deltaTime );
            
        }
    }
}