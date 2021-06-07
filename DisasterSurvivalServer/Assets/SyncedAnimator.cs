using UnityEngine;
using LambWorks.Networking.Server;

public class SyncedAnimator : MonoBehaviour {
   public float[] values;



   void FixedUpdate() {
       ServerSend.PlayerAnimation(GetComponent<Player>().id, values);
   }
}
