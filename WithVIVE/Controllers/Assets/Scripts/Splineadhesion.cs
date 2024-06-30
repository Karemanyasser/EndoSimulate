using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using Valve.VR;
public class Splineadhesion : MonoBehaviour
{// public SplineContainer spline;
    [SerializeField] SplineAnimate spline;
    
    public float speed = 0.3f;
    public Transform targetObject;
    public float collisionDistance = 2.5f;
    
    public Transform sphere; 
    
     public GameObject Patient1; // First patient object
    public GameObject Patient2; // Second patient object
    public GameObject Patient3; // Second patient object
    public GameObject Patient4; // Second patient object
    public GameObject Patient5; // Second patient object
    public GameObject Patient6; // Second patient object
    public GameObject Patient7; // Second patient object
    public GameObject Patient8;
    public GameObject Patient9;
    private Material originalMaterial1; // To store the original material of the first patient
    private Material originalMaterial2; // To store the original material of the second patient
    private Material originalMaterial3;
    private Material originalMaterial4;
    private Material originalMaterial5;
    private Material originalMaterial6;
    private Material originalMaterial7;
    private Material originalMaterial8;
    private Material originalMaterial9; 
    // public SteamVR_ActionSet m_ActionSet;
    public SteamVR_Action_Vector2 m_TouchPosition;

    bool isMoving = false;
  
    void Start()
    {
        if (Patient1 != null)
        {
            Renderer renderer1 = Patient1.GetComponent<Renderer>();
            if (renderer1 != null)
            {
                originalMaterial1 = renderer1.material;
            }
        }

        if (Patient2 != null)
        {
            Renderer renderer2 = Patient2.GetComponent<Renderer>();
            if (renderer2 != null)
            {
                originalMaterial2 = renderer2.material;
            }
        }
        if (Patient3 != null)
        {
            Renderer renderer3 = Patient3.GetComponent<Renderer>();
            if (renderer3 != null)
            {
                originalMaterial3 = renderer3.material;
            }
        }
        if (Patient4 != null)
        {
            Renderer renderer4 = Patient4.GetComponent<Renderer>();
            if (renderer4 != null)
            {
                originalMaterial4 = renderer4.material;
            }
        }
        if (Patient5 != null)
        {
            Renderer renderer5 = Patient5.GetComponent<Renderer>();
            if (renderer5 != null)
            {
                originalMaterial5 = renderer5.material;
            }
        }
        if (Patient6 != null)
        {
            Renderer renderer6 = Patient6.GetComponent<Renderer>();
            if (renderer6 != null)
            {
                originalMaterial6 = renderer6.material;
            }
        }
        if (Patient7 != null)
        {
            Renderer renderer7 = Patient7.GetComponent<Renderer>();
            if (renderer7 != null)
            {
                originalMaterial7 = renderer7.material;
            }
        }
        if (Patient8 != null)
        {
            Renderer renderer8 = Patient8.GetComponent<Renderer>();
            if (renderer8 != null)
            {
                originalMaterial8 = renderer8.material;
            }
        }
        if (Patient9 != null)
        {
            Renderer renderer9 = Patient9.GetComponent<Renderer>();
            if (renderer9 != null)
            {
                originalMaterial9 = renderer9.material;
            }
        }
        
    }

    
    // Update is called once per frame
    void Update()
    {
        Vector2 ScrollValue = m_TouchPosition.GetAxis(SteamVR_Input_Sources.Any); 
        Debug.Log("scrollvalue" + ScrollValue[1]);

        if (isMoving)
        {
        
            Debug.Log("TRUE!");


            spline.ElapsedTime=Mathf.Clamp(spline.ElapsedTime,0.0823722f,3.455514f);
           if(ScrollValue[1] > 0.00f && spline.ElapsedTime <3.455514f ){
            spline.ElapsedTime += speed * Time.deltaTime;
        }

        if( ScrollValue[1] <  0.00f && spline.ElapsedTime > 0.0823722f){
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
            MakeTransparent(Patient2);
            MakeTransparent(Patient3);
            MakeTransparent(Patient4);
            MakeTransparent(Patient5);
            MakeTransparent(Patient6);
            MakeTransparent(Patient7);
            MakeTransparent(Patient8);
            MakeTransparent(Patient9);

        }
    } void MakeTransparent(GameObject patient)
    {
        if (patient != null)
        {
            Renderer renderer = patient.GetComponent<Renderer>();
            if (renderer != null && renderer.material != null)
            {
                Color color = renderer.material.color;
                color.a = 0.3f; // 95% transparent
                renderer.material.color = color;
                renderer.material.SetFloat("_Mode", 3);
                renderer.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                renderer.material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                renderer.material.SetInt("_ZWrite", 0);
                renderer.material.DisableKeyword("_ALPHATEST_ON");
                renderer.material.EnableKeyword("_ALPHABLEND_ON");
                renderer.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                renderer.material.renderQueue = 3000;
            }
            else
            {
                Debug.LogWarning("Renderer or material not found on the patient object.");
            }
        }
    }
    }


