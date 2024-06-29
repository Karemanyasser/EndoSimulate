using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Valve.VR.InteractionSystem.Sample
{
public class ButtonAction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler , IPointerUpHandler, IPointerDownHandler
{
    Color lightPurple = new Color(0.808f, 0.663f, 0.831f); 
    
    Color purple = new Color(0.753f, 0.329f, 0.698f);

    public int sceneIndex;

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
        SceneManager.LoadScene(sceneIndex);
    }

    public void OnPointerUp(PointerEventData eventData)              // Called when the hand pointer Ups the object
    {
        Debug.Log("Up");
    }

    public void OnPointerDown(PointerEventData eventData)              // Called when the hand pointer Downs the object
    {
        Debug.Log("Down");
    }
}
}