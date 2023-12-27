using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KneeTrack : MonoBehaviour
{
    
    public Button button1; // define button. 

    void Start()
    {
        button1.onClick.AddListener(Knee); // when we click on button ,execute 'Knee function'.
    }

    void Knee()
    {
        SceneManager.LoadScene("KneeMenuScene");  //Go to knee levels scene.

    }
}
