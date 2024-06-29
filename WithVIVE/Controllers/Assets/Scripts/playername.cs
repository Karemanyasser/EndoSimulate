using UnityEngine;
using UnityEngine.UI;

public class Playername : MonoBehaviour
{
    public Text playerDisplay;
    public Text scoreText; // Added Text component for displaying score.

    private void Start()
    {
        if (DBManager.LoggedIn)
        {
            playerDisplay.text = "Welcome: " + DBManager.FirstName + " " + DBManager.LastName;
            
            //Check if the score is valid before displaying it.
            if (DBManager.score > 0)
            {
                scoreText.text = "Your Last Score: " + DBManager.score;
            }
            else
            {
                scoreText.text = "This is your first time in ENDOSIMULATE, no score for you saved yet";
            }
        }
    }
}
