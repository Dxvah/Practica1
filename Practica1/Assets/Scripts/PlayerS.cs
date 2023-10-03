using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerS : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 5f;
    public float movX;
    public float movY;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        movX = Input.GetAxis("Horizontal");
        movY = Input.GetAxis("Vertical");
    }
    void FixedUpdate()
    {
        Vector2 vector = new Vector2(movX * 5,movY * 5);
        rb.velocity = vector;

    }
}