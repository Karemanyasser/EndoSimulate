using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
   
    public Button exit; // define exit button. 

    public Button yes; // define yes button. 

    public Button no; // define no button. 

    public GameObject exitPanel; // define exit panel
    public int sceneindex; //define scene index

    void Start() // Start is called before the first frame update
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
        SceneManager.LoadScene(sceneindex);  // load exit scene. 
    }

     void NO()
    {
        exitPanel.SetActive(false);  //deactivate panel.
    }
}
