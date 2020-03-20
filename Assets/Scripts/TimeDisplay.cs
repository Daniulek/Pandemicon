using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeDisplay : MonoBehaviour
{
    private TextMeshProUGUI timeText;
    private int timeElapsed;

    void Start()
    {
        timeText = GetComponent<TextMeshProUGUI>();
        //timeElapsed = Integer(Time.timeSinceLevelLoad);
    }


    void Update()
    {
        timeText.text = "TIME: " + Time.timeSinceLevelLoad.ToString("0");
        
    }
}
