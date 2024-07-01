using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

namespace Valve.VR.InteractionSystem.Sample
{
    public class CharacterHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler 
    {
        private Quaternion startRotation;
        public float rotationSpeed = 30f;
        private bool isRotating = false; // Flag to indicate if rotation should occur

        public int sceneIndex;

        void Start()
        {
            // Store the initial rotation
            startRotation = transform.rotation;
        }

        void Update()
        {
            // Rotate the character if the flag is set
            if (isRotating)
            {
                RotateCharacter();
            }
        }

        public void RotateCharacter()
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }

        public void OnPointerEnter(PointerEventData eventData)           // Called when the hand pointer enters the object
        {
            Debug.Log("Enter");
            isRotating = true; // Start rotating
        }

        public void OnPointerExit(PointerEventData eventData)              // Called when the hand pointer exits the object
        {
            Debug.Log("Exit");
            isRotating = false; // Stop rotating
        }

        public void OnPointerClick(PointerEventData eventData)              // Called when the hand pointer click on the object
        {
            Debug.Log("Click");
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
