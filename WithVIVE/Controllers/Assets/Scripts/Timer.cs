using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public float gameTime = 180f; // Total game time in seconds . 
    public TextMeshProUGUI timerText;   // text of timer.
    public GameObject gameoverPanel; //The text that will appear in case of time end.
  
    public static float currentTime; // Current time left in the game .

    public AudioSource audioSource; // Audio source component.
    public AudioClip timeFinishClip; // Audio clip to play when time finishes.
    public AudioClip warningClip; // Audio clip to play when time is less than 20 seconds.
    public bool warningPlayed = false;
  
    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();  //Fetch the Text from the GameObject.
        currentTime = gameTime;        // Current time equal Total game time.

       gameoverPanel.SetActive(false); // Ensure the gameover panel is initially inactive

    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;  // decrease a timer value based on the elapsed time since the last frame.
        Updatetimer();  // call update time function .

          if ( showlevel2.show == true ){
            timerText.text = string.Format("{0:00}:{1:00}", 0, 0);   //stop timer when passing
            showlevel2.show = false;
          }
            if ( SplineCustomMovement.showpanel == true  ){
            timerText.text = string.Format("{0:00}:{1:00}", 0, 0);   //stop timer when passing
            SplineCustomMovement.showpanel = false;
            }

        if (currentTime <= 0) // If time ends, do the following.
        {
            timerText.text = string.Format("{0:00}:{1:00}", 0, 0); // Represent current time equal zero.
            gameoverPanel.SetActive(true); // Activate gameover panel.

            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(timeFinishClip); // Play the time finish audio clip.
            }
        }
        else if (currentTime <= 20 && !warningPlayed) // If time is less than 20 seconds and warning hasn't been played.
        {
            audioSource.PlayOneShot(warningClip); // Play the warning audio clip.
            warningPlayed = true; // Set the warning played flag to true.
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
        warningPlayed = false;
    
    } 
}
