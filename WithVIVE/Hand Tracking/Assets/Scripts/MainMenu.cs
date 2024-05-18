using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

   public void GoToLogin(){
    SceneManager.LoadScene(1);
   }

   public void GoToPlay(){
    SceneManager.LoadScene(3);
   }

}
