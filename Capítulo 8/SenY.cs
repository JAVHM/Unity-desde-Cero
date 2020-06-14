using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenY : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speedY;
    public float scale;


    Vector2 pos;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        SenYmove();
    }

    public void SenYmove()
    {
        pos = transform.position;
        float newY = Mathf.Sin(Time.time * speedY);
        //Y se moverá como una seoideal multiplicada la escala que se le pida, X está en cero por la naturaleza de la senoideal
        transform.position = new Vector2(pos.x, newY * scale);
    }
}
