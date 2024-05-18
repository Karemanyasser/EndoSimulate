using UnityEngine;

public class EndoscopeShader : MonoBehaviour
{
    [SerializeField] Material Highlighted;
    private bool isHovered = false;

    void Start()
    {
        Highlighted.SetFloat("_Factor", 0);
    }

  
    // Called when the hand pointer enters the object
    public void OnPointerEnter()
    {
        isHovered = true;
    }

    // Called when the hand pointer exits the object
    public void OnPointerExit()
    {
        isHovered = false;
    }

    // Method to highlight the endoscope
    public void HighlightEndoscope()
    {
        // Implement highlighting logic here if needed
        Highlighted.SetFloat("_Factor", 0.003f);
    }

    // Method to reset the endoscope shader
    public void ResetEndoscope()
    {
        Highlighted.SetFloat("_Factor", 0);
        // Implement resetting shader logic here if needed
    }
}
