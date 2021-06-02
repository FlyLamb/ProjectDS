using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class AssetBundleLoader : MonoBehaviour {
    void Start() {
        var bundle 
            = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "map"));
        if (bundle == null) {
            Debug.Log("Failed to load AssetBundle!");
            return;
        }
        string[] scenePath = bundle.GetAllScenePaths();
        SceneManager.LoadScene(scenePath[0], LoadSceneMode.Additive);
    }
}