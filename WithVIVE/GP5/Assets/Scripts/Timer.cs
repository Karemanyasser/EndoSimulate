using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public float gameTime = 30f; // Total game time in seconds . 
    public TextMeshProUGUI timerText;   // text of timer.
    public GameObject gameoverPanel; //The text that will appear in case of time end.
  
    public static float currentTime; // Current time left in the game .

    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();  //Fetch the Text from the GameObject.
        currentTime = gameTime;        // Current time equal Total game time.
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;  // decrease a timer value based on the elapsed time since the last frame.
        Updatetimer();  // call update time function .
        if (currentTime <= 0)   // if time end,we will do the following.
        {
            timerText.text = string.Format("{0:00}:{1:00}", 0, 0); // represent current time equal zero.

            gameoverPanel.SetActive(true); // activate gameover panel.
           
        }
        
    }
   void Updatetimer()  //update timergame
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);  //calculate minutes from current time and floor.
        int seconds = Mathf.FloorToInt(currentTime % 60f);  // calculate seconds from current time and floor.
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // represent of minutes and seconds.
    }

    public void RestartTimer()  //when reload game
    {
        currentTime = gameTime; //return to value of game Time.
        gameoverPanel.SetActive(false);  //deactivate gameover panel.
    
    } 
}
