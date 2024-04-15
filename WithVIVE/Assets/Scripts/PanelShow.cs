using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PanelShow : MonoBehaviour 
{
    public GameObject Panel;   // define levelpanel. 
    private bool isHovered = false;

    void Update()
    {
        if (isHovered)
        {
            for(int i = 0; i < 5; i++);
            Panel.SetActive(true);  //activate panel.
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


