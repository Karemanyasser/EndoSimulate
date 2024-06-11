using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class CharacterHover : MonoBehaviour
{
    private bool isHovered = false;
    private Quaternion startRotation;
    public float rotationSpeed = 30f;

    void Start()
    {
        // Store the initial rotation
        startRotation = transform.rotation;

        // Register XR interaction events
        var interactable = GetComponent<XRGrabInteractable>();
        if (interactable != null)
        {
            interactable.hoverEntered.AddListener(OnHoverEntered);
            interactable.hoverExited.AddListener(OnHoverExited);
            interactable.selectEntered.AddListener(OnSelectEntered);
        }
    }

    void Update()
    {
        // Rotate the character when hovered over
        if (isHovered)
        {
            RotateCharacter();
        }
        else
        {
            // Reset the rotation to the initial rotation
            transform.rotation = Quaternion.Lerp(transform.rotation, startRotation, Time.deltaTime * 5f);
        }
    }

   public void RotateCharacter()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    public void OnHoverEntered(HoverEnterEventArgs args)
    {
        // Called when the XR controller hovers over the character
        isHovered = true;
        Debug.Log("Hover entered");
    }

    public void OnHoverExited(HoverExitEventArgs args)
    {
        // Called when the XR controller stops hovering over the character
        isHovered = false;
        Debug.Log("Hover exited");
    }

     public void OnSelectEntered(SelectEnterEventArgs args)
    {
        // Load the scene when the character is selected (clicked)
        Debug.Log("Character selected");
        SceneManager.LoadScene(4);
    }
}