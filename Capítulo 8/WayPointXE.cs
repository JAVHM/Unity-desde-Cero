using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointXE : MonoBehaviour
{
    public GameObject[] waypoints;
    int current = 0;
    public float speed;
    double WPradius = 0.2;
    public Transform prefab;

    //[0,1,2,3,4]
    //[a,b,c,d,f]
    void Update()
    {
        //Recorrer la lista de Waypoints desde el primero hasta el último, si estas en el ultimo, vuelve al primero
        //Si la distancia entre el la posición del punto referente (de la lsita) y la posición actual del objeto es menor al radio del punto referente
        if (Vector3.Distance(waypoints[current].transform.position, prefab.position) < WPradius)
        {
            //Se le suma a waypoint al que se dirige +1, por lo que se desplza al siguiente waypoint
            current++;
            //Si el número de posición del waypoint corriente no está en el arreglo se vuelve a iniciar el patrón
            if (current >= waypoints.Length)
            {
                current = 0;
            }
        }
        //Posición del objeto actual se mueve hacia la posición de Waypoint[n] en un tiempo determinado 
        prefab.position = Vector3.MoveTowards(prefab.position, waypoints[current].transform.position, speed * Time.deltaTime);
    }
}
