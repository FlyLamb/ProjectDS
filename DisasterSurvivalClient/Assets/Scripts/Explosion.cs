using LambWorks.Networking.Client;
using UnityEngine;

public class Explosion : Entity
{
    public void Explode((float,float) prms) {
        var objects = Physics.OverlapSphere(transform.position, prms.Item1);
        foreach (var item in objects) {
            if(item.GetComponent<Rigidbody>() != null) {
                item.GetComponent<Rigidbody>().AddExplosionForce(prms.Item2, transform.position, prms.Item1);
            }
        }
    }
}
