
using UnityEngine;
using UnityEngine.UI;


public class Tryagain : MonoBehaviour
{
   public GameObject errorPanel;   // define errorPanel. 
   public Button TryagainButton;



    void Start()
    {
        TryagainButton.onClick.AddListener(Hide); // when we click on Tryagain Button ,execute 'Hide function'.
    }

     void Hide()
    {
        errorPanel.SetActive(false);  //deactivate panel.
    }


}
