using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public ObjectType ObjectType => ObjectType.Player;
    public static Action<bool> Interacted;

    private JumpObject jumpObject;
    private EnlargeObject enlargeObject;
    private GameObject currentInteractObject = null;
    [SerializeField] private GameObject interactableIcon;

    private int moveSpeed = 5;

    private void Start()
    {
        jumpObject = FindObjectOfType<JumpObject>();
        enlargeObject = FindObjectOfType<EnlargeObject>();

        interactableIcon.SetActive(false);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        Interact();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        transform.Translate(Vector2.right * horizontalInput);
    }

    public void OpenInteracableIcon()
    {
        interactableIcon.SetActive(true);
    }
    public void CloseInteracableIcon()
    {
        interactableIcon.SetActive(false);
    }

    private void Interact()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            currentInteractObject.SendMessage("CheckIfInteract");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var objectType = other.GetComponent<IObjectType>().ObjectType;

        if (objectType == ObjectType.InteracableObject)
        {
            currentInteractObject = other.gameObject;

            OpenInteracableIcon();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var objectType = other.GetComponent<IObjectType>().ObjectType;

        if (objectType == ObjectType.InteracableObject)
        {
            if(currentInteractObject = other.gameObject)
            {
                currentInteractObject = null;
            }

            CloseInteracableIcon();
        }
    }
}
