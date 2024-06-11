using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Showchecklist : MonoBehaviour
{
     public Button Show; // define button. 
    public GameObject infoPanel;
    public GameObject hidearrow;
    public GameObject showarrow1;
    public GameObject showarrow2;
    public GameObject showarrow3;

    public Button no; // define button. 

    // Start is called before the first frame update
    void Start()
    {
        Show.onClick.AddListener(SHOW);  
        Show.onClick.AddListener(SHOWarrow);  
      no.onClick.AddListener(NO); // when we click on no button ,xecute 'NO function'.
      
    }

     void SHOW()
    {
        
        infoPanel.SetActive(true);  //activate panel.
        hidearrow.SetActive(false); //
        

    }
    void SHOWarrow()
    {
        showarrow1.SetActive(true);
        showarrow2.SetActive(true); //
        showarrow3.SetActive(true);
        //
        

    }

     void NO()
    {
        infoPanel.SetActive(false);  //deactivate panel.
    }
}
