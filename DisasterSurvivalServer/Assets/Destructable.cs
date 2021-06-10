using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LambWorks.Networking.Server;

public class Destructable : Entity {
    public float collisionSpeed = 12;
    public GameObject spawnOnImpact;

    void OnCollisionEnter(Collision c) {
        if(c.relativeVelocity.magnitude > collisionSpeed) {
            Destruction();
        }
    }

    public virtual void Destruction() {
        if(spawnOnImpact != null) Instantiate(spawnOnImpact,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
