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
    
    void OnApplicationQuit() {
        isQuitting = true;
    }

    void Update() {

        Vector3 delta = transform.position - previousPosition;

        avgvelocity = Mathf.Lerp(avgvelocity,delta.magnitude/Time.deltaTime, Time.deltaTime * 20);

        previousPosition = transform.position;
    }

    void OnDestroy() {
        if(isQuitting) return;
        tempInstance = Instantiate(prefab, transform.position, transform.rotation);
        foreach(var w in tempInstance.GetComponentsInChildren<Rigidbody>()) {
            w.AddExplosionForce(avgvelocity * 10, transform.position, 4);
        }

        if(prefabLifetime > 0)
            Destroy(tempInstance,prefabLifetime);
        
    }

}
