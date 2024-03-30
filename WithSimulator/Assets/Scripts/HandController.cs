using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandController : MonoBehaviour
{
    [SerializeField] private InputActionProperty triggerAction; //The input action property for triggering an action.
    [SerializeField] private InputActionProperty gripAction; // The input action property for gripping an object.
    private Animator anim; // The Animator component for controlling animations.
    private void Start(){ // Start is called before the first frame update
        anim= GetComponent<Animator>(); // Assigns the Animator component to the anim field.
    }
 

    // Update is called once per frame
    void Update()
    {
       float triggerValue = triggerAction.action.ReadValue<float>(); // Reads the value of the trigger action and assigns it to triggerValue.
       float gripValue = gripAction.action.ReadValue<float>(); // Reads the value of the grip action and assigns it to gripValue.

       anim.SetFloat("Trigger", triggerValue); // Sets the "Trigger" parameter of the Animator to the triggerValue.
       anim.SetFloat("Grip", gripValue); // Sets the "Grip" parameter of the Animator to the gripValue.

    }
}
