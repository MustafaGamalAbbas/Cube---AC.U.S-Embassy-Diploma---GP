using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTC.UnityPlugin.Vive;
using HTC.UnityPlugin.VRModuleManagement;
public class GrapAndThrowHandler : MonoBehaviour
{
  
    private GameObject child;

    void Update()
    {
        Collider[] Colliders = Physics.OverlapSphere(transform.position, 0.1f);
        if (ViveInput.GetPressDown(HandRole.RightHand, ControllerButton.Trigger) || ViveInput.GetPressDown(HandRole.LeftHand, ControllerButton.Trigger))
        {
            if (Colliders.Length > 0 && Colliders[0].gameObject.layer == 14)
            {
                Colliders[0].gameObject.transform.parent = this.transform;
                child = Colliders[0].gameObject;
                child.GetComponent<Rigidbody>().isKinematic = true;
                child.GetComponent<Rigidbody>().useGravity = false;
            }
        }

        if (ViveInput.GetPressUp(HandRole.RightHand, ControllerButton.Trigger) || ViveInput.GetPressUp(HandRole.LeftHand, ControllerButton.Trigger))
        { 
            if(child != null)
            {
                child.GetComponent<Rigidbody>().isKinematic = false;
                uint deviceIndex = ViveRoleProperty.New(HandRole.RightHand).GetDeviceIndex();
                Vector3 v = VRModule.GetDeviceState(deviceIndex, false).velocity;
                Vector3 Av = VRModule.GetDeviceState(deviceIndex, false).angularVelocity;

                child.GetComponent<Rigidbody>().velocity = v;
                child.GetComponent<Rigidbody>().angularVelocity = Av; 
                child.GetComponent<Rigidbody>().useGravity = true;
                child.transform.parent = null;
            }

        }

    }

    


}
