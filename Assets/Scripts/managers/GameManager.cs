using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : Singleton<GameManager>
{
    public GameObject player;
    public GameObject screen;
 
    private TextMeshProUGUI killMessage;

    public void strangerThingsdetected(GameObject detector)
    { 
        while (true)
        {
            if (detector.transform.parent.tag == "cube")
            {
               
                detector.transform.parent.GetComponent<CubeController>().closeAllDoors();
                detector.transform.parent.GetComponent<CubeController>().instantiateTrap();
                break; 
            }
            else
            {
                detector = detector.transform.parent.gameObject; 
            }
        }
  
    }
    
    public void killPlayer()
    {
        Debug.Log("You Dead");
        player.transform.GetChild(0).GetChild(1).GetComponent<Rigidbody>().isKinematic = false;
        player.transform.GetChild(0).GetChild(1).GetComponent<Rigidbody>().useGravity = true;
        player.transform.GetChild(0).GetChild(1).GetChild(1).gameObject.SetActive(false); 
        player.transform.GetChild(0).GetChild(1).GetChild(2).gameObject.SetActive(false);
        player.transform.GetComponent<CapsuleCollider>().isTrigger = false; 
        screen.transform.GetChild(0).gameObject.SetActive(true);
        screen.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = " You Dead! ";
    }
    
    public void requestForPlayingVideo(GameObject playOn)
    {
        playOn.GetComponent<VideoScreenLinker>().screen.GetComponent<VideoPlayerHandler>().playVideo(); 
    }
}
