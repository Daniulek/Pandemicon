using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AchievMS : MonoBehaviour
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

        textMesh.text = "RUN HERO RUN!!! \n +" + (gameSession.GetMultiplierMS() * 1).ToString() + " MOVE SPEED";

    }
}
