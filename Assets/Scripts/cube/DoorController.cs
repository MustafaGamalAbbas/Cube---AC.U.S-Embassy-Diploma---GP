using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Vector3 verticalOpeningPosition, horizontalOpeningPosition,  initPosition;
    private InteriorDoorController interiorDoorController;

    private float speed = 1.0f;
    private bool interiorClosed = false;


    void Start()
    {
        interiorDoorController = this.gameObject.transform.GetChild(2).gameObject.GetComponent<InteriorDoorController>();
        
        initPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
   
    public void open()
    {
        float step = 1.0f * Time.deltaTime;

        this.transform.position = Vector3.MoveTowards(this.transform.position, verticalOpeningPosition, step);
        if (isVerticallyOpened())
        {
            interiorDoorController.setTranslationPoint(horizontalOpeningPosition);
            interiorDoorController.open();
        }

        interiorClosed = false;
    }
    public bool isVerticallyOpened()
    {
        return (Vector3.Distance(this.transform.position, verticalOpeningPosition) < 0.00001f);
    }
    public bool isTotallyOpened()
    {
        return interiorDoorController.isInteriorOpened();
    }
    public bool isTotallyClosed()
    {
        return (Vector3.Distance(this.transform.position, initPosition) < 0.001f);
    }

    public void close()
    {
        if (interiorClosed)
        {
            float step = 1.0f * Time.deltaTime;
            transform.position = Vector3.MoveTowards(this.transform.position, initPosition, step);
        }
        else if(!interiorClosed)
        {
            interiorDoorController.close();
            interiorClosed = interiorDoorController.isClosed();
        }

    }
    public void setTranslationPoints(Vector3 verticalPosition, Vector3 horizontalPosition)
    {
        verticalOpeningPosition = verticalPosition;
        horizontalOpeningPosition = horizontalPosition; 
    }
}
