using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPlaneCollisionHandler : MonoBehaviour
{
     
    public Constants.GetWayDirection getWayDirection; 
    private void OnTriggerEnter(Collider other)
    {
        
 
         if (other.gameObject.tag == "player")
        {
            if(getWayDirection == Constants.GetWayDirection.Xneg)
            {
             
              other.gameObject.transform.position = new Vector3(other.bounds.min.x -0.4f , other.bounds.min.y -1.0f, other.bounds.min.z);
           
            }
            else if (getWayDirection == Constants.GetWayDirection.Xplus)
            {
              
                other.gameObject.transform.position = new Vector3(other.bounds.max.x +0.7f, other.bounds.max.y - 1.0f, other.bounds.max.z);
                

            }
            else if (getWayDirection == Constants.GetWayDirection.Zneg)
            {
             
                other.gameObject.transform.position = other.bounds.min + new Vector3(0, -1.0f,  -0.4f);
          

            }
            else if (getWayDirection == Constants.GetWayDirection.Zplus)
            {
              
                other.gameObject.transform.position = other.bounds.max + new Vector3(0, -1.0f, 0.7f);
              

            }
            else if (getWayDirection == Constants.GetWayDirection.Yneg)
            {
                 
                other.gameObject.transform.position = other.bounds.min + new Vector3(0, -1.8f, 0);
        
            }


        }

    }
   
}
