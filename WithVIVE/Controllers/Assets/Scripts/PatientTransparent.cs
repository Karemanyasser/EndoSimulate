using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientTransparent : MonoBehaviour
{
    
     private void OnCollisionEnter(Collision collision)
    {
        // Get the Renderer component of the game object
        Debug.Log("Entering Patient");
            Renderer renderer = GetComponent<Renderer>();

            // Check if the renderer and its material are not null
            if (renderer != null && renderer.material != null)
            {
                // Get the current color of the material
                Color color = renderer.material.color;

                // Set the alpha value to 0 (transparent)
                color.a = 0.4f;

                // Apply the new color to the material
                renderer.material.color = color;
            }
        // if (collision.gameObject.tag == "Hystroscope"){
            

        // }
    }
    //    private void OnCollisionEnter(Collision collision){
    //    this.gameObject.SetActive(false);
    // }
}
