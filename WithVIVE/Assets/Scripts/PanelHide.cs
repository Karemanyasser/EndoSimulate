using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTC.UnityPlugin.ColliderEvent;
using HTC.UnityPlugin.Utility;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PanelHide : MonoBehaviour 
{
    public GameObject Panel;   // define levelpanel. 
    private bool isHovered = false;

    void Update()
    {
        if (isHovered)
        {
            for(int i = 0; i < 5; i++);
            Panel.SetActive(false);  //activate panel.
        }
    }

    public void OnPointerEnter()           // Called when the hand pointer enters the object
    {
        isHovered = true;
    }

    public void OnPointerExit()              // Called when the hand pointer exits the object
    {
        isHovered = false;
    }


}


