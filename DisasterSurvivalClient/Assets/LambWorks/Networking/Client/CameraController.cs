using UnityEngine;

namespace LambWorks.Networking.Client {
    public class CameraController : MonoBehaviour {
        public PlayerManager player;
        public float sensitivity = 100f;
        public float clampAngle = 85f;

        private Camera me;

        private float verticalRotation;
        private float horizontalRotation;

        private Vector3 delta;
        private Vector3 lastPos;
        private float estSpeed;

        private void Start() {
            verticalRotation = transform.localEulerAngles.x;
            horizontalRotation = player.transform.eulerAngles.y;

            sensitivity = ConArg.GetFloat("--set_sens");
            me= GetComponent<Camera>();
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                ToggleCursorMode();
            }

            if (Cursor.lockState == CursorLockMode.Locked) {
                Look();
            }
            Debug.DrawRay(transform.position, transform.forward * 2, Color.red);

            estSpeed = Mathf.Lerp(estSpeed, delta.magnitude/Time.deltaTime, Time.deltaTime * 5);
            delta = transform.position - lastPos;
            lastPos = transform.position;

            me.fieldOfView = Mathf.Clamp(60 + estSpeed * 1.5f, 62,75);
        }

        private void Look() {
            float _mouseVertical = -Input.GetAxis("Mouse Y");
            float _mouseHorizontal = Input.GetAxis("Mouse X");

            verticalRotation += _mouseVertical * sensitivity * Time.deltaTime;
            horizontalRotation += _mouseHorizontal * sensitivity * Time.deltaTime;

            verticalRotation = Mathf.Clamp(verticalRotation, -clampAngle, clampAngle);

            transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
            player.transform.rotation = Quaternion.Euler(0f, horizontalRotation, 0f);

        }

        private void ToggleCursorMode() {
            Cursor.visible = !Cursor.visible;

            if (Cursor.lockState == CursorLockMode.None) {
                Cursor.lockState = CursorLockMode.Locked;
            } else {
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}