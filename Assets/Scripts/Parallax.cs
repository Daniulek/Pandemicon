using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float speed = 0.5f;

    Material material;
    Vector2 offset;

    private void Awake()
    {
        material = GetComponent<Renderer>().material;
    }
    void Start()
    {

        offset = new Vector2(0, speed);

    }

    // Update is called once per frame
    void Update()
    {
        material.mainTextureOffset += offset * Time.deltaTime;
       
    }
}
