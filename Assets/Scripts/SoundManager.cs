using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public Sound[] sounds;



    void Start()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.volume = s.volume; // ses ayarlamalarý yapmak için sound manager üzerinden


        }

        //PlaySound("MainTheme"); oyun þarkýsý için olan bu kodu kapattýk. Ana ekranda buton ile aç kapa yapmak için
        
    }

   public void PlaySound(string name)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == name)
                s.source.Play();


        }


    }

    

  
}
