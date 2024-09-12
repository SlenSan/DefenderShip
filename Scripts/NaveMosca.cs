using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveMosca : MonoBehaviour
{
    public float velocidad = 5f;
    public AudioClip sonidoExplosion;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("El componente AudioSource no se encontro en NaveMosca");
        }
    }

    void Update()
    {
        transform.Translate(Vector2.down * velocidad * Time.deltaTime);

        if (transform.position.y < -6) //Ajusta segun la posicion de tu escenario
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.IncrementarMissed(1); //Incrementa el contador de naves perdidas
            }
            Destroy(gameObject); // Destruye la nave que se paso
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Proyectil"))
        {
            Debug.Log("Reproduciendo sonido de explosion");
            // Reproducir sonido de explosion
            if (audioSource != null && sonidoExplosion != null)
            {
                audioSource.PlayOneShot(sonidoExplosion);
            }
            else
            {
                Debug.LogError("AudioSource o sonidoExplosion no esta asignado.");
            }
        }

    }
}
