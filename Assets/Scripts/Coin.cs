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
        transform.Rotate(70 * Time.deltaTime, 0, 0); // paran�n s�rekli olarak d�nen bir �ekilde g�z�kmesini sa�lad�k
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player") 
        {
            FindObjectOfType<SoundManager>().PlaySound("CoinSound"); // para kazanma sesi i�in soundmanagerdan �a��r�p coinsound sesimizi kulland�k 
            PlayerManager.NumberofCoins += 1;
           // Debug.Log("Coins="+PlayerManager.NumberofCoins); // toplanan paralar�n miktar�n� konsolda g�stermek ama�l�
            Destroy(gameObject); // e�er ana karakterimiz ise �arpan paralar�m�z�n yok olmas� i�in (para toplama g�r�n�m� ama�l�)
        }
    }
}

