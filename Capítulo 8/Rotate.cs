using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //El objeto rotará en Z a la velocidad "speed"
        transform.Rotate(0, 0, speed);
    }
}
