using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Levels : MonoBehaviour
{
    public Button levelup; // define button. 
    public Button leveldown; 
    public Button level1; 
    public Button level2; 
    public Button level3; 
    public Button level4; 

    public int currentLevel = 1;

    // Start is called before the first frame update
    void Start()
    {
        // Attach functions to button clicks
        levelup.onClick.AddListener(LevelUp);
        leveldown.onClick.AddListener(LevelDown);
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
        button.gameObject.SetActive(true);
    }

    void DeactivateLevelButton(Button button)
    {
        button.gameObject.SetActive (false);
    }
}
