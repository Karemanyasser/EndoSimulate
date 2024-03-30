using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Back : MonoBehaviour
{
   
    public Button button1; // define back button. 
    public int sceneindex; // define scene index

    void Start() // Start is called before the first frame update
    {
        button1.onClick.AddListener(BackButton); // when we click on button ,execute 'BackButton function'.
    }

    void BackButton()
    {
        SceneManager.LoadScene(sceneindex);  // return to previous scene.
        
    }
}
