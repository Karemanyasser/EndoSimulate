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

    public AudioSource audioSource; //AudioSource:A representation of audio sources in 3D.

    public AudioClip warning; //AudioClip: A container for audio data.

    public AudioClip lose; //AudioClip: A container for audio data.

    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();  //Fetch the Text from the GameObject.
        currentTime = gameTime;        // Current time equal Total game time.

        GetComponent<AudioSource>().Play(); //Fetch the AudioSource from the GameObject and play audio.

    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;  // decrease a timer value based on the elapsed time since the last frame.
        Updatetimer();  // call update time function .

          if ( showlevel2.show == true  )
            timerText.text = string.Format("{0:00}:{1:00}", 0, 0);   //stop timer when passing

        if (currentTime <=  20){
            audioSource.clip = warning; //determines the audio clip that will be played next.
		    audioSource.Play();  //Play the audio you attach to the AudioSource component.
        }

        if (currentTime <= 0)   // if time end,we will do the following.
        {
            timerText.text = string.Format("{0:00}:{1:00}", 0, 0); // represent current time equal zero.

            gameoverPanel.SetActive(true); // activate gameover panel.
            audioSource.clip = lose; //determines the audio clip that will be played next.
		    audioSource.Play();  //Play the audio you attach to the AudioSource component.
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
