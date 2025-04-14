using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class CombinationLock : MonoBehaviour
{
    [SerializeField] TMP_Text userInputText;
    [SerializeField] TMP_Text lockText;

    [SerializeField] XrButtonInteractable[] comboButtons;
    [SerializeField] Image lockedPanel;

    public bool isLocked;
    [SerializeField] string passcode = "134";

    private void Onbuttonpress() => buttonPressedAudioAction?.Invoke(this);
    private void OnUnlocked() => unlockedAudioAction?.Invoke(this);
    private void OnLocked() => lockedAudioAction?.Invoke(this);


    public UnityAction<CombinationLock> buttonPressedAudioAction;
    public UnityAction<CombinationLock> unlockedAudioAction;
    public UnityAction<CombinationLock> lockedAudioAction;

    public AudioClip GetComboLockButtonPressedClip => ComboLockButtonPressedClip;
    [SerializeField] AudioClip ComboLockButtonPressedClip;
    public AudioClip GetComboLockLockedClip => ComboLockLockedClip;
    [SerializeField] AudioClip ComboLockLockedClip;
    public AudioClip GetComboLockUnlockedClip => ComboLockUnlockedClip;
    [SerializeField] AudioClip ComboLockUnlockedClip;

    // Start is called before the first frame update
    void Start()
    {
        ResetUserInput();

        for (int i = 0; i < comboButtons.Length; i++)
        {
            comboButtons[i].selectEntered.AddListener(OnComboButtonPressed);
        }
        UpdateLock();
    }

    private void OnComboButtonPressed(SelectEnterEventArgs arg0)
    {
        Onbuttonpress();
        for (int i = 0; i < comboButtons.Length; i++) //Detect which button was pressed
        {
            if (arg0.interactableObject.transform.name == comboButtons[i].transform.name)
            {
                userInputText.text += i.ToString();
            }
            else
            {
                comboButtons[i].ResetColor();
            }
        }

        if (userInputText.text.Length > passcode.Length)
        {
            ResetUserInput();
            OnLocked();
        }

        if (userInputText.text == passcode)
        {
            isLocked = false;
            OnUnlocked();
        }
        else
        {
            isLocked = true;
        }
        UpdateLock();
    }

    private void UpdateLock()
    {
        if (isLocked)
        {
            lockText.text = "Locked";
            lockedPanel.color = Color.red;
        }
        else
        {
            lockText.text = "Unlocked";
            lockedPanel.color = Color.green;
        }
    }

    private void ResetUserInput()
    {
        userInputText.text = "";
    }
}
