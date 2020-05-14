using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public string up;
    public string down;
    public string left;
    public string right;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(up))
        {
            rb.velocity = new Vector2(0f, speed);
        }
        else if (Input.GetKey(down))
        {
            rb.velocity = new Vector2(0f, -1 * speed);
        }
        else if (Input.GetKey(left))
        {
            rb.velocity = new Vector2(-1 * speed, 0);
        }
        else if (Input.GetKey(right))
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(0f, 0f);
        }
    }

}

