using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

public class SimpleUIControl : MonoBehaviour
{
    [SerializeField] XrButtonInteractable startButton;

    [SerializeField] string[] msgStrings;

    [SerializeField] TMP_Text[] msgTexts;

    [SerializeField] GameObject KeyIndicatorLight;

    // Start is called before the first frame update
    void Start()
    {
        if (startButton != null)
        {
            startButton.selectEntered.AddListener(StartButtonPressed);
        }
    }

    private void StartButtonPressed(SelectEnterEventArgs arg0)
    {
        SetText(msgStrings[1]);
        if (KeyIndicatorLight != null)
        {
            KeyIndicatorLight.SetActive(true);
        }
    }

    // Update is called once per frame
    public void SetText(string msg)
    {
        for (int i = 0; i < msgTexts.Length; i++)
        {
            msgTexts[i].text = msg;
        }
        
    }
}
