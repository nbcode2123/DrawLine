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
    public GameObject CompleteLevelCanvas;
    public GameObject Star1;
    public GameObject Star2;
    public GameObject Star3;
    public GameObject HintBtn;
    public GameObject EndCanvas;


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
        TurnOffCompleteLevelCanvas();
        TurnOffEndCanvas();


    }

    public void Play()
    {
        ObserverManager.Notify("PlayBtn");
        ObserverManager.Notify("PlayAudio", "ButtonSound");


    }
    public void BackToMenuInLevelMenu()
    {
        ObserverManager.Notify("BackToMenuLevel");
        ObserverManager.Notify("PlayAudio", "ButtonSound");


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
    public void TurnOnCompleteLevelCanvas()
    {
        CompleteLevelCanvas.SetActive(true);

    }
    public void TurnOffCompleteLevelCanvas()
    {
        CompleteLevelCanvas.SetActive(false);

    }
    public void BackToMenuInLevel()
    {
        SceneController.Instance.ChangeToMenuScene();
        ObserverManager.Notify("PlayAudio", "ButtonSound");

    }
    public void ResetLevel()
    {
        SceneController.Instance.ResetLevel();
        Star3.GetComponent<StarLevel>().OnSprite();

        Star2.GetComponent<StarLevel>().OnSprite();

        Star1.GetComponent<StarLevel>().OnSprite();
        TurnOnLevelCanvas();
        DrawLineController.Instance.isInLevel = true;
        DrawLineController.Instance.isFirstLine = false;
        DrawLineController.Instance.ClearLine();
        ObserverManager.Notify("PlayAudio", "ButtonSound");




    }
    public void UpdateLevelText(int level)
    {
        LevelText.text = $"LEVEL.{level}";

    }
    public void UpdateStarUI(int star)
    {
        if (star == 2)
        {
            Star3.GetComponent<StarLevel>().OffSprite();

        }
        else if (star == 1)
        {
            Star2.GetComponent<StarLevel>().OffSprite();

        }
        else if (star == 0)
        {
            Star1.GetComponent<StarLevel>().OffSprite();

        }

    }
    public void ResetCompleteCanvas()
    {
        CompleteLevelCanvas.GetComponent<CompleteCanvasStarEffect>().Reset();



    }
    public void PlayNextLevel()
    {
        SceneController.Instance.ChangeToNextLevel();
        LevelCanvas.SetActive(true);
        TurnOffCompleteLevelCanvas();
        // ObserverManager.Notify("PlayAudio", "ButtonSound");

    }
    public void TurnOnHint()
    {
        LevelManager.Instance.TurnOnHintLevel();
        ObserverManager.Notify("PlayAudio", "ButtonSound");

    }
    public void TurnOnEndCanvas()
    {
        EndCanvas.SetActive(true);

    }
    public void TurnOffEndCanvas()
    {
        EndCanvas.SetActive(false);

    }






}
