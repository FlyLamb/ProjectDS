using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieInstance : MonoBehaviour {
    public GameObject prefab;
    public float prefabLifetime;

    Vector3 previousPosition;
    float avgvelocity;

    bool isQuitting;
    private GameObject tempInstance;
    Vector3 delta;
    
    void OnApplicationQuit() {
        isQuitting = true;
    }

    void Update() {

        delta = transform.position - previousPosition;

        avgvelocity = Mathf.Lerp(avgvelocity,delta.magnitude/Time.deltaTime, Time.deltaTime * 20);

        previousPosition = transform.position;
    }

    void OnDestroy() {
        if(isQuitting) return;
        tempInstance = Instantiate(prefab, transform.position, transform.rotation);
        foreach(var w in tempInstance.GetComponentsInChildren<Rigidbody>()) {
            w.AddForce(delta/Time.deltaTime * 30);
            w.AddExplosionForce(avgvelocity * 9, transform.position, 2);
        }

        if(prefabLifetime > 0)
            Destroy(tempInstance,prefabLifetime);
        
    }

}
