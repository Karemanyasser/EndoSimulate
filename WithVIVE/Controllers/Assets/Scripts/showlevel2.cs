using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class showlevel2 : MonoBehaviour
{
   
    public GameObject infoPanel;
    public Image targetImage1;
    public Image targetImage2;
    public Image targetImage3;

    Color green= new Color(0.0f, 1.0f, 0.0f);


    public static bool  show = false;

    // Start is called before the first frame update
    void Start()
    {
        CheckImagesAndShowPanel();
    }

    // Update is called once per frame
    void Update()
    {
        CheckImagesAndShowPanel();
    }

     void CheckImagesAndShowPanel()
    {
        if ( targetImage1.color == green &&
             targetImage2.color == green &&
             targetImage3.color == green)
        {
            infoPanel.SetActive(true);  // Activate panel
            show = true; 
        }
        else
        {
            infoPanel.SetActive(false);  // Deactivate panel if colors are not green
        }
    }
}
