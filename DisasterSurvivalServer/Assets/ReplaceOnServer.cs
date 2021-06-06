using UnityEngine;

public class ReplaceOnServer : MonoBehaviour {
    public string id;

    void Start() {
        foreach(var w in PrefabRegistry.instance.registry) {
            if(w.GetComponent<LambWorks.Networking.Server.Entity>().model == id)
                Instantiate(w, transform.position, transform.rotation, transform.parent);
            
        }

        Destroy(gameObject);
    }
}