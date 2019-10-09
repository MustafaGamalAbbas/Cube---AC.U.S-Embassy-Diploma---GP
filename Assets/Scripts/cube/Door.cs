using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public  bool  close = false;
    public bool open = false ;

    private  DoorController doorController;

    void Start()
    {
        doorController = this.gameObject.transform.GetChild(1).GetComponent<DoorController>();
        doorController.setTranslationPoints(this.gameObject.transform.GetChild(3).transform.position, this.gameObject.transform.GetChild(4).transform.position);      
    }

    

    void Update(){
        if (open) {
            openDoor();
        }
        else if(close)
        {
            closeDoor(); 
        }
    }
    public void openDoor()
    {
        doorController.open();
    }
    public void closeDoor()
    { 
        doorController.close();
    }
    public bool isOpened()
    {
        return doorController.isTotallyOpened();
    }
    public bool isClosed()
    {
        return doorController.isTotallyClosed();
    }

}

