using UnityEngine;
using UnityEngine.UI;

public class PanelHide : MonoBehaviour 
{
    public GameObject Panel;   // define levelpanel. 

    public Button button1; // define button. 

      void Start()
    {
        button1.onClick.AddListener(ButtonAction); // when we click on button ,execute 'ButtonAction function'.
    }

    void ButtonAction()
    {
        Panel.SetActive(false);
}

}


