
using System;
using System.Collections.Generic;
using UnityEngine;

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
        CurrentLevelIndex = level;
        ObserverManager.Notify("ChangeToLevelScene");
        Level _tempLevel = ListLevel.Find(x => x.Index == level);
        CurrentLevelObj = Instantiate(_tempLevel.Prefab);
        DrawLineController.Instance.isInLevel = true;
    }
    public void BallCounterIncrease()
    {
        BallCounter++;
        if (BallCounter == BallCounterComplete)
        {
            DrawLineController.Instance.isInLevel = false;
            BallCounter = 0;
            LevelUnlock.ListLevelUnlock.Add(CurrentLevelIndex++);

            ObserverManager.Notify("Level Complete");

            Debug.Log("Game Complete");
        }
    }
    public void BackToMenu()
    {
        Destroy(CurrentLevelObj);

    }
    public void ResetLevel()
    {
        Destroy(CurrentLevelObj);
        Level _tempLevel = ListLevel.Find(x => x.Index == CurrentLevelIndex);
        CurrentLevelObj = Instantiate(_tempLevel.Prefab);



    }
}
[Serializable]
public class Level
{
    public int Index;
    public GameObject Prefab;
    public bool isComplete;
}
