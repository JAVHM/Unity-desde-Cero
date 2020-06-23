using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Este spawner determina la velocidad
public class Spawner : MonoBehaviour
{
    //Lista de objetos a generar
    public GameObject[] gameObject2Shoot;

    //la posición de salida del objeto
    public Transform firePoint;
    public float bulletSpeed;

    //sirven para la cadencia de fuego
    public float fireRate;
    float nextTimeForFire = 0;

    Vector2 whereToSpawn;
    public float randx;
    public float randy;
    public float rangoMaxDeX;
    public float rangoMaxDeY;
    public float rangoMinDeX;
    public float rangoMinDeY;
    int randObj;


    private void Update()
    {
        ShootAfterRoF();
    }

    void Shoot()
    {
        //Se agregan estas dos lineas en las cuales definimos el rango de movimiento en X en los cuales puede spawnear de forma aleatoria
        //whereToSpawn transforma los randx y rand y en un Vector para poder ser puesto en la línea 45 en el Instantiate
        randx = Random.Range(rangoMinDeX, rangoMaxDeX);
        randy = Random.Range(rangoMinDeY, rangoMaxDeY);
        randObj = Random.Range(0, gameObject2Shoot.Length);
        whereToSpawn = new Vector2(randx, randy);

        //Hemos definido un GameObject el cual es "obj2mov" (objeto a mover), que está compuesto por 1 objeto en la lista de gameObject2Shoot, si posición de inicio es la del punto de fuego y su rotación tambien
        GameObject obj2mov = Instantiate(gameObject2Shoot[randObj], whereToSpawn + (Vector2)firePoint.position, firePoint.rotation);
        //Definimos a "rb" como un rigidBody2D que es parte de "obj2mov"
        Rigidbody2D rb = obj2mov.GetComponent<Rigidbody2D>();

        //A este "rb" de añadimos una fuerza la cual será la de la velocidad dada por el vector de inicio (su posición inicial y su rotación), y esta va a recibir un ForceMode2D.Impulse
        //ForceMode2D.Impulse le brinda un impulso inicial al "rb"
        rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);

        
    }

    void ShootAfterRoF()
    {
        //Se especifica cadencia de fuego aquí poruqe como está en update se llama cada frame
        if (Time.time > nextTimeForFire)
        {
            //Mientras el siguiente tiempo de disparo sea menor al tiempo transcurrido pasa esto se prepara el siguiten nuevo disparo
            nextTimeForFire = Time.time + 1 / fireRate;

            //Función previamente vista en los capítulos anteriores
            Shoot();
        }
    }
}
