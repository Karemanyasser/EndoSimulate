using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Valve.VR.Extras;

public class LaserPointer : MonoBehaviour
{
    
    static SteamVR_LaserPointer laserPointer = null;

    // Start is called before the first frame update
    void Start()
    {
        // We need to find the laser pointer which we expect attached to our right hand:
        // NOTE: would be better to defend against missing SteamVR_LaserPointer component
        laserPointer = GameObject.Find("RightHand").GetComponent<SteamVR_LaserPointer>();
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
    }


    public static void PointerInside(object sender, PointerEventArgs e)
    {
        laserPointer.color = Color.yellow;
    }

    public static void PointerOutside(object sender, PointerEventArgs e)
    {
       laserPointer.color = Color.black;
    }

    public static void PointerClick(object sender, PointerEventArgs e)
    {
       SceneManager.LoadScene("MainMenuPage");
    }
}