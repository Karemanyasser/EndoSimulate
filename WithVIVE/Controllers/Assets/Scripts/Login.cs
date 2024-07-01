using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections;

namespace Valve.VR.InteractionSystem.Sample
{
    public class Login : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public InputField UserIDField;
        public InputField passwordField;
        public Button loginButton;

        public GameObject errorPanel;
        public Text errorText;
        public GameObject keypad;

        private string currentInput = "";
        private bool isPasswordField = false;

        Color lightPurple = new Color(0.808f, 0.663f, 0.831f);
        Color purple = new Color(0.753f, 0.329f, 0.698f);

        private Image m_Image = null;

        private void Awake()
        {
            m_Image = GetComponent<Image>();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Debug.Log("Enter");
            m_Image.color = purple;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Debug.Log("Exit");

            m_Image.color = lightPurple;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("Click");

             if (VerifyInputs())
                {
                    StartCoroutine(UserLogin());
                }
        
        }

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
                    string errorMessage = "User login failed: ";
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
            errorPanel.SetActive(true);
            Debug.Log(message);
            errorText.text = message;
        }

        public bool VerifyInputs()
        {
            return !string.IsNullOrEmpty(UserIDField.text) && passwordField.text.Length >= 5;
        }

        public void OnUserIDFieldClick()
        {
            currentInput = UserIDField.text;
            isPasswordField = false;
            keypad.SetActive(true);
            errorPanel.SetActive(false);
        }

        public void OnPasswordFieldClick()
        {
            currentInput = passwordField.text;
            isPasswordField = true;
            keypad.SetActive(true);
            errorPanel.SetActive(false);
        }

       
    }
}
