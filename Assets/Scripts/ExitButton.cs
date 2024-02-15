using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
   
    public Button exit; // define exit button. 

    public Button yes; // define yes button. 

    public Button no; // define no button. 

    public GameObject exitPanel; 
    public int sceneindex;

    void Start()
    {
        exit.onClick.AddListener(EXIT); // when we click on exit button ,execute 'exit function'.
        yes.onClick.AddListener(YES); // when we click on yes button ,execute 'YES function'.
        no.onClick.AddListener(NO); // when we click on no button ,execute 'NO function'.
    }
    void EXIT()
    {
        exitPanel.SetActive(true);  //activate panel.
    }

    void YES()
    {
        SceneManager.LoadScene(sceneindex);  // exit. 
    }

     void NO()
    {
        exitPanel.SetActive(false);  //deactivate panel.
    }
}
