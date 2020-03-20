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
    Animator achievAnimMS;
    Animator achievAnimSP;


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
            achievAnimSP = GameObject.FindGameObjectWithTag("AchievSP").GetComponent<Animator>();
            shotPower += 1 * multiplierSP;
            achievAnimSP.SetTrigger("start");
            multiplierSP += 1;
            //Debug.Log(" Coronas: " + coronas + " BonusSP: " + bonusSP + " Multiplier: " + multiplierSP + " ShotPower: " + shotPower);
            bonusSP = bonusSP * 10;
     
        }

    }
    public int GetMultiplierSP()
    {
        return multiplierSP;
    }

    public int GetSP()
    {
        return shotPower;
    }

    public void AddMoveSpeed(int scoreValue)  // MOVE SPEED ACHIEVEMENT
    {
        if (scoreValue >= bonusMS)
        {
            achievAnimMS = GameObject.FindGameObjectWithTag("AchievMS").GetComponent<Animator>();
            playerMoveSpeed += 1 * multiplierMS;
            achievAnimMS.SetTrigger("start");
            //Debug.Log(" SCORE: " + score + " BonusMS: " + bonusMS + " MultiplierMS: " + multiplierMS + " PLAYERMOVESPEED: " + playerMoveSpeed);
            multiplierMS += 1;
            bonusMS = bonusMS * 10;

        }
    }

    public int GetMultiplierMS()
    {
        return multiplierMS;
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
