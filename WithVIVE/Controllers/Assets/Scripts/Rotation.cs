using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField]
    float eulerAngX;
    [SerializeField]
    float eulerAngY;
    [SerializeField]
    float eulerAngZ;
    public TextMeshProUGUI Text555; // Text component to display the message
    bool flag = false;

    void Update()
    {
        eulerAngX = NormalizeAngle(transform.localEulerAngles.x);
        eulerAngY = NormalizeAngle(transform.localEulerAngles.y);
        eulerAngZ = NormalizeAngle(transform.localEulerAngles.z);

        print($"Euler Angles - X: {eulerAngX}, Y: {eulerAngY}, Z: {eulerAngZ}");

        if ((eulerAngX >= 5 && eulerAngX <= 7) || (eulerAngY >= 115 && eulerAngY<=125))
        {
            Text555.text = "Correct position"; // Correct way to set the text
            print(Text555.text);
        }
        else if (!((eulerAngX >= 5 && eulerAngX <= 7) || (eulerAngY >= 115 && eulerAngY<=125)))
        {
            Text555.text = " Wrong Postion"; // Clear the text if not in the right position
        }
        else{
            Text555.text = ""; // Clear the text if not in the right position
        }
        
    }

    float NormalizeAngle(float angle)
    {
        // Normalize the angle to be within 0 to 360 degrees
        angle = angle % 360;
        if (angle < 0)
        {
            angle += 360;
        }
        return angle;
    }

}
