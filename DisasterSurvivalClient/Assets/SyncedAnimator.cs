using UnityEngine;
using LambWorks.Networking.Client;

public class SyncedAnimator : MonoBehaviour {
    //public float[] values;
    public Animator animator;

    public string[] mapping;

    public void SetValues(float[] values) {
        if(animator == null) return;
        //this.values = values;
        for (int i = 0; i < values.Length; i++) {
            animator.SetFloat(mapping[i],values[i]);
        }

    }
}
