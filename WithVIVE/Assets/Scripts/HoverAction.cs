using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTC.UnityPlugin.ColliderEvent;
using HTC.UnityPlugin.Utility;
using UnityEngine.SceneManagement;


public class HoverAction : MonoBehaviour
{
    private Camera vrCamera; // Assuming your Vive Pro2 camera rig has a camera component attached
    private RaycastHit hit; // Variable to store information about a raycast hit.

    void Start() // Start is called before the first frame update
    {
        vrCamera = GetComponentInChildren<Camera>(); // Assuming the camera is a child of the camera rig
    }

    void Update() // Update is called once per frame
    {
        // Perform a raycast from the VR camera's position in the direction it is facing.
        // If the raycast hits something, store information about the hit in the 'hit' variable.
        if (Physics.Raycast(vrCamera.transform.position, vrCamera.transform.forward, out hit))
        {
            HoverAction hoverAction = hit.collider.GetComponent<HoverAction>(); // Get the HoverAction component attached to the collider of the object hit by the raycast.
            if (hoverAction != null)
            {
                SceneManager.LoadScene(7);  // load scene of index 7
            }
        }
    }
}
