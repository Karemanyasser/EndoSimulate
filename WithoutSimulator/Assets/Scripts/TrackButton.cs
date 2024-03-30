using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TrackButton : MonoBehaviour
{
    public Button button1; // define button. 
    public int sceneindex; // define scene index

    void Start() // Start is called before the first frame update
    {
        button1.onClick.AddListener(Track); // when we click on button ,execute 'Track function'.
    }

    void Track()
    {
        SceneManager.LoadScene(sceneindex);  // return to track menu scene.
        
    }
}
