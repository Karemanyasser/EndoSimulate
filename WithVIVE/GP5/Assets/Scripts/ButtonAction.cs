using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonAction : MonoBehaviour
{
    public int sceneIndex;
    private bool isHovered = false;

    void Update()
    {
        if (isHovered)
        {
            StartCoroutine(LoadSceneAfterDelay(5f, sceneIndex));
        }
    }

    IEnumerator LoadSceneAfterDelay(float delay, int sceneIndex)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneIndex);
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
