using LambWorks.Networking.Server;
using UnityEngine;

public class Explosion : Entity {
    public float radius = 5, force = 900;

    protected override void Start() {
        base.Start();
        var objects = Physics.OverlapSphere(transform.position, radius);
        foreach (var item in objects) {
            if(item.GetComponent<Rigidbody>() != null) {
                item.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, radius);
            }
        }

        Message("Explode",(radius,force));
    }
}
