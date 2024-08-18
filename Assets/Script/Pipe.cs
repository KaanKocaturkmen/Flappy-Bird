using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float acceleration;

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector2.left * Time.deltaTime * acceleration);
        
        if (transform.position.x < -24.13f)
        {
            float randomNum = UnityEngine.Random.Range(5.5f, -2.3f);
            transform.position = new Vector2(0f, randomNum);
        }
    }
}
