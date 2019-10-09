using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteriorDoorController : MonoBehaviour
{
    
    private Vector3 horizontalOpeningPosition , initPosition , init ;
    void Start()
    {
        initPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        init = initPosition; 
    }
    public void open()
    {
        float step = 1.0f * Time.deltaTime;
        this.transform.position = Vector3.MoveTowards(this.transform.position, horizontalOpeningPosition, step);
    }

    public bool isInteriorOpened()
    {
        return (Vector3.Distance(this.transform.position, horizontalOpeningPosition) < 0.00001f);
    }
    public void close()
    {
        float step = 1.0f * Time.deltaTime;
        this.transform.position = Vector3.MoveTowards(this.transform.position, initPosition, step);
    }
    public bool isClosed()
    {
        return (Vector3.Distance(this.transform.position, initPosition) < 0.00001f);
    }

    public void setTranslationPoint(Vector3 position)
    {
        if (initPosition == init)
            initPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        horizontalOpeningPosition = position; 
    } 
}
