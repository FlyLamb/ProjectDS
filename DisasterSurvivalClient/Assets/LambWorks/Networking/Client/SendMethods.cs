using UnityEngine;

namespace LambWorks.Networking.Client {
    public partial class ClientSend {
        /// <summary>Confirms the player id with the server, this is sent when Welcome is received</summary>
        public static void WelcomeReceived() {
            using (Packet packet = new Packet((int)ClientPackets.welcomeReceived)) {
                packet.Write(Client.instance.myId);
                packet.Write(ConArg.Get("--username"));
                SendTCPData(packet);
            }
        }

        /// <summary>Sends player input to the server.</summary>
        /// <param name="inputs"></param>
        public static void PlayerMovement(Vector3 inputs) {
            using (Packet packet = new Packet((int)ClientPackets.playerMovement)) {
                packet.Write(inputs);
                packet.Write(GameManager.players[Client.instance.myId].transform.rotation);
                packet.Write(GameManager.players[Client.instance.myId].transform.Find("Camera").rotation); // TODO: remove the transform.find
                SendUDPData(packet);
            }
        }

        /// <summary>Sends a message (essentially attempts to call a function) in the server entity</summary>
        /// <param name="entity">The entity to message.</param>
        /// <param name="message">The name of the function to call</param>
        /// <param name="parameter">The object to send as the parameter to the function</param>
        public static void MessageEntity(Entity entity, string message, object parameter = null) {
            using (Packet packet = new Packet((int)ClientPackets.entityMessage)) {
                packet.Write(entity.id);
                packet.Write(message);
                packet.WriteObject(parameter);

                SendTCPData(packet);
            }
        }

        public static void PlayerInteract() {
            using (Packet packet = new Packet((int)ClientPackets.playerInteract)) {
                SendTCPData(packet);
            }
        }
    }

}