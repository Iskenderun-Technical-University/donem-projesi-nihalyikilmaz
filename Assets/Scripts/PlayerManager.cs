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

        UpdateHighScore(); // yeni en yüksek skoru oyunun baþýnda göstermesi için

        

    }


    void Update()
    {

        if (GameOver)
        {
           
            Time.timeScale = 0;
            GameOverPanel.SetActive(true);
            UpdateHighScore(); // yeni en yüksek skoru oyunun sonunda da göstermesi için

        }

        if (NumberofCoins > PlayerPrefs.GetInt("HighScore", 0)) // en yüksek skoru kontrol ediyoruz.
        {
            PlayerPrefs.SetInt("HighScore", NumberofCoins);  // ayný zamanda burada High Score'a NUmberofCoins yani altýnlarýmýzýn sayýsý yerine 0 yazarak en yüksek skoru sýfýrlayabiliriz.
        }

        GameObject.Find("CoinsText").GetComponent<TMPro.TextMeshProUGUI>().SetText("Score: " + NumberofCoins.ToString()); //score yazan yazýya paralar toplandýkça miktarýný yazdýrýyoruz.

        

        if (Input.GetKeyDown(KeyCode.Space))  // space tuþuna basýnca baþlamasý için player controller kýsmýnda game started ile yönlendireceðiz
        {
            GameStarted = true;
            Destroy(StartingText);
            FindObjectOfType<SoundManager>().PlaySound("MenuSound"); // space tuþun basma sesi ekledik
        }

       
    }

    

    void UpdateHighScore() //en yüksek skor güncelleme
    {
        
        highscore.text = $"HighScore: {PlayerPrefs.GetInt("HighScore", 0)}";
    }

}
