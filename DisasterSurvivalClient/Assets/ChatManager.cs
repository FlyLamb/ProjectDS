using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI chat;
    public void Chat(string msg) {
        chat.text += "\n" +msg;
    }
}
