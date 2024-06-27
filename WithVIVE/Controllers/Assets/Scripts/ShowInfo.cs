using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Valve.VR.InteractionSystem.Sample
{

public class ShowInfo : MonoBehaviour
{
   public Button Show; // define button. 
    public GameObject infoPanel;
    public GameObject hidearrow;
    public Button no; // define button. 
    public Image targetImage; // Image component whose color will be changed
    


    // Start is called before the first frame update
    void Start()
    {
     Show.onClick.AddListener(SHOW);  
      no.onClick.AddListener(NO); // when we click on no button ,execute 'NO function'. 
      Show.onClick.AddListener(() => ChangeColor(Color.green)); // Change color to red on button click
    }

    void SHOW()
    {
        infoPanel.SetActive(true);  //activate panel.
        hidearrow.SetActive(false); //

    }
     void NO()
    {
        infoPanel.SetActive(false);  //deactivate panel.
    }
    public void ChangeColor(Color newColor)
    {
        if (targetImage != null)
        {
            targetImage.color = newColor;
        }
        else
        {
            Debug.LogWarning("Target image is not set.");
        }
    }
}
}