using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ServerSideScript : MonoBehaviour
{
    [Serializable]
    public struct Property {
        public string propertyName;
        public string value;
    }
    public string componentName;
    public Property[] properties;

    void Awake() {
        var getTypeByName = Type.GetType(componentName);
        var cw = gameObject.AddComponent(getTypeByName);
        cw = GetComponent(getTypeByName);
        foreach(Property p in properties) {
            getTypeByName.GetField(p.propertyName).SetValue(cw, p.value);
            
        }
    }
}
