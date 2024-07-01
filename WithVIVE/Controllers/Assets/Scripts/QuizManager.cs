using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    
   public GameObject[] cases; // Assign spheres in the inspector
    public Button[] buttons; // Assign buttons in the inspector

    private GameObject activeCase;
    private string activeTag;

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
            // Handle correct selection
        }
        else
        {
            Debug.Log("Incorrect answer ");
            // Handle incorrect selection
        }

        // Optionally, reset the game
        HideAllCases();
        ShowRandomCase();
        SetButtonTags();
    }
}
