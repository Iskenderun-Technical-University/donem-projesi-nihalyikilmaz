using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSoundAudio : MonoBehaviour
{
    // Sahne de�i��e bile, yani oyun tekrar ba�lasa da ana sesimiz olan �ark�n�n kald��� yerden devam etmesi i�in

    private static MainSoundAudio instance = null;
    public static MainSoundAudio Instance
    {
    get { return instance; }
    } 
    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

}
