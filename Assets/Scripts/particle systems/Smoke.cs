using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    private GameManager gameManager;
    private bool isTrapped = false;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnParticleCollision(GameObject other)
    {
        if(other.gameObject.layer == 11&& ! isTrapped)
        {
            isTrapped = true;
            StartCoroutine(Example());
        }
    
    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(5);
        gameManager.killPlayer();
    }
}
