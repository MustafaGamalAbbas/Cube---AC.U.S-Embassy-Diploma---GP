using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEdgeCollisionHandler : MonoBehaviour
{
    public Constants.DoorEdge doorEdge;
    private void OnTriggerEnter(Collider other)
    {

       
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "player")
        {
            if(doorEdge == Constants.DoorEdge.Right)
            {
                other.gameObject.transform.position -= new Vector3(0, 0, 0.4f);
            }
            else if(doorEdge == Constants.DoorEdge.Left)
            {
                other.gameObject.transform.position += new Vector3(0,0,0.2f);
            }


        }

    }
 
}
