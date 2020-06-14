using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float initialDelay;
    public float spawnRate;

    public float bulletSpeed;
    void Start()
    {
        //Le dicemos que invoque la función "Shoot", después de "initialDelay" y que cada "spawnRate" se vuelva a invocar
        InvokeRepeating("Shoot", initialDelay, spawnRate);
    }

    void Shoot()
    {
        //Hemos definido un GameObject el cual es "bullet", que está compuesto por "bulletPreba", si posición de inicio es la del punto de fuego y su rotación tambien
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        //Definimos a "rb" como un rigidBody2D que es parte de "bullet"
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        //A este "rb" de añadimos una fuerza la cual será la de la velocidad dada por el vector de inicio (su posición inicial y su rotación), y esta va a recibir un ForceMode2D.Impulse
        //ForceMode2D.Impulse le brinda un impulso inicial al "rb"
        rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
    }
}
