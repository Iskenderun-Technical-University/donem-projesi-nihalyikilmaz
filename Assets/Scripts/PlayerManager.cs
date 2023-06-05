using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerManager : MonoBehaviour
{
    [SerializeReference] TextMeshProUGUI highscore;

    public static bool GameOver;
    public GameObject GameOverPanel;

    public static bool GameStarted;

    public GameObject StartingText;

    public static int NumberofCoins;
    public GameObject ScoreText;
    public GameObject highScore;

    
    
    void Start()
    {
        GameOver = false;
        Time.timeScale = 1;

        GameStarted = false;

        NumberofCoins = 0;

        UpdateHighScore(); // yeni en y�ksek skoru oyunun ba��nda g�stermesi i�in

        

    }


    void Update()
    {

        if (GameOver)
        {
           
            Time.timeScale = 0;
            GameOverPanel.SetActive(true);
            UpdateHighScore(); // yeni en y�ksek skoru oyunun sonunda da g�stermesi i�in

        }

        if (NumberofCoins > PlayerPrefs.GetInt("HighScore", 0)) // en y�ksek skoru kontrol ediyoruz.
        {
            PlayerPrefs.SetInt("HighScore", NumberofCoins);  // ayn� zamanda burada High Score'a NUmberofCoins yani alt�nlar�m�z�n say�s� yerine 0 yazarak en y�ksek skoru s�f�rlayabiliriz.
        }

        GameObject.Find("CoinsText").GetComponent<TMPro.TextMeshProUGUI>().SetText("Score: " + NumberofCoins.ToString()); //score yazan yaz�ya paralar topland�k�a miktar�n� yazd�r�yoruz.

        

        if (Input.GetKeyDown(KeyCode.Space))  // space tu�una bas�nca ba�lamas� i�in player controller k�sm�nda game started ile y�nlendirece�iz
        {
            GameStarted = true;
            Destroy(StartingText);
            FindObjectOfType<SoundManager>().PlaySound("MenuSound"); // space tu�un basma sesi ekledik
        }

       
    }

    

    void UpdateHighScore() //en y�ksek skor g�ncelleme
    {
        
        highscore.text = $"HighScore: {PlayerPrefs.GetInt("HighScore", 0)}";
    }

}
