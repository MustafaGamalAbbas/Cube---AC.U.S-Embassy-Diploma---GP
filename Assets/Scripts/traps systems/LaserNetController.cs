using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserNetController : MonoBehaviour
{
    public Vector3 centeralPoint { set; get; }

    private GameManager gameManager;
    private void Start()
    {
        gameManager  = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }
    public void moveNet()
    {       
        float step = 0.2f * Time.deltaTime;
        this.transform.position = Vector3.MoveTowards(this.transform.position, centeralPoint, step);
    }
    private void OnTriggerEnter(Collider other)
    {
         if (other.gameObject.tag == "player"){
            gameManager.killPlayer();
        }
    }
    void OnCollisionEnter(Collision collision)
    {
       
    }
    
}
