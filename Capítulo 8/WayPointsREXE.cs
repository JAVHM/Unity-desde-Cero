using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointsREXE : MonoBehaviour
{
    //Lista de GameObjects
    public GameObject[] waypoints;
    int current = 0;
    public float speed;
    double WPradius = 0.2;
    bool A = true;

    public Transform prefab;

    void Update()
    {
        //Si A es verdadero
        if (A)
            GoingUpList();
        //Si A es falso
        if (!A)
            GoingDownList();
    }

    //Se corre la lista de wayPoints desde el primero hasta el último
    void GoingUpList()
    {
        //Si la distancia entre el la posición del punto referente (de la lista) y la posición actual del objeto es menor al radio del punto referente
        if (Vector3.Distance(waypoints[current].transform.position, prefab.position) < WPradius)
        {
            //Se le suma a waypoint al que se dirige +1, por lo que se desplza al siguiente waypoint
            current++;
            //Si el número de posición del waypoint corriente no está en el arreglo se vuelve a iniciar el patrón
            if (current >= waypoints.Length)
            {
                current = current - 2;
                A = false;
            }
        }
        //Posición del objeto actual se mueve hacia la posición de Waypoint[n] en un tiempo determinado 
        prefab.position = Vector3.MoveTowards(prefab.position, waypoints[current].transform.position, speed * Time.deltaTime);
    }

    //Se corre la lista de wayPoints de el útlimo hasta el primero
    void GoingDownList()
    {
        //Si la distancia entre el la posición del punto referente (de la lista) y la posición actual del objeto es menor al radio del punto referente
        if (Vector3.Distance(waypoints[current].transform.position, prefab.position) < WPradius)
        {
            //Ahora se le resta 1 a waypoint, por lo que se al termni en la posición anterior.
            current--;
            //Cuando se llama a la posición -1, se le suma 2, por lo que se va ahora a la posición 1, y ahora A es verdadero.
            if (current < 0)
            {
                current = current + 2;
                A = true;
            }
        }
        //Posición del objeto actual se mueve hacia la posición de Waypoint[n] en un tiempo determinado 
        prefab.position = Vector3.MoveTowards(prefab.position, waypoints[current].transform.position, speed * Time.deltaTime);
    }
}
