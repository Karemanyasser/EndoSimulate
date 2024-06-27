using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

namespace Valve.VR.InteractionSystem.Sample
{
public class ButtonAction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler , IPointerUpHandler, IPointerDownHandler
{
    Color lightBlue = new Color(0.678f, 0.847f, 0.902f); // RGB values for light blue
    
   // public Color32 m_NormalColor = lightBlue;
    public Color32 m_HoverColor = Color.blue; 

    public int sceneIndex;

    private Image m_Image = null;

    private void Awake()
    {
        m_Image = GetComponent<Image>();
    }


    public void OnPointerEnter(PointerEventData eventData)           // Called when the hand pointer enters the object
    {
        Debug.Log("Enter");
        m_Image.color = m_HoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)              // Called when the hand pointer exits the object
    {
        Debug.Log("Exit");
        m_Image.color = lightBlue;
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