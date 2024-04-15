using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonAction : MonoBehaviour
{

    public int sceneindex;
    private bool isHovered = false;

    void Update()
    {
        if (isHovered)
        {
            for(int i = 0; i < 5; i++);
            SceneManager.LoadScene(sceneindex);
        }
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
