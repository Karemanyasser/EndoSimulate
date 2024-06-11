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
        if ( targetImage1.color == Color.green &&
             targetImage2.color == Color.green &&
             targetImage3.color == Color.green)
        {
            infoPanel.SetActive(true);  // Activate panel
        }
        else
        {
            infoPanel.SetActive(false);  // Deactivate panel if colors are not green
        }
    }
}
