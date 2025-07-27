
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }
    public List<Level> ListLevel;
    public int BallCounter;
    public int BallCounterComplete;
    public Level CurrentLevel;
    public GameObject CurrentLevelObj;
    public int CurrentLevelIndex;
    public LevelUnlockSrciptableObj LevelUnlock;
    public Slider SliderStar;
    public int StarCurrentLevel;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {


    }

    public void RunLevel(int level)
    {
        ResetVariable();
        CurrentLevelIndex = level;
        ObserverManager.Notify("ChangeToLevelScene");
        Level _tempLevel = ListLevel.Find(x => x.Index == level);
        CurrentLevel = _tempLevel;
        CurrentLevelObj = Instantiate(_tempLevel.Prefab);
        DrawLineController.Instance.isInLevel = true;
        StarCurrentLevel = 0;
    }
    public void BallCounterIncrease()
    {
        BallCounter++;
        if (BallCounter == BallCounterComplete)
        {
            DrawLineController.Instance.isInLevel = false;
            BallCounter = 0;
            if (LevelUnlock.ListLevelUnlock.Contains(CurrentLevelIndex + 1) == false)
            {
                LevelUnlock.ListLevelUnlock.Add(CurrentLevelIndex + 1);

            }
            if (CurrentLevel.Star < StarCurrentLevel)
            {
                CurrentLevel.Star = StarCurrentLevel;
            }

            ObserverManager.Notify("Level Complete");
            Debug.Log("Game Complete");
        }
    }
    public void BackToMenu()
    {
        Destroy(CurrentLevelObj);

    }
    public void DecreaseSlideStarValue()
    {
        SliderStar.value -= 1;
        if (SliderStar.value >= 800)
        {
            StarCurrentLevel = 3;

        }
        else if (SliderStar.value < 800 && SliderStar.value >= 400)
        {
            StarCurrentLevel = 2;
            UIController.Instance.UpdateStarUI(2);
        }
        else if (SliderStar.value < 400 && SliderStar.value > 0)
        {
            StarCurrentLevel = 1;
            UIController.Instance.UpdateStarUI(1);


        }
        else if (SliderStar.value <= 0)
        {
            StarCurrentLevel = 0;
            UIController.Instance.UpdateStarUI(1);


        }

    }
    public void ResetLevel()
    {
        Destroy(CurrentLevelObj);
        Level _tempLevel = ListLevel.Find(x => x.Index == CurrentLevelIndex);
        CurrentLevelObj = Instantiate(_tempLevel.Prefab);
        SliderStar.value = SliderStar.maxValue;
        BallCounter = 0;
        UIController.Instance.ResetCompleteCanvas();




    }
    public void NextLevel()
    {
        Destroy(CurrentLevelObj);
        Level _tempLevel = ListLevel.Find(x => x.Index == CurrentLevelIndex + 1);
        CurrentLevelObj = Instantiate(_tempLevel.Prefab);
        CurrentLevelIndex = _tempLevel.Index;
        SliderStar.value = SliderStar.maxValue;
        BallCounter = 0;



    }
    public void ResetVariable()
    {
        Destroy(CurrentLevelObj);
        SliderStar.value = SliderStar.maxValue;
        BallCounter = 0;



    }
}
