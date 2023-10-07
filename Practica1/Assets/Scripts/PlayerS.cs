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
    public int diamantesTotales = 5;
    public GameObject canvasVictoria;
    public GameObject canvasDerrota;
    public TextMeshProUGUI timerText;
    private float tiempoRestante = 60.0f;
    private bool partidaTerminada = false;
    SpriteRenderer p_SpriteRenderer;
    public TextMeshProUGUI nDiamantes;
    public TextMeshProUGUI cuantosDiamantes;
    public AudioSource audioVictoria;
    public AudioSource audioDerrota;
    public AudioSource audiofondo;
    private bool sonidosMuteados = false;


    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canvasVictoria.SetActive(false);
        canvasDerrota.SetActive(false);
        p_SpriteRenderer = GetComponent<SpriteRenderer>();
        ActualizarTextoDiamantes();
    }


    void Update()
    {
        movX = Input.GetAxis("Horizontal");
        movY = Input.GetAxis("Vertical");
        if (!partidaTerminada)
        {
            tiempoRestante -= Time.deltaTime;
            timerText.text = ": " + Mathf.Round(tiempoRestante).ToString();

            if (tiempoRestante <= 0)
            {
                tiempoRestante = 0;
                MostrarCanvasDerrota();
                PauseGame();
                
            }
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
            Destroy(col.gameObject);
            ActualizarTextoDiamantes();
            if(diamante < 4)
            {
                cuantosDiamantes.text = "Ooooh, vaya pena. No has conseguido ningun diamante";
            }
            else if (diamante >= 4 && diamante < diamantesTotales)
            {
                cuantosDiamantes.text = "¡Has terminado! Aún así, te has dejado algunos diamantes por el camino";
            }
            else 
            {
                cuantosDiamantes.text = "Perfect! Has conseguido todos los diamantes ¡Felicidades!";
            }

        }
        else if(col.gameObject.tag == "Meta")
        {
            MostrarCanvasVictoria();
            PauseGame();
            Destroy(col.gameObject);
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
        if (audiofondo != null && audioVictoria != null && sonidosMuteados)
        {
            audiofondo.UnPause();
            audioVictoria.UnPause();
            sonidosMuteados = false;
        }
        
    }

    void MostrarCanvasDerrota()
    {
        canvasDerrota.SetActive(true);
        if (audiofondo != null && audioDerrota != null && sonidosMuteados)
        {
            audiofondo.UnPause();
            audioDerrota.UnPause();
            sonidosMuteados = false;
        }
        
  
    }
    private void ActualizarTextoDiamantes()
    {
        nDiamantes.text = ": " + diamante + " / " + diamantesTotales;
    }
}