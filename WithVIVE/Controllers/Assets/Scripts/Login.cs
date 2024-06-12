using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections;

public class Login : MonoBehaviour
{
    public InputField UserIDField;
    public InputField passwordField;
    public Button loginButton;

    public GameObject panel;
    public Text errorText;

    public GameObject keypad;

    private string currentInput = "";
    private bool isPasswordField = false;

    private void Start()
    {
        loginButton.onClick.AddListener(() => StartCoroutine(UserLogin()));
        VerifyInputs();
    }

    private IEnumerator UserLogin()
    {
        WWWForm form = new WWWForm();
        form.AddField("UserID", UserIDField.text);
        form.AddField("Password", passwordField.text);

        using (WWW www = new WWW("http://localhost/sqlconnect/login.php", form))
        {
            yield return www;

            if (!string.IsNullOrEmpty(www.error))
            {
                HandleError("Connection error: " + www.error);
                yield break;
            }

            string[] responseParts = www.text.Split('\t');

            if (responseParts.Length >= 5 && responseParts[0] == "0")
            {
                DBManager.UserID = responseParts[1];
                DBManager.FirstName = responseParts[2];
                DBManager.LastName = responseParts[3];

                if (int.TryParse(responseParts[4], out int score))
                {
                    DBManager.score = score;
                    SceneManager.LoadScene(2);
                }
                else
                {
                    Debug.Log("Failed to parse score.");
                    HandleError("Failed to parse score.");
                }
            }
            else
            {
                string errorMessage = "User login failed:  ";
                if (responseParts.Length > 0)
                {
                    errorMessage += responseParts[0];
                }
                else
                {
                    errorMessage += "Unknown";
                }
                HandleError(errorMessage);
            }
        }
    }

    void HandleError(string message)
    {
        keypad.SetActive(false);
        panel.SetActive(true);
        Debug.Log(message);
        errorText.text = message;
    }

    public void VerifyInputs()
    {
        loginButton.interactable = !string.IsNullOrEmpty(UserIDField.text) && (passwordField.text.Length >= 5);
    }

    public void OnUserIDFieldClick()
    {
        currentInput = UserIDField.text;
        isPasswordField = false;
        keypad.SetActive(true);
        panel.SetActive(false);
    }

    public void OnPasswordFieldClick()
    {
        currentInput = passwordField.text;
        isPasswordField = true;
        keypad.SetActive(true);
        panel.SetActive(false);
    }

    public void OnKeypadButtonClick(string buttonValue)
    {
    
        if (buttonValue == "C")
        {
            if (currentInput.Length > 0)
            {
                currentInput = "";  // Clear all input
            }
        }
        else if (buttonValue == "D")  
        {
            if (currentInput.Length > 0)
            {
                currentInput = currentInput.Substring(0, currentInput.Length - 1);   // Delete last input
            }
        }
        else
        {
            currentInput += buttonValue;
        }

        UpdateInputField();
        VerifyInputs();
    }

    private void UpdateInputField()
    {
        if (isPasswordField)
        {
            passwordField.text = currentInput;
        }
        else
        {
            UserIDField.text = currentInput;
        }
    }
}
