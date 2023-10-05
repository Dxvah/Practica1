using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerS : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 5f;
    public float movX;
    public float movY;
    public int diamante = 0;
    SpriteRenderer p_SpriteRenderer;
    public GameObject canvasVictoria;
    public GameObject canvasDerrota;
    public TextMeshProUGUI timerText;
    public float tiempoRestante = 60.0f;
    public TextMeshProUGUI diamantesText;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        p_SpriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        movX = Input.GetAxis("Horizontal");
        movY = Input.GetAxis("Vertical");
        tiempoRestante -= Time.deltaTime;
        if(tiempoRestante <=0)
        {
            MostrarCanvasDerrota();
        }
    }
    void FixedUpdate()
    {
        Vector2 vector = new Vector2(movX * 5, movY * 5);
        rb.velocity = vector;

    }
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Diamante")
        {
            diamante++;
            //diamantesText = 
            Destroy(col.gameObject);

        }
        else if(col.gameObject.tag == "Meta")
        {
            PauseGame();
            Destroy(col.gameObject);
            MostrarCanvasVictoria();
        }
        else if (col.gameObject.tag == "Rotatorio")
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            Invoke("ReactivarMovimiento", 2f);
            p_SpriteRenderer.color = Color.red;

        }
        else if (col.gameObject.tag == "Pinchos")
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            Invoke("ReactivarMovimiento", 3f);
            p_SpriteRenderer.color = Color.red;
        }
    }
    void ReactivarMovimiento()
    {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        p_SpriteRenderer.color = Color.white;

    }
    void MostrarCanvasVictoria()
    {
        canvasVictoria.SetActive(true);
    }
    void MostrarCanvasDerrota()
    {
        //canvasDerrota().SetActive(true);
    }
}