using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public InputField usernameField;
    public InputField passwordField;
    public Button loginButton;

    public GameObject panel;   // Define error panel. Use camelCase for variable names.
    public Text errorText;

    public void CallLogin()
    {
        StartCoroutine(UserLogin());
    }

    IEnumerator UserLogin()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", usernameField.text);
        form.AddField("password", passwordField.text);

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
                DBManager.username = responseParts[1];
                DBManager.firstname = responseParts[2];
                DBManager.lastname = responseParts[3];

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
                string errorMessage = "User login failed. Error: ";
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
        panel.SetActive(true);  // Activate panel.
        Debug.Log(message);     // Log error message to console.
        errorText.text = message;
    }

    public void VerifyInputs()
    {
        loginButton.interactable = !string.IsNullOrEmpty(usernameField.text) && (passwordField.text.Length >= 5);
    }
}
