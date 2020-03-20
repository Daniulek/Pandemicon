using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AchievHP : MonoBehaviour
{
    GameObject motherCell;
    private TextMeshProUGUI textMesh;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        motherCell = GameObject.FindGameObjectWithTag("MotherCell");
    }

    void Update()
    {
        
        textMesh.text = "LONG SURVIVOR! +" + ((motherCell.GetComponent<MotherCell>().multiplier - 1) * 25).ToString() + "HP";

    }
}
