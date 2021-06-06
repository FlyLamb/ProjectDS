using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {
    public bool isUsed = false;
    ///<summary>Called when player E-clicks the Interactable</summary>
    ///<returns>Should the object be marked as player-used?</summary>
    public virtual bool OnInteract(BajtixPlayerController player) {
        return false;
    }

    ///<summary>Called every FixedUpdate when player is using the Interactable</summary>
    ///<returns>Should the object still be used next frame</summary>
    public virtual bool OnUsing(BajtixPlayerController player) {
        return false;
    }

    ///<summary>Called when player manually stops using the Interactable</summary>
    ///<returns>Can the player stop using it?</summary>
    public virtual bool Throw(BajtixPlayerController player) {
        return true;
    }
}
