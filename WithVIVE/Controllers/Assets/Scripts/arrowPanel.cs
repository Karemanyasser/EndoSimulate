using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Valve.VR.InteractionSystem.Sample
{
public class arrowPanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler , IPointerUpHandler, IPointerDownHandler
{
    Color blue = new Color(0.0f, 0.0f, 1.0f); // Blue color 
    
    Color lightBlue = new Color(0.678f, 0.847f, 0.902f);
    Color green= new Color(0.0f, 1.0f, 0.0f);

    public GameObject Panel;   // define panel. 
    public GameObject hidearrow;
    public Image targetImage; // Image component whose color will be changed



    private Image m_Image = null;

    private void Awake()
    {
        m_Image = GetComponent<Image>();
    }


    public void OnPointerEnter(PointerEventData eventData)           // Called when the hand pointer enters the object
    {
        Debug.Log("Enter");
        m_Image.color = lightBlue; 
    }

    public void OnPointerExit(PointerEventData eventData)              // Called when the hand pointer exits the object
    {
        Debug.Log("Exit");
        m_Image.color = blue;
    }

     public void OnPointerClick(PointerEventData eventData)              // Called when the hand pointer click on  the object
    {
        Debug.Log("Click");
        Panel.SetActive(true);
        hidearrow.SetActive(false); //
        ChangeColor();

    }

    public void OnPointerUp(PointerEventData eventData)              // Called when the hand pointer Ups the object
    {
        Debug.Log("Up");
    }

    public void OnPointerDown(PointerEventData eventData)              // Called when the hand pointer Downs the object
    {
        Debug.Log("Down");
    }
    public void ChangeColor()
    {
        if (targetImage != null)
        {
            targetImage.color = green;
        }
        else
        {
            Debug.LogWarning("Target image is not set.");
        }
    }
}
}