using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yeetable : Interactable
{
    private BajtixPlayerController lastInteracted;

    public override bool OnInteract(BajtixPlayerController player) {
        GetComponent<Rigidbody>().AddForce(Vector3.up * 100);
        lastInteracted = player;
        
        return !isUsed;
    }

    public override bool OnUsing(BajtixPlayerController player) {
        Vector3 dp = player.lookTransform.position + player.lookTransform.forward * 3f + Vector3.up * 0.5f;
        Vector3 force = (dp - transform.position) * (Vector3.Distance(dp, transform.position) - 1);

        GetComponent<Rigidbody>().AddForce(force * Time.fixedDeltaTime * 5000);

        GetComponent<Rigidbody>().drag = Vector3.Distance(dp, transform.position) < 10 ? 8 : 0;
        

        return Vector3.Distance(dp, transform.position) < 10;
    }

    public override bool Throw(BajtixPlayerController player) {
        GetComponent<Rigidbody>().AddForce(player.lookTransform.forward * Time.fixedDeltaTime * 60000);
        GetComponent<Rigidbody>().drag = 0;
        return true;
    }

}
