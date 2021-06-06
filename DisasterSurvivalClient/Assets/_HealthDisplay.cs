using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LambWorks.Networking.Client;
using UnityEngine.UI;
public class _HealthDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text =  GameObject.Find("LocalPlayer(Clone)").GetComponent<PlayerManager>().health.ToString();
    }
}
