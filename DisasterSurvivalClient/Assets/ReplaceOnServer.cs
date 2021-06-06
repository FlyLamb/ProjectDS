using UnityEngine;
using System.Collections;

public class ReplaceOnServer : MonoBehaviour { 
    public string id; 

    void Start() {
        StartCoroutine(DestroyTimer());
    }

    IEnumerator DestroyTimer() {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }

    public void StopPerformDie() {
        StopAllCoroutines();
        Destroy(this);
    }
}
