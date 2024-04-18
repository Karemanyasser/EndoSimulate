using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CharacterHover : MonoBehaviour
{
    private bool isHovered = false;
    private Quaternion startRotation;
    public float rotationSpeed = 30f;
    // public int sceneindex;


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
            
            for(int i = 0; i < 15; i++){
                transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
            }
            
            SceneManager.LoadScene("StartScene");
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
        isHovered = true;
        
    }

    public void OnPointerExit()
    {
        // Called when the mouse pointer exits the character
        isHovered = false;
        
    }

    // public void OnPointerClick()
    // {
    //     // Called when the object is clicked
    //     SceneManager.LoadScene("StartScene"); 
    // }
}
