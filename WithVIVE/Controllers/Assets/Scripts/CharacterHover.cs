using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CharacterHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private bool isHovered = false;
    private Quaternion startRotation;
    public float rotationSpeed = 30f;

    void Start()
    {
        // Store the initial rotation
        startRotation = transform.rotation;
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

    private void RotateCharacter()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Called when the mouse pointer enters the character
        isHovered = true;
        Debug.Log("Pointer entered");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Called when the mouse pointer exits the character
        isHovered = false;
        Debug.Log("Pointer exited");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Load the scene when the character is clicked
        Debug.Log("Character clicked");
        SceneManager.LoadScene(4); 
    }

}
