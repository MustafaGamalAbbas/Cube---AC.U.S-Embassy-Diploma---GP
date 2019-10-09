using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSystemController : MonoBehaviour 
{
    public bool turn;
    private LaserNetController  netController =new LaserNetController() ;
    private SoundManager soundManager;
     void Start()
    {
       
        netController = this.gameObject.transform.GetChild(0).GetComponent<LaserNetController>();
        netController.centeralPoint = this.gameObject.transform.GetChild(1).transform.position;
        soundManager = GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>();
        soundManager.playLaserSound(transform.GetChild(2).GetComponent<AudioSource>());

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
       netController.moveNet();
    }

    public void turnOff()
    {

    }
  

}
