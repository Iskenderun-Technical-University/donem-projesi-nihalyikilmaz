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
            s.source.volume = s.volume; // ses ayarlamalar� yapmak i�in sound manager �zerinden


        }

        //PlaySound("MainTheme"); oyun �ark�s� i�in olan bu kodu kapatt�k. Ana ekranda buton ile a� kapa yapmak i�in
        
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
