using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class StrangerThingsSensor : MonoBehaviour
{
    GameManager manager;

    void Start()
    {
        manager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>(); 
    }
  
    private void OnTriggerEnter(Collider other)
    {
 
        if (other.gameObject.tag == "player")
        {
            manager.strangerThingsdetected(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player" || collision.gameObject.tag == "things")
               manager.strangerThingsdetected(this.gameObject);
 
    }
}
