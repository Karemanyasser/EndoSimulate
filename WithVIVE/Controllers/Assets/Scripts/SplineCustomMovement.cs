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
    public Transform sphere; 

    // float distancePercentage = 0f;
    // // float splineLength;
    bool isMoving = false;

    // private void Start()
    // {
    //     splineLength = spline.CalculateLength();
    // }

    // Update is called once per frame
    void Update()
    {
       
        if (isMoving)
        {
        //     // distancePercentage += speed * Time.deltaTime / splineLength;

            // Vector3 currentPosition = spline.EvaluatePosition(distancePercentage);
            // hysteroscopeCamera.transform.position = currentPosition;

            // if (distancePercentage > 1f)
            // {
            //     distancePercentage = 0f;
            // }

            // Vector3 nextPosition = spline.EvaluatePosition(distancePercentage + 0.05f);
            // Vector3 direction = nextPosition - currentPosition;
            // hysteroscopeCamera.transform.rotation = Quaternion.LookRotation(direction, transform.up);
            Debug.Log("TRUE!");


            Mathf.Clamp(spline.ElapsedTime,0.0009808332f, 0.04081119f);
           if(inputreader.forward > 0.008f && spline.ElapsedTime < 0.04081119f ){
            spline.ElapsedTime += speed * Time.deltaTime;
        }

        if( inputreader.forward <  -0.008f && spline.ElapsedTime > 0.0009808332f){
            spline.ElapsedTime -= speed * Time.deltaTime;
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
    }}

