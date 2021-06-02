using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCamera : MonoBehaviour {
    public bool controlRotationY;
    

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {

        transform.localRotation *= Quaternion.Euler(-Input.GetAxis("Mouse Y"),0, 0);

        if(controlRotationY) {
            transform.parent.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X"), 0);
        }
    }
}
