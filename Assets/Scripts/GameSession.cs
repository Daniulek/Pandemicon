using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    int score = 0;
    int coronas = 0;
    int bonusSP = 1;
    int bonusMS = 1000;
    int shotPower = 5;
    int playerMoveSpeed = 10;
    int multiplierSP = 1;
    int multiplierMS = 1;

    private void Awake()
    {
        SetUpSingleton();
        
    }

    private void SetUpSingleton()
    {
        int numberGameSessions = FindObjectsOfType<GameSession>().Length;

        if (numberGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void AddToScore(int scoreValue)
    {
        score += scoreValue;
        AddMoveSpeed(score);
    }

    public int GetCoronas()
    {
        return coronas;
    }

    public void CountCorona() 
    {
        coronas += 1;
        AddShotPower(coronas);
        
    }

    public void AddShotPower(int coronasValue) // SHOT POWER ACHIEVEMENT
    {
        

        if (coronasValue >= bonusSP)
        {
            shotPower += 1 * multiplierSP;
            multiplierSP += 1;
            //Debug.Log(" Coronas: " + coronas + " BonusSP: " + bonusSP + " Multiplier: " + multiplierSP + " ShotPower: " + shotPower);
            bonusSP = bonusSP * 10;
            
        }

    }

    public int GetSP()
    {
        return shotPower;
    }

    public void AddMoveSpeed(int scoreValue)  // MOVE SPEED ACHIEVEMENT
    {
        if (scoreValue >= bonusMS)
        {

            playerMoveSpeed += 1 * multiplierMS;
            Debug.Log(" SCORE: " + score + " BonusMS: " + bonusMS + " MultiplierMS: " + multiplierMS + " PLAYERMOVESPEED: " + playerMoveSpeed);
            multiplierMS += 1;
            bonusMS = bonusMS * 10;

        }
    }

    public int GetMS()
    {
        return playerMoveSpeed;
    }


    public void ResetGame()
    {
        Destroy(gameObject);

    }

}
