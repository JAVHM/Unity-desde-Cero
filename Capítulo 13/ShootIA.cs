using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootIA : MonoBehaviour
{
    //Un gameobject que sea una torreta que gire y dispare al jugador
    public float Range;
    public Transform Target;
    bool Detected = false;
    Vector2 Direction;

    //especificaciones del disparador
    public GameObject AlarmLight;
    public GameObject gun;
    Quaternion originalRotationValue;
    public float rotationSpeed;

    //la bala a disparar
    public GameObject bulletPrefab;

    //la posición de salida de la bala
    public Transform firePoint;
    public float bulletSpeed;

    //sirven para la cadencia de fuego
    public float fireRate;
    float nextTimeForFire = 0;

    //usamos el booleano para definir si se dispara en su posición inicial aunque no haya nada o que sí lo haga
    public bool startAwake;

    void Start()
    {
        originalRotationValue = gun.gameObject.transform.rotation;
    }

    void Update()
    {
        //La posición del objetivo
        Vector2 targetPos = Target.position;
        //La dirección adisparar será la posición del objetivo hecho vector2
        Direction = targetPos - (Vector2)transform.position;

        //Usamos Raycast para que solo se le dispare al objeto no solo si están en rango, 
        //sino que fisicamente halla la posiblidad, por lo quue si hay un objeto de por medio por más que lo detecto NO le disparará
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, Range);

        //Si se detecta algo...
        if (rayInfo && !(rayInfo.collider.gameObject.tag == "Obstacle"))
        {
            //Si detecta algo con el tag player...
            if (rayInfo.collider.gameObject.tag == "Player")
            {
                //Si hasta ese momento la detección era falsa ahora será verdadera
                if(Detected == false)
                {
                    Detected = true;
                    //El color del rayo de advertencia mientras no se detecte objetivo será azul
                    AlarmLight.GetComponent<SpriteRenderer>().color = Color.red;
                }
            }

            //Caso contrario, se detectaba pero ya no
            else
            {
                //Como se detectaba verdadero pero ahora será falso pasa esto...
                if(Detected == true)
                {
                    Detected = false;
                    //El color del rayo de advertencia mientras se detecte objetivo será rojo
                    AlarmLight.GetComponent<SpriteRenderer>().color = Color.blue;
                }
            }
        }
        //Si se detectaba verdadero..
        if(Detected)
        {
            //El objeto al cual nos referimos como arma apunta a la dirección donde está el objetivo trasando el Vector 2 que los distancia
            gun.transform.up = Direction;
            //Si se declaró NO comeinza disparando
            if(!startAwake)
            {
                ShootAfterRoF();
            }
        }
        //si no se ha detectado un objetivo vuelve a su posición inicial
        if(!Detected)
        {
            //La rotación del arma va a la posición original en función del tiempo multiplicado por la velocidad de la rotación
            gun.transform.rotation = Quaternion.Slerp(gun.transform.rotation, originalRotationValue, Time.time * rotationSpeed);
        }
        //Si se declaro que comienza disparando 
        if(startAwake)
        {
            ShootAfterRoF();
        } 
    }

    //Los mismo que en el código shooting
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

    //Esta función hace que cuando el Gizmos esté activado se vea la circunsfeerncia en la cual actuará el Raycast
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
