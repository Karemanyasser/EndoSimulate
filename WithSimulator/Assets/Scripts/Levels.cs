using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Levels : MonoBehaviour
{
    public Button levelup; // define button. 
    public Button leveldown; // define leveldown button.
    public Button level1; // define level1 button.
    public Button level2; // define level2 button.
    public Button level3; // define level3 button.
    public Button level4; // define level4 button.

    public int currentLevel = 1; // This variable stores the current level of the game, starting from level 1

    // Start is called before the first frame update
    void Start()
    {
        // Attach functions to button clicks
        levelup.onClick.AddListener(LevelUp);
        leveldown.onClick.AddListener(LevelDown);
    }

    void LevelUp()
    {
        // Increases the current level by 1 and activates the button for the new level if the current level is less than 4
        if (currentLevel < 4)
        {
            currentLevel++;//Increases the current level by 1
            ActivateCurrentLevelButton();//Activates the button for the new level
        }
    }

    void LevelDown()
    {
        // decreases the current level by 1 and activates the button for the new level if the current level is more than 1
        if (currentLevel > 1)
        {
            currentLevel--;//decreases the current level by 1
            ActivateCurrentLevelButton();//Activates the button for the new level
        }
    }

    void ActivateCurrentLevelButton()
    {
        // Activates the button for the current level and adjusts the visibility of other level buttons
        switch (currentLevel)
        {
            case 1:
                ActivateLevelButton(level1);
                ActivateLevelButton(levelup);
                DeactivateLevelButton(level2);
                DeactivateLevelButton(level3);
                DeactivateLevelButton(level4);
                DeactivateLevelButton(leveldown);
                break;
            case 2:
                ActivateLevelButton(level2);
                ActivateLevelButton(levelup);
                ActivateLevelButton(leveldown);
                DeactivateLevelButton(level1);
                DeactivateLevelButton(level3);
                DeactivateLevelButton(level4);
                break;
            case 3:
                ActivateLevelButton(level3);
                ActivateLevelButton(levelup);
                DeactivateLevelButton(level1);
                DeactivateLevelButton(level2);
                DeactivateLevelButton(level4);
                break;
            case 4:
                ActivateLevelButton(level4);
                DeactivateLevelButton(level1);
                DeactivateLevelButton(level2);
                DeactivateLevelButton(level3);
                DeactivateLevelButton(levelup);
                break;
        }
    }

    void ActivateLevelButton(Button button)
    {
        button.gameObject.SetActive(true); // Set the game object associated with the button to active, making it visible and interactable
    }

    void DeactivateLevelButton(Button button)
    {
        button.gameObject.SetActive (false);// Set the game object associated with the button to inactive, making it invisible and non-interactable
    }
}
