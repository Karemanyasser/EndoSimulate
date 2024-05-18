using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    [SerializeField]   InputAction Finput;
    // [SerializeField]  InputAction Binput;
    float l_value;
    // Vector2  B_value;
    public float forward => l_value;
    // public Vector2 horizontally => B_value;

     private void OnEnable() {
        Finput.Enable(); 
        // Binput.Enable();   
    }

    private void OnDisable() {
        Finput.Disable();
        // Binput.Disable();
    }
    private void Update() {
        l_value=Finput.ReadValue<Vector2>().y;
        // B_value=Binput.ReadValue<Vector2>().y;
        Debug.Log(l_value );
    }
}
