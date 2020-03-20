using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] AudioClip gameOverSound;
    [SerializeField] [Range(0, 1)] float gameOverSoundVolume = 0.75f;


    void Start()
    {
        AudioSource.PlayClipAtPoint(gameOverSound, Camera.main.transform.position, gameOverSoundVolume);
    }

    
    void Update()
    {
        
    }
}
