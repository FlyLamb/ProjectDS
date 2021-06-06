using UnityEngine;
namespace LambWorks.Networking.Server {
    public class ServerHandle {
        public static void WelcomeReceived(int fromClient, Packet packet) {
            int clientIdCheck = packet.ReadInt();
            string username = packet.ReadString();
            Debug.Log($"{Server.clients[fromClient].tcp.socket.Client.RemoteEndPoint} connected successfully and is now player {fromClient} aka {username}");
            Server.clients[fromClient].SendIntoGame();
            Server.clients[fromClient].player.username = username;
        }

        public static void PlayerMovement(int fromClient, Packet packet) {
            Vector3 inputs = packet.ReadVector3();
            Quaternion rotation = packet.ReadQuaternion();
            Quaternion camrotation = packet.ReadQuaternion();
            Server.clients[fromClient].player.SetInput(inputs, rotation, camrotation);
        }

        public static void MessageEntity(int fromClient, Packet packet) {
            uint id = (uint)packet.ReadLong();
            string msg = packet.ReadString();
            object obj = packet.ReadObject();
            Server.entities[id].SendMessage(msg, obj);
        }

        public static void PlayerInteract(int fromClient, Packet packet) { // TODO: dear future me; FOR GODS SAKE KURWA REMAKE THIS PLEASE
            Server.clients[fromClient].player.GetComponent<BajtixPlayerController>().Interaction();
        }

    }
}