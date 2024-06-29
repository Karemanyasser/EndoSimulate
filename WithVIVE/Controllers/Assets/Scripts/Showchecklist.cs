using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Valve.VR.InteractionSystem.Sample
{
public class Showchecklist : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler , IPointerUpHandler, IPointerDownHandler

{
    Color blue = new Color(0.0f, 0.0f, 1.0f); // Blue color 
    
    Color lightBlue = new Color(0.678f, 0.847f, 0.902f);
    public Button Show; // define button. 
    public GameObject infoPanel;
    public GameObject hidearrow;
    public GameObject showarrow1;
    public GameObject showarrow2;
    public GameObject showarrow3;

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
        SHOW();
        SHOWarrow();
    }

    public void OnPointerUp(PointerEventData eventData)              // Called when the hand pointer Ups the object
    {
        Debug.Log("Up");
    }
    public void OnPointerDown(PointerEventData eventData)              // Called when the hand pointer Downs the object
    {
        Debug.Log("Down");
    }

    

     void SHOW()
    {
        
        infoPanel.SetActive(true);  //activate panel.
        hidearrow.SetActive(false); //
        

    }
    void SHOWarrow()
    {
        showarrow1.SetActive(true);
        showarrow2.SetActive(true); //
        showarrow3.SetActive(true);
        //
        

    }

    
}}
