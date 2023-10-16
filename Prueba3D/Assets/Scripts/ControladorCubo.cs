using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCubo : MonoBehaviour
{
    private float movX;
    private float movZ;
    public float jump;
    Rigidbody rb;
    public float speed = 5;
    public bool itsUp;
    void Start()
    {
       
       rb = GetComponent<Rigidbody>();
        itsUp = false;
    }

   

    void Update()
    {
        movX = Input.GetAxis("Horizontal");
        movZ = Input.GetAxis("Vertical");
        if (Input.GetButtonDown("Jump"))
        {
            itsUp = true;
        }

    }
    void FixedUpdate()
    {

        Vector3 newVelocity = new Vector3(movX * speed, rb.velocity.y, movZ * speed);
        rb.velocity = newVelocity;
        
        
        if (itsUp)
        {
            rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
            itsUp = false;
        }

    }
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Terreno")
        {
            itsUp = false;
        }
    }
    
}
