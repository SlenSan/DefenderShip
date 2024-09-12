using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float velocidad = 10f;
    public float tiempoDeVida = 2f;

    private void Start()
    {
        Destroy(gameObject, tiempoDeVida);
    }

    void Update()
    {
        transform.Translate(Vector2.up * velocidad * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("NaveEnemiga"))
        {
            Destroy(other.gameObject); // destruye nave enemiga
            Destroy(gameObject); // destruye el proyectil

            //Incrementa puntaje
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.IncrementarScore(10); // incrementa de 10 en 10
            }
            else
            {
                Debug.LogError("No se encontro el GameManager en la escena");
            }
        }
        
    }
}
