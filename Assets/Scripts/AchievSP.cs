using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AchievSP : MonoBehaviour
{
    GameSession gameSession;
    private TextMeshProUGUI textMesh;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        gameSession = FindObjectOfType<GameSession>();
    }

    void Update()
    {

        textMesh.text = "CORONAS HUNTER!!! \n +" + ((gameSession.GetMultiplierSP() * 1) - 1).ToString() + " SHOT POWER";

    }
}
