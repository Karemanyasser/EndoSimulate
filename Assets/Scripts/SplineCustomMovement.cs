using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class SplineCustomMovement : MonoBehaviour
{
    [SerializeField] SplineAnimate spline;
    [SerializeField] InputReader inputreader;
    [SerializeField] float speed=1f;

    // Update is called once per frame
    void Update()
    {
        Mathf.Clamp(spline.ElapsedTime, 0.001905352f,0.2681102f);
        if(inputreader.forward > 0.8f && spline.ElapsedTime < 0.2681102f ){
            spline.ElapsedTime += speed * Time.deltaTime;
        }

        if(inputreader.forward <  -0.8f && spline.ElapsedTime > 0.001905352f){
            spline.ElapsedTime -= speed * Time.deltaTime;
        }
    }
}
