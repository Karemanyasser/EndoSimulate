using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


namespace Valve.VR.InteractionSystem.Sample
{
public class Forward : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler 
{
    // define buttons
    public Button levelup; 
    public Button leveldown; 
    public Button level1; 
    public Button level2; 
    public Button level3; 
    public Button level4; 

    public int currentLevel = 1;

    Color lightPurple = new Color(0.808f, 0.663f, 0.831f); 
    
    Color purple = new Color(0.753f, 0.329f, 0.698f);


    private Image m_Image = null;


    private void Awake()
    {
        m_Image = GetComponent<Image>();
    }


    public void OnPointerEnter(PointerEventData eventData)           // Called when the hand pointer enters the object
    {
        Debug.Log("Enter");
        m_Image.color = purple;
    }

    public void OnPointerExit(PointerEventData eventData)              // Called when the hand pointer exits the object
    {
        Debug.Log("Exit");
        m_Image.color = lightPurple;
    }

     public void OnPointerClick(PointerEventData eventData)              // Called when the hand pointer click on  the object
    {
        Debug.Log("Click");
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

}
}


