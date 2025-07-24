using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController Instance { get; private set; }

    public GameObject MenuCanvas;
    public GameObject PlayBtn;
    public GameObject QuitBtn;
    public GameObject LevelCanvas;
    public TextMeshProUGUI LevelText;
    private void Awake()
    {
        if (Instance != this && Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        ObserverManager.AddListener("ChangeToLevelScene", TurnOffMenuCanvas);
        ObserverManager.AddListener("ChangeToLevelScene", TurnOnLevelCanvas);
        TurnOffLevelCanvas();


    }
    public void Play()
    {
        ObserverManager.Notify("PlayBtn");
    }
    public void BackToMenuInLevelMenu()
    {
        ObserverManager.Notify("BackToMenuLevel");
    }
    public void TurnOffMenuCanvas()
    {

        MenuCanvas.SetActive(false);
    }
    public void TurnOnMenuCanvas()
    {
        MenuCanvas.SetActive(true);
    }
    public void TurnOnLevelCanvas()
    {
        LevelCanvas.SetActive(true);

    }
    public void TurnOffLevelCanvas()
    {
        LevelCanvas.SetActive(false);

    }
    public void BackToMenuInLevel()
    {
        SceneController.Instance.ChangeToMenuScene();
    }
    public void ResetLevel()
    {
        SceneController.Instance.ResetLevel();
    }
    public void UpdateLevelText(int level)
    {
        LevelText.text = $"LEVEL.{level}";

    }


}
