using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponenteRotatorio : MonoBehaviour
{
    

     public float rotacionZ = 45f;


    void Update()
    {

        transform.Rotate(0f, 0f, rotacionZ * Time.deltaTime);



    }
}
