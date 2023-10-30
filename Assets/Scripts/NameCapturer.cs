using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NameCapturer :MonoBehaviour
{
    public TMP_InputField nameInput;
    public Button playButton;
   public void CaptureName()
    {
        ScoreManager.Instance.CurrentScore.PlayerName = nameInput.text;
        playButton.interactable = true;
    }
}
