using LambWorks.Networking.Client;
using UnityEngine;

public class ConnectToServer : MonoBehaviour {
    public void Start() {
        if(!Application.isEditor) {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1, UnityEngine.SceneManagement.LoadSceneMode.Additive); 
            Client.instance.ip = ConArg.Get("--host");
        }

        Client.instance.ConnectToServer();
    }
}
