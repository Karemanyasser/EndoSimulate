using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseCase : MonoBehaviour
{
    public AudioSource audioSource; // Audio source component.
    public AudioClip caseAudio; // Audio clip to play when time finishes.

    public Button Show; 
    public GameObject case1;
    public GameObject case2;
    public GameObject case3;

    // Start is called before the first frame update
    void Start()
    {
     Show.onClick.AddListener(SHOW);   
    }

    void SHOW()
    {
        case1.SetActive(true);  //activate panel.
        case2.SetActive(false); //
        case3.SetActive(false); 
        audioSource.PlayOneShot(caseAudio); 

    }
}