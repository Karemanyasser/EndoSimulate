using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Back : MonoBehaviour
{
   
    public Button Back_button; // define back button. 
    public int sceneindex;  // define scene index
    
    // Start is called before the first frame update
    void Start()
    {
        Back_button.onClick.AddListener(BackButton); // when we click on button ,execute 'BackButton function'.
    }

    void BackButton()
    {
        SceneManager.LoadScene(sceneindex);  // return to previous scene.
        
    }
}
