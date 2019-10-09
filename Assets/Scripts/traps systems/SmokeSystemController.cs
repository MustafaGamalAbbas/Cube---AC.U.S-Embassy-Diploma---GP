using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeSystemController : MonoBehaviour
{
    private SoundManager soundManager;

    void Start()
    {
        soundManager = GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>();
        soundManager.playSpreadingSmokeSound(transform.GetChild(2).GetComponent<AudioSource>());
    }
 
}
