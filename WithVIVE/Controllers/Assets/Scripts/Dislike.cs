using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Valve.VR.InteractionSystem.Sample
{
public class Dislike : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    Color lightRed = new Color(1.0f, 0.6f, 0.6f); 
    
    Color Red = new Color(1.0f, 0.0f, 0.0f);

    public GameObject Panel;   // define panel. 

    private Image m_Image = null;

    private void Awake()
    {
        m_Image = GetComponent<Image>();
    }


    public void OnPointerEnter(PointerEventData eventData)           // Called when the hand pointer enters the object
    {
        Debug.Log("Enter");
        m_Image.color = Red;
    }

    public void OnPointerExit(PointerEventData eventData)              // Called when the hand pointer exits the object
    {
        Debug.Log("Exit");
        m_Image.color = lightRed;
    }

     public void OnPointerClick(PointerEventData eventData)              // Called when the hand pointer click on  the object
    {
        Debug.Log("Click");
        Panel.SetActive(false);
    }

    
}
}