using UnityEngine;

public class ControlShader : MonoBehaviour
{
    [SerializeField] Material Highlighted;
    [SerializeField] GameObject endoscopeObject; // Reference to the endoscope object
    private bool isHovered = false;

    private EndoscopeShader endoscopeShader; // Reference to the EndoscopeShader script attached to the endoscope

    void Start()
    {
        Highlighted.SetFloat("_Factor", 0.003f);
        endoscopeShader = endoscopeObject.GetComponent<EndoscopeShader>(); // Get the EndoscopeShader component
    }

    void Update()
    {
        if (isHovered)
        {
            Highlighted.SetFloat("_Factor", 0);
            endoscopeShader.HighlightEndoscope(); // Call the HighlightEndoscope method
        }
        else
        {
            Highlighted.SetFloat("_Factor", 0.003f);
            endoscopeShader.ResetEndoscope(); // Call the ResetEndoscope method
        }
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
}
