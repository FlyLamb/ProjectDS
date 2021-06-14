using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LambWorks.Networking.Server;

public class ChatHandler : MonoBehaviour
{
    public static ChatHandler instance;

    private void Awake( ) {
        instance = this;
    }

    public void Send(string msg) {
        ServerSend.ChatMessage(msg);
    }
}
