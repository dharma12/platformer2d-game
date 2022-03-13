using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnlargeObject : MonoBehaviour, IObjectType, IInteracable
{
    public ObjectType ObjectType => ObjectType.InteracableObject;

    
    private bool isEnlarge;

    private void Start()
    {
        isEnlarge = false;
    }

    public void CheckIfInteract()
    {
        ChangeSize();
    }

    private void ChangeSize()
    {
        if (isEnlarge == false)
        {
            Enlarge();
            //Debug.Log("Enlarge");
        }
        else
        {
            Shrink();
            //Debug.Log("Shrink");
        }
    }

    private void Enlarge()
    {
        transform.localScale = new Vector2(15, 15);
        isEnlarge = !isEnlarge;
    }

    private void Shrink()
    {
        transform.localScale = new Vector2(9, 9);
        isEnlarge = !isEnlarge;
    }
}
