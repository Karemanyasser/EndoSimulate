using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;



public class Forward : MonoBehaviour 
{
    private bool isHovered = false;
 
    // define buttons
    public Button levelup; 
    public Button leveldown; 
    public Button level1; 
    public Button level2; 
    public Button level3; 
    public Button level4; 

    public int currentLevel = 1;

    void Update()
    {
        if (isHovered)
        {
            StartCoroutine(WaitAndLevelUp(5f));
        }
    }

    IEnumerator WaitAndLevelUp(float delay)
    {
        yield return new WaitForSeconds(delay);
        LevelUp();
    }

    void LevelUp()
    {
        if (currentLevel < 4)
        {
            currentLevel++;
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

    public void OnPointerEnter()           // Called when the hand pointer enters the object
    {
        isHovered = true;
    }

    public void OnPointerExit()              // Called when the hand pointer exits the object
    {
        isHovered = false;
    }


}


