using UnityEngine;

namespace LambWorks.Networking.Client {
    public class PlayerController : MonoBehaviour {
        public Transform camTransform;

        private void FixedUpdate() {
            SendInputToServer();
        }

        private void Update() {
            if(Input.GetKeyDown(KeyCode.E))
            ClientSend.PlayerInteract();
        }

        /// <summary>Sends player input to the server.</summary>
        private void SendInputToServer() {
            Vector3 inputs = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Input.GetButton("Jump") ? 1 : 0);

            ClientSend.PlayerMovement(inputs);
        }
    }
}