using UnityEngine;
using System.Collections;

public class ReplaceOnServer : MonoBehaviour { 
    public string id; 

    void Start() {
        StartCoroutine(DestroyTimer());
    }

    IEnumerator DestroyTimer() {
        yield return new WaitForSeconds(0.1f);
        gameObject.SetActive(false);
        gameObject.transform.position = Vector3.down * 1000; // stupid OnDestroy workaround
        Destroy(gameObject);
    }

    public void StopPerformDie() {
        StopAllCoroutines();
        Destroy(this);
    }
}
