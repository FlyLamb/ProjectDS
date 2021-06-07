using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LambWorks.Networking.Server;

public class Palette : Entity
{
    void OnCollisionEnter(Collision c) {
        if(c.relativeVelocity.magnitude > 12) {
            Destroy(gameObject);
        }
    }
}
