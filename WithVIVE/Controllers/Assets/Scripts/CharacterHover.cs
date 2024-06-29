using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

namespace Valve.VR.InteractionSystem.Sample
{
public class CharacterHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler , IPointerUpHandler, IPointerDownHandler
{
    private Quaternion startRotation;
    public float rotationSpeed = 30f;

     public int sceneIndex;

    void Start()
    {
        // Store the initial rotation
        startRotation = transform.rotation;
    }


   public void RotateCharacter()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    public void OnPointerEnter(PointerEventData eventData)           // Called when the hand pointer enters the object
    {
        Debug.Log("Enter");
        RotateCharacter();
    }

    public void OnPointerExit(PointerEventData eventData)              // Called when the hand pointer exits the object
    {
        Debug.Log("Exit");
    }

     public void OnPointerClick(PointerEventData eventData)              // Called when the hand pointer click on  the object
    {
        Debug.Log("Click");
        SceneManager.LoadScene(sceneIndex);
    }

    public void OnPointerUp(PointerEventData eventData)              // Called when the hand pointer Ups the object
    {
        Debug.Log("Up");
    }

    public void OnPointerDown(PointerEventData eventData)              // Called when the hand pointer Downs the object
    {
        Debug.Log("Down");
    }

}
}