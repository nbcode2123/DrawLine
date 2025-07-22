using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController Instance { get; private set; }
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

    }
    public GameObject MenuCanvas;
    public GameObject PlayBtn;
    public GameObject QuitBtn;
    public void Play()
    {
        ObserverManager.Notify("PlayBtn");




    }
    public void BackToMenuInLevel()
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


}
