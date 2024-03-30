using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CharacterHover : MonoBehaviour
{
    private bool isHovered = false; //This variable tracks whether the object is currently being hovered over with initial value equal false 
    private Quaternion startRotation; // This variable stores the initial rotation of the object
    public float rotationSpeed = 30f;// defines rotation speed with initial value = 30.0
    
    // Start is called before the first frame update

    void Start()
    {
        // Store the initial rotation
        startRotation = transform.rotation;
    }

    void Update() // Update is called once per frame
    {
        // Rotate the character when hovered over
    
        if (isHovered)
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);// Rotate the object around its up axis with a speed of rotationSpeed degrees per second
        }
        else
        {
            // Reset the rotation to the initial rotation
            transform.rotation = Quaternion.Lerp(transform.rotation, startRotation, Time.deltaTime * 5f);
        }
    }

    public void OnPointerEnter()
    {
        // Called when the mouse pointer enters the character
        isHovered = true;// Set isHovered to true to indicate that the object is now being hovered over
        
    }

    public void OnPointerExit()
    {
        // Called when the mouse pointer exits the character
        isHovered = false; // Set isHovered to false to indicate that the object is no longer being hovered over
        
    }

    public void OnPointerClick()
    {
        // Called when the object is clicked
        SceneManager.LoadScene("StartScene");  // Load start scene
    }
}
