using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleActiveOnClick : MonoBehaviour
{
    void Update()
    {
        // Check if the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Check if the main camera exists
            if (Camera.main != null)
            {
                // Create a ray from the camera to the mouse position
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                // Check if the ray hits the collider of the GameObject
                if (Physics.Raycast(ray, out hit))
                {
                    // Check if the hit object is the one this script is attached to
                    if (hit.transform == transform)
                    {
                        // Toggle the active state
                        gameObject.SetActive(!gameObject.activeSelf);
                    }
                }
            }
            else
            {
                Debug.LogError("No camera with 'MainCamera' tag found in the scene.");
            }
        }
    }
}