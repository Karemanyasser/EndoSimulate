using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
public class SplineCustomMovement : MonoBehaviour
{
    // public SplineContainer spline;
    [SerializeField] SplineAnimate spline;
    [SerializeField] InputReader inputreader;
    public float speed = 1f;
    public Transform targetObject;
    public float collisionDistance = 2.5f;
    public GameObject infoPanel; // Reference to the info panel
    public Transform sphere; 
    public static bool  showpanel = false;
   
    bool isMoving = false;

    
    // Update is called once per frame
    void Update()
    {
       
        if (isMoving)
        {
        
            Debug.Log("TRUE!");


            spline.ElapsedTime=Mathf.Clamp(spline.ElapsedTime,0.0009808332f, 0.04081119f);
           if(inputreader.forward > 0.008f && spline.ElapsedTime < 0.04081119f ){
            spline.ElapsedTime += speed * Time.deltaTime;
        }

        if( inputreader.forward <  -0.008f && spline.ElapsedTime > 0.0009808332f){
            spline.ElapsedTime -= speed * Time.deltaTime;
        }
        // Check if ElapsedTime equals 0.23600f and show the panel
            if (spline.ElapsedTime>0.03957449f)
            {
                ShowPanel();
            }
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

