using System.Collections;
using UnityEngine;
using LambWorks.Networking.Server;

public class PeriodicSpawner : Entity { // some dum dum code for spawning objects
    public GameObject prefab;
    public float interval = 10f;

    public bool startOnStart = true;

    public GameObject isThereASpawned = null;

    protected override void Start() {
        if(startOnStart) StartCoroutine(Spawn());
    }

    protected override void FixedUpdate() { 
        if(isThereASpawned == null) StartCoroutine(Spawn());

        
    }

    public override void Send()
    { }

    public IEnumerator Spawn() {
        isThereASpawned = gameObject;
        yield return new WaitForSeconds(10);
        isThereASpawned = Instantiate(prefab,transform.position,transform.rotation);
    }
}
