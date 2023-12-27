using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UterusTrack : MonoBehaviour
{
     public Button button1; // define button. 

    void Start()
    {
        button1.onClick.AddListener(Uterus); // when we click on button ,execute 'Uterus function'.
    }

    void Uterus()
    {
        SceneManager.LoadScene("UterusMenuScene");  //Go to Uterus levels scene.

    }
}
