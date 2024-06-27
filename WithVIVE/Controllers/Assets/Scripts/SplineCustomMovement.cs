using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using Valve.VR;

public class SplineCustomMovement : MonoBehaviour
{
    // public SplineContainer spline;
    [SerializeField] SplineAnimate spline;
    [SerializeField] InputReader inputreader;
    public float speed = 0.3f;
    public Transform targetObject;
    public float collisionDistance = 2.5f;
    public GameObject infoPanel; // Reference to the info panel
    public Transform sphere; 
    public static bool  showpanel = false;
    public GameObject Patient;
    // public SteamVR_ActionSet m_ActionSet;
    public SteamVR_Action_Vector2 m_TouchPosition;

    bool isMoving = false;
  
    // private void Start(){
    //     m_ActionSet.Activate (SteamVR_Input_Sources. Any, 0, true);
    // }

    
    // Update is called once per frame
    void Update()
    {
        Vector2 ScrollValue = m_TouchPosition.GetAxis(SteamVR_Input_Sources.Any); 
        Debug.Log("scrollvalue" + ScrollValue[1]);

        if (isMoving)
        {
        
            Debug.Log("TRUE!");


            spline.ElapsedTime=Mathf.Clamp(spline.ElapsedTime,0.03838043f,4.191996f);
           if(ScrollValue[1] > 0.00f && spline.ElapsedTime <4.191996f ){
            spline.ElapsedTime += speed * Time.deltaTime;
        }

        if( ScrollValue[1] <  0.00f && spline.ElapsedTime > 0.03838043f){
            spline.ElapsedTime -= speed * Time.deltaTime;
        }
        // Check if ElapsedTime equals 0.23600f and show the panel
            if (spline.ElapsedTime>3.739959f)
            {
                ShowPanel();
            }
            
            Renderer renderer = Patient.GetComponent<Renderer>();
            // Check if the renderer and its material are not null
            if (renderer != null && renderer.material != null)
            {
                // Get the current color of the material
                Color color = renderer.material.color;

                // Set the alpha value to 0 (transparent)
                color.a = 0.4f;

                // Apply the new color to the material
                renderer.material.color = color;}
        }else{
            CheckCollision();
        }
      
    }

    void CheckCollision()
    {
        if (Vector3.Distance(sphere.position, targetObject.position) <= collisionDistance)
        {
            isMoving = true;
            Debug.Log("Collision Detected!");

            // Perform any additional actions when collision occurs
            // You can add code here to trigger any desired behavior
        }
    }
    void ShowPanel()
    {
        if (infoPanel != null)
        {
            infoPanel.SetActive(true);  // Activate panel
            showpanel = true; 
            Debug.Log("Panel shown due to spline.ElapsedTime reaching 0.23600f.");
        }
        else
        {
            Debug.LogWarning("Info panel is not assigned.");
        }
    }}





