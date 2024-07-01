using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Valve.VR.InteractionSystem.Sample
{
    public class Keypad : MonoBehaviour 
    {
        private string userInput = "";
        private string passwordInput = "";

        public InputField UserIDField;
        public InputField passwordField;

        private bool isPasswordField = false;

        public void OnKeypadButtonClick(string buttonValue)
        {
            if (buttonValue == "C")
            {
                isPasswordField = !isPasswordField;  // Toggle the flag
            }
            else if (buttonValue == "D")
            {
                if (isPasswordField)
                {
                    if (passwordInput.Length > 0)
                    {
                        passwordInput = passwordInput.Substring(0, passwordInput.Length - 1);  // Delete last input
                    }
                }
                else
                {
                    if (userInput.Length > 0)
                    {
                        userInput = userInput.Substring(0, userInput.Length - 1);  // Delete last input
                    }
                }
            }
            else
            {
                if (isPasswordField)
                {
                    passwordInput += buttonValue;
                }
                else
                {
                    userInput += buttonValue;
                }
            }
            
            UpdateInputField();
        }

        private void UpdateInputField()
        {
            if (isPasswordField)
            {
                passwordField.text = passwordInput;
            }
            else
            {
                UserIDField.text = userInput;
            }
        }
    }
}
