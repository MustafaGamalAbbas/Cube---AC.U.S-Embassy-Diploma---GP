using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTC.UnityPlugin.Vive;
using HTC.UnityPlugin.VRModuleManagement;

public class RaycastHandler : MonoBehaviour
{
    private bool isActive = false;
    private Vector3 forward, start;

    private static int VideoPlayerScreenLayer = 13;
    private GameManager gameManager; 
    private SoundManager soundManager;
    private void Start()
    {
        soundManager = GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>();
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        if (ViveInput.GetPressDown(HandRole.LeftHand, ControllerButton.Trigger))
            isActive = !isActive;

        if (isActive)
        {
            start = transform.GetChild(1).position; 
            forward = transform.GetChild(2).position; 
            Debug.DrawRay( start, transform.GetChild(1).forward*2.5f, Color.green);
            this.gameObject.GetComponent<LineRenderer>().positionCount = 2;
            this.gameObject.GetComponent<LineRenderer>().SetPositions(new Vector3[2] { start,  forward }); 
            this.gameObject.GetComponent<LineRenderer>().startWidth = 0.05f;
            this.gameObject.GetComponent<LineRenderer>().endWidth = 0.05f;
        }
        else
        {
                this.gameObject.GetComponent<LineRenderer>().positionCount = 0; 
        }
        
         
    }
 
    void FixedUpdate()
    {
       // Debug.Log(" asdasdasd " + Vector3.Distance(forward, start)); 
        RaycastHit hit;
         if (isActive && Physics.Raycast(start, transform.GetChild(1).forward * 2.5f, out hit,2.5f))
        {
            Debug.Log(" hit : " + hit.transform.gameObject.tag);
            if (hit.transform.gameObject.tag.Equals("InteriorDoor"))  
                {
                Door door = hit.transform.parent.parent.gameObject.GetComponent<Door>(); 
                if(door == null)
                    door = hit.transform.parent.parent.parent.gameObject.GetComponent<Door>();

                if (door.isClosed()){
                    door.open = true;
                    soundManager.playDoorSound(door.transform.GetChild(5).GetComponent<AudioSource>());
                    GameObject cube = door.transform.parent.parent.GetComponent<WallCubeLinker>().cube;
                    if (cube)
                        cube.SetActive(true);
                }
                else if (door.isOpened()){
                    door.open = false;
                    door.close = true;
                   soundManager.playDoorSound(door.transform.GetChild(5).GetComponent<AudioSource>());
                    GameObject cube = door.transform.parent.parent.GetComponent<WallCubeLinker>().cube;
                    if (cube)
                        cube.SetActive(false);

                }



            }
            else if (hit.transform.gameObject.layer == VideoPlayerScreenLayer)
            {
                gameManager.requestForPlayingVideo(hit.transform.gameObject);
            }


        }
        else
        {
           // Debug.Log("Did not Hit");
        }
    }
}
