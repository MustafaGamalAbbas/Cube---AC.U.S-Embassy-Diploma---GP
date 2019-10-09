using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSystemController : MonoBehaviour
{
    public bool turn;
    private ParticleSystem[] particleSystems = new ParticleSystem[8];
    private SoundManager soundManager; 
    void Start()
    {
        for(int i =0; i< 8;i++)
                particleSystems[i] = transform.GetChild(i).GetComponent<ParticleSystem>();

        soundManager = GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>();
        soundManager.playFireSound(transform.GetChild(9).GetComponent<AudioSource>());
     }
 
    void Update()
    {
        if (turn)
        {
            turnOn();
        }

    }


    public void turnOn()
    {
      
        for (int i = 0; i < 8; i++)
            particleSystems[i].Play();
         

    }

}
