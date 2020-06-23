using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutScene : MonoBehaviour
{

    float maxX = 14;
    float minX = -14;
    float maxY = 10;
    float minY = -10;

    void Update()
    {
        if (gameObject.transform.position.x > maxX || gameObject.transform.position.x < minX || gameObject.transform.position.y > maxY || gameObject.transform.position.y < minY)
        {
            Destroy(gameObject);
        }
    }
}