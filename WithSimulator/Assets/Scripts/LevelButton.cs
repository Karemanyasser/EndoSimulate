using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.PlayerLoop;

public class LevelButton : MonoBehaviour
{

    public Button button1; // define level button. 
    public Button start; // define start button. 
    public Button quit; // define quit button. 
    public GameObject Panel;   // define levelpanel. 

    public int sceneindex; // define scene index

    // Start is called before the first frame update
    void Start()
    {
        button1.onClick.AddListener(Level); // when we click on level button ,execute 'Level function'.
        start.onClick.AddListener(StartButton); // when we click on start button ,execute 'StartButton function'.
        quit.onClick.AddListener(QuitButton); // when we click on quit button ,execute 'QuitButton function'.
        
    }
    void Level()
    {
        Panel.SetActive(true);  //activate panel.
    }
    void StartButton()
    {
        SceneManager.LoadScene(sceneindex);  // Go to room scene

    }
    void QuitButton()
    {
        Panel.SetActive(false);  //deactivate panel.
        
    }
}
