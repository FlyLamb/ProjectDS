using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _SpawnPalet : MonoBehaviour
{
    public GameObject paleta;
    public Transform[] paletySpots;

    void Start() {
        StartCoroutine(Spawnuj());
    }

    IEnumerator Spawnuj() {
        while(true) {
        yield return new WaitForSeconds(3);
        
        Instantiate(paleta, paletySpots[Random.Range(0,paletySpots.Length)].position, Quaternion.identity);
        }
    }
}
