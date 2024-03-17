using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTC.UnityPlugin.ColliderEvent;
using HTC.UnityPlugin.Utility;
using UnityEngine.SceneManagement;


public class HoverAction : MonoBehaviour
{
    private Camera vrCamera; // Assuming your Vive Pro2 camera rig has a camera component attached
    private RaycastHit hit;

    void Start()
    {
        vrCamera = GetComponentInChildren<Camera>(); // Assuming the camera is a child of the camera rig
    }

    void Update()
    {
        if (Physics.Raycast(vrCamera.transform.position, vrCamera.transform.forward, out hit))
        {
            HoverAction hoverAction = hit.collider.GetComponent<HoverAction>();
            if (hoverAction != null)
            {
                SceneManager.LoadScene(7);
            }
        }
    }
}
