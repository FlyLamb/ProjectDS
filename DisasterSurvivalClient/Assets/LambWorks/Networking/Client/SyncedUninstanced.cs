using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;
using LambWorks.Networking.Client;

public class SyncedUninstanced : MonoBehaviour {

    int Hash(GameObject s) {
        int result = 0;
        for (int i = 0; i < s.name.Length; i++)
        {
            result += ((short)s.name[i]);
        }

        result *= (int)Mathf.Abs(s.transform.position.x);
        return result;
    }

    // this code is terrible, it makes me wanna die and if it doesn't work i'll prolly be contemplating suicide. Sorry, future me!

    void Awake() {
            var component = gameObject.AddComponent<LerpedEntity>();     
            uint id = (uint)Hash(gameObject);
            component.id = id;
            component.lerpSpeed = 40f;
            GameManager.entities.Add(id, component);

            Destroy(GetComponent<Rigidbody>());
    } 

    /* FOOTNOTE: 
        I have just discovered that i am unable to include scripts in asset bundles in a simple manner. This sucks, but I can't really be bothered to change the code, so I'll just use this thing for now.
    */
}
