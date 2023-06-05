using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSoundAudio : MonoBehaviour
{
    // Sahne deðiþþe bile, yani oyun tekrar baþlasa da ana sesimiz olan þarkýnýn kaldýðý yerden devam etmesi için

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
