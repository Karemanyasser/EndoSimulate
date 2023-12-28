using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CharacterHover : MonoBehaviour
{
    private bool isHovered = false;
    private Quaternion startRotation;
    public float rotationSpeed = 30f;

    void Start()
    {
        // Store the initial rotation
        startRotation = transform.rotation;
    }

    void Update()
    {
        // Rotate the character when hovered over
        if (isHovered)
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
        else
        {
            // Reset the rotation to the initial rotation
            transform.rotation = Quaternion.Lerp(transform.rotation, startRotation, Time.deltaTime * 5f);
        }
    }

    public void OnPointerEnter()
    {
        // Called when the mouse pointer enters the character
        isHovered = true;
        
    }

    public void OnPointerExit()
    {
        // Called when the mouse pointer exits the character
        isHovered = false;
        
    }

    public void OnPointerClick()
    {
        // Called when the object is clicked
        SceneManager.LoadScene("StartScene"); 
    }
}
