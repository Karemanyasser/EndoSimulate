using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StomachTrack : MonoBehaviour
{
    public Button button1; // define button. 

    void Start()
    {
        button1.onClick.AddListener(Stomach); // when we click on button ,execute 'Stomach function'.
    }

    void Stomach()
    {
        SceneManager.LoadScene("StomachMenuScene");  //Go to Stomach levels scene.

    }
}
