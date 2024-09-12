using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public AudioSource backgroundSound;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI missedText;
    public GameObject gameOverTextPrefab; //Prefab para el texto GameOver
    public GameObject WinnerTextPrefab;//Prefab para el texto Winner
    public Transform canvasTransform; //Transform del canvas para mostrar mensaje
    public int score = 0;
    public int missed = 0;

    void Start()
    {
        ActualizarScore();
        ActualizarMissed();

    }

    public void IncrementarScore (int cantidad)
    { 
        score += cantidad;
        ActualizarScore();

        if (score >= 100)
        {
            MostrarWinner();
        }
    }

    public void IncrementarMissed(int cantidad)
    {
        missed += cantidad;
        ActualizarMissed();
        if (missed >= 10)
        {
            MostrarGameOver();
        }
    }

    void ActualizarScore()
    {
        if (scoreText != null)
        {
            scoreText.text = "StarShip: " + score.ToString();
        }
        else
        {
            Debug.LogError("Score Text no esta asignado en el Inspector.");
        }
    }

    void ActualizarMissed()
    {
        if (missedText != null)
        {
            missedText.text = "FlyShip: " + missed.ToString();

        }
        else
        {
            Debug.LogError("Missed Text no esta asignado en el Inspector");
        }
    }

    void MostrarGameOver()
    {
        Debug.Log("Juego Terminado. Has Perdido");
        Time.timeScale = 0;        

        if (backgroundSound != null)
        {
            backgroundSound.Stop();
        }

        if (gameOverTextPrefab != null && canvasTransform != null)
        {
            Instantiate(gameOverTextPrefab, canvasTransform);
        }
    }

    void MostrarWinner()
    {
        Debug.Log("Felicidades. Has Ganado ");
        Time.timeScale = 0;
        
        if (backgroundSound != null)
        {
            backgroundSound.Stop();
        }
        if (WinnerTextPrefab != null && canvasTransform != null)
        { 
            Instantiate(WinnerTextPrefab, canvasTransform);
        }
    }


    public void DispararProyectil()
    {
        NaveDefensora naveDefensora = FindObjectOfType<NaveDefensora>(); 
        if (naveDefensora != null )
        { 
            naveDefensora.Disparar();
        }
    }
}