using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTC.UnityPlugin.ColliderEvent;
using HTC.UnityPlugin.Utility;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ButtonAction : MonoBehaviour ,IColliderEventHoverEnterHandler
{
    public int sceneindex;

    public void OnColliderEventHoverEnter(ColliderHoverEventData eventData)
    {
        for(int i = 0; i < 10; i++);
        SceneManager.LoadScene(sceneindex);
    }

}


