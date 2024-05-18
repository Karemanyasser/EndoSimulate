using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ControlShader : MonoBehaviour
{
    [SerializeField] Material Highlighted;
    private bool isHovered = false;

   
    void Start()
    {
        Highlighted.SetFloat("_Factor",0);
    }

    void Update() 
    {
            
        if (isHovered)
        {
            Highlighted.SetFloat("_Factor",0.03f);
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