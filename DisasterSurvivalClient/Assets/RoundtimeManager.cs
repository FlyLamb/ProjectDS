using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundtimeManager : MonoBehaviour {
    public float roundTime = -69420f;

    public TMPro.TextMeshProUGUI timeDisplay;

    void Update() {
        int time = Mathf.Abs((int)roundTime);

        int minutes = (int)Mathf.Floor(time/60f);
        int seconds = time - minutes * 60;

        timeDisplay.text = $"{minutes}:{seconds:00}";
    }
}
