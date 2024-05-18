using UnityEngine;
using UnityEngine.UI;

public class Levels : MonoBehaviour 
{

    // define buttons
    public Button forwardButton; 
    public Button backwardButton; 
    public Button level1; 
    public Button level2; 
    public Button level3; 
    public Button level4; 

    public int currentLevel = 1;

    void Start()
    {
        forwardButton.onClick.AddListener(LevelUp);
        backwardButton.onClick.AddListener(LevelDown);
    }

    void LevelUp()
    {
        if (currentLevel < 4)
        {
            currentLevel++;
            ActivateCurrentLevelButton();
        }
    }

    void LevelDown()
    {
        if (currentLevel > 1)
        {
            currentLevel--;
            ActivateCurrentLevelButton();
        }
    }

    void ActivateCurrentLevelButton()
    {
        switch (currentLevel)
        {
            case 1:
                ActivateLevelButton(level1);
                ActivateLevelButton(forwardButton);
                DeactivateLevelButton(level2);
                DeactivateLevelButton(level3);
                DeactivateLevelButton(level4);
                DeactivateLevelButton(backwardButton);
                break;
            case 2:
                ActivateLevelButton(level2);
                ActivateLevelButton(forwardButton);
                ActivateLevelButton(backwardButton);
                DeactivateLevelButton(level1);
                DeactivateLevelButton(level3);
                DeactivateLevelButton(level4);
                break;
            case 3:
                ActivateLevelButton(level3);
                ActivateLevelButton(forwardButton);
                DeactivateLevelButton(level1);
                DeactivateLevelButton(level2);
                DeactivateLevelButton(level4);
                break;
            case 4:
                ActivateLevelButton(level4);
                DeactivateLevelButton(level1);
                DeactivateLevelButton(level2);
                DeactivateLevelButton(level3);
                DeactivateLevelButton(forwardButton);
                break;
        }
    }

    void ActivateLevelButton(Button button)
    {
        button.gameObject.SetActive(true);
    }

    void DeactivateLevelButton(Button button)
    {
        button.gameObject.SetActive (false);
    }


}


