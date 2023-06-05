using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Rotate(70 * Time.deltaTime, 0, 0); // paranýn sürekli olarak dönen bir þekilde gözükmesini saðladýk
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player") 
        {
            FindObjectOfType<SoundManager>().PlaySound("CoinSound"); // para kazanma sesi için soundmanagerdan çaðýrýp coinsound sesimizi kullandýk 
            PlayerManager.NumberofCoins += 1;
           // Debug.Log("Coins="+PlayerManager.NumberofCoins); // toplanan paralarýn miktarýný konsolda göstermek amaçlý
            Destroy(gameObject); // eðer ana karakterimiz ise çarpan paralarýmýzýn yok olmasý için (para toplama görünümü amaçlý)
        }
    }
}

