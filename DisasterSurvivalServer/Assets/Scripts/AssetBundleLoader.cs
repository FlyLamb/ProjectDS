using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;
using LambWorks.Networking.Server;

public class AssetBundleLoader : MonoBehaviour {
    string mapScenePath;

    public static AssetBundleLoader instance;

    void Awake() {
        instance = this;
    }

    void Start() {
        var bundle 
            = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "map"));
        if (bundle == null) {
            Debug.Log("Failed to load AssetBundle!");
            return;
        }
        string[] scenePath = bundle.GetAllScenePaths();
        mapScenePath = scenePath[0];
        LoadMap();
    }

    public void LoadMap() {
        StartCoroutine(Load());
    }

    private IEnumerator Load() {
        Debug.Log("Start load");
        var ao = SceneManager.LoadSceneAsync(mapScenePath, LoadSceneMode.Additive);
        ao.allowSceneActivation = false;
        while(ao.progress < 0.9f) yield return new WaitForEndOfFrame();
        
        ao.allowSceneActivation = true;
        
        yield return new WaitForEndOfFrame();
        Debug.Log("Finish load");
    }

    public void UnloadMap() {
        foreach(Entity item in Server.entities.Values) {
            item.transform.position = Vector3.down * 100000f;
            item.Send();
            Debug.Log("Clearing item " + item.gameObject.name);
            ServerSend.DestroyEntity(item);
            Destroy(item.gameObject, 0.1f);
        }
        Server.entities.Clear();
        SceneManager.UnloadScene(mapScenePath);
        SceneManager.SetActiveScene(SceneManager.GetSceneAt(0));
    }
}