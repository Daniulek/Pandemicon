using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{

    private TextMeshProUGUI scoreTextMesh;
    private GameSession gameSession;



    void Start()
    {

        scoreTextMesh = GetComponent<TextMeshProUGUI>();
        gameSession = FindObjectOfType<GameSession>();
 
    }


    void Update(){scoreTextMesh.text = "SCORE: " + gameSession.GetScore().ToString("000000");}

}
