using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QGizmo : MonoBehaviour
{
    public Mesh mesh;
    public Color gizmoColor = Color.green;

    void OnDrawGizmos() {
        if(mesh == null) return;
        Gizmos.color = gizmoColor;
        Gizmos.DrawMesh(mesh, 0, transform.position, transform.rotation, transform.localScale);
    }
}
