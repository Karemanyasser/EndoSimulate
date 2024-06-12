using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tryagain : MonoBehaviour
{

    public GameObject errorPanel;   // define levelerrorPanel. 
    private bool isHovered = false;

   void Update()
    {
        if (isHovered)
        {
            StartCoroutine(LoadSceneAfterDelay(5f));
        }
    }

    IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        errorPanel.SetActive(false);  //deactivate errorPanel.
        
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
