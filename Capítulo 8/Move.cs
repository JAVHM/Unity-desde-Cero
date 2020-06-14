using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3 posA;
    public Vector3 posB;
    //Variable temporal
    public Vector3 nextPos;

    public float speed;

    //Lo llamamos childTransform porque los posición A no es el objeto, es hijo de este
    public Transform childTransform;

    public Transform BTransform;

    // Start is called before the first frame update
    void Start()
    {
        //Definimos posA, poB y a quien de ellos nos dezplazamos de nuevo
        posA = childTransform.localPosition;
        posB = BTransform.localPosition;
        nextPos = posB;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        //A se dezplaza a B
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nextPos, speed * Time.deltaTime);

        //Cuando esté muy cerca la posición del hijo a su siguiente posición se cambiará de destino al otro punto
        if(Vector3.Distance(childTransform.localPosition, nextPos) <= 0.1)
        {
            ChangeDestination();
        }

    }

    public void ChangeDestination()
    {
        //Si la siguiente posición no es A, ahora será A
        if (nextPos != posA)
        {
            nextPos = posA;
        }
        //Si la siguiente posición no es B, ahora será B
        else
        {
            nextPos = posB;
        }
    }

}
