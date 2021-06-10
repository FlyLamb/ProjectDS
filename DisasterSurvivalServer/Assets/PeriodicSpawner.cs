using System.Collections;
using UnityEngine;
using LambWorks.Networking.Server;

public class PeriodicSpawner : Entity {
    public GameObject prefab;
    public float interval = 10f;

    public bool startOnStart = true;

    protected override void Start() {
        if(startOnStart) StartCoroutine(Spawn());
    }

    protected override void FixedUpdate()
    { }

    public override void Send()
    { }

    public IEnumerator Spawn() {
        while(true) {
            Instantiate(prefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(interval);
        }
    }
}
