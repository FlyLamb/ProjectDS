using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabRegistry : MonoBehaviour
{
    public static PrefabRegistry instance;

    private void Awake() {
        instance = this;
    }


    public List<GameObject> registry;

}
