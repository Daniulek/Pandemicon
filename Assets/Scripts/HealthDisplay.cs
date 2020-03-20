using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    private TextMeshProUGUI healthText;


    void Start()
    {
        healthText = GetComponent<TextMeshProUGUI>();

    }


    void Update()
    {
        healthText.text = "HEALTH: " + GameObject.FindGameObjectWithTag("MotherCell").GetComponent<MotherCell>().health;
    }

}
