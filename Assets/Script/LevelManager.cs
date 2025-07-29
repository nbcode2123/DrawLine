
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        if (_tempLevel == null || _tempLevel.Prefab == null)
        {
            UIController.Instance.TurnOnEndCanvas();
        }
        else
        {
            CurrentLevel = _tempLevel;
            CurrentLevelObj = Instantiate(_tempLevel.Prefab);
            StarCurrentLevel = 0;
        }

    }
    public void BallCounterIncrease()
    {
        BallCounter++;
        if (BallCounter == BallCounterComplete)
        {
            BallCounter = 0;
            ;

            if (LevelUnlock.ListLevelUnlock.Contains(CurrentLevelIndex + 1) == false)
            {
                LevelUnlock.ListLevelUnlock.Add(CurrentLevelIndex + 1);

            }

            Data data = DataSystem.LoadData();
            if (data.ListLevelPlayerPref.Find(x => x.Index == CurrentLevelIndex) == null || data == null)
            {
                data.ListLevelPlayerPref.Add(new LevelPlayerPref { Index = CurrentLevelIndex, Star = StarCurrentLevel });
                DataSystem.SaveData(data);

            }



            ObserverManager.Notify("Level Complete");
            ObserverManager.Notify("PlayAudio", "LevelComplete");
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
        if (_tempLevel == null)
        {
            Debug.Log("level null");
            UIController.Instance.TurnOnEndCanvas();
            UIController.Instance.TurnOffLevelCanvas();
        }
        else
        {
            CurrentLevelObj = Instantiate(_tempLevel.Prefab);
            CurrentLevelIndex = _tempLevel.Index;
            SliderStar.value = SliderStar.maxValue;
            BallCounter = 0;
        }




    }
    public void ResetVariable()
    {
        Destroy(CurrentLevelObj);
        SliderStar.value = SliderStar.maxValue;
        BallCounter = 0;



    }
    public void TurnOnHintLevel()
    {
        CurrentLevelObj.GetComponent<LevelPrefab>().TurnOnHint();
    }


}
[Serializable]
public class LevelPlayerPref
{
    public int Index;
    public int Star;
}
[Serializable]
public class Data
{
    public List<LevelPlayerPref> ListLevelPlayerPref;
    public Data()
    {
        ListLevelPlayerPref = new List<LevelPlayerPref>();
        ListLevelPlayerPref.Add(new LevelPlayerPref()
        {
            Index = 0,
            Star = 0,
        });
    }

}
public static class DataSystem
{
    public static void SaveData(Data data)
    {
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("DataLevel", json);
        PlayerPrefs.Save();

    }
    public static Data LoadData()
    {
        string json = PlayerPrefs.GetString("DataLevel");
        Data data;
        if (string.IsNullOrEmpty(json))
        {
            return new Data();
        }
        else
        {
            data = JsonUtility.FromJson<Data>(json);
            if (data.ListLevelPlayerPref == null || data.ListLevelPlayerPref.Count == 0)
            {
                data.ListLevelPlayerPref = new List<LevelPlayerPref>();
                data.ListLevelPlayerPref.Add(new LevelPlayerPref()
                {
                    Index = 0,
                    Star = 0,
                });
            }

        }
        return data;

    }
}

