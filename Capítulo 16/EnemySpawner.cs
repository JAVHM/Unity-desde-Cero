using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Objeto a spawnear
    public GameObject EnemyShip;
    float randx;

    //Donde spawneará. En este caso será en un valor aleatorio de X
    Vector2 whereToSpawn;
    public float spawnRate = 1f;
    float nextSpawn = 0.0f;
    public int necessaryScore;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ( necessaryScore <= Score.score )
        {
            if (Time.time > nextSpawn)
            {
                //El siguiente ibjeto a Spwanear va  a cumplir esta condición: 
                nextSpawn = Time.time + spawnRate;
                randx = Random.Range(-9f, 9f);
                whereToSpawn = new Vector2(randx, transform.position.y);
                //Instanciamos el objeto nave enemiga, le decimos donde spawnear, Quaternion.identity hace que la rotación no afecte
                Instantiate(EnemyShip, whereToSpawn, Quaternion.identity);
            }
        }
        
    }
}
