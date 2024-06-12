using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Showpanel : MonoBehaviour
{
    public Button Show; // define button. 
    public GameObject infoPanel;
    // Start is called before the first frame update
    void Start()
    {
        Show.onClick.AddListener(SHOW); 
    }

    void SHOW()
    {
        infoPanel.SetActive(true);  //activate panel.
       

    }
}
