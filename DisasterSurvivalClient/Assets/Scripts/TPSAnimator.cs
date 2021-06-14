using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSAnimator : MonoBehaviour
{
    private Vector3 delta;
        private Vector3 lastPos;
        private float estSpeed;
        public Animator animator;

        void Start() {
            
        }

        void Update() {
            estSpeed = Mathf.Lerp(estSpeed, delta.magnitude/Time.deltaTime, Time.deltaTime * 5);
            delta = transform.position - lastPos;
            lastPos = transform.position;

            animator.SetFloat("Speed", estSpeed * 0.25f);

            
        }
}
