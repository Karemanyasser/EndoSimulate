using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    
   public GameObject[] cases; // Assign spheres in the inspector
    public Button[] buttons; // Assign buttons in the inspector

    private GameObject activeCase;
    private string activeTag;

    public TextMeshProUGUI Textanswer; // Text component to display the answer

    void Start()
    {
        HideAllCases();
        ShowRandomCase();
        // SetButtonTags();
    }

    void HideAllCases()
    {
        foreach (GameObject case1 in cases)
        {
            case1.SetActive(false);
        }
    }

    void ShowRandomCase()
    {
        int randomIndex = Random.Range(0, cases.Length);
        activeCase = cases[randomIndex];
        activeCase.SetActive(true);
        activeTag = activeCase.tag;
    }

    void SetButtonTags()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            string tag = cases[i].tag;
            buttons[i].GetComponentInChildren<Text>().text = tag;
            buttons[i].onClick.RemoveAllListeners();
            buttons[i].onClick.AddListener(() => OnButtonClicked(tag));
        }
    }

    void OnButtonClicked(string tag)
    {
        Debug.Log("OnButtonClicked");
        if (tag == activeTag)
        {

            Debug.Log("Correct answer!");
            Textanswer.text = "Correct answer!"; // Correct way to set the text
            Textanswer.color = Color.green; // Set the text color to green
            // Handle correct selection
        }
        else
        {
            Debug.Log("Incorrect answer ");
            Textanswer.text = "Incorrect answer!"; // Correct way to set the text
            Textanswer.color = Color.red; // Set the text color to red
            // Handle incorrect selection
        }

        // Optionally, reset the game
        HideAllCases();
        ShowRandomCase();
        SetButtonTags();
    }
}
