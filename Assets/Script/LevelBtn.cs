using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBtn : MonoBehaviour
{
    public int Level;
    public int Star;
    public Sprite SpriteNull;
    public Sprite SpriteOn;
    public Image Star1;
    public Image Star2;
    public Image Star3;
    public bool isUnlock;



    // Start is called before the first frame update
    void Start()
    {
        CheckLevelUnlock();
        Data data = DataSystem.LoadData();
        // Debug.Log(data.ListLevelPlayerPref.Find(x => x.Index == Level).Index);
        ObserverManager.AddListener("Level Complete", CheckLevelUnlock);





    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LevelBtnNotify()
    {
        SceneController.Instance.ChangeToLevelScene(Level);
        DrawLineController.Instance.isInLevel = true;
        DrawLineController.Instance.isFirstLine = false;
        ObserverManager.Notify("PlayAudio", "ButtonSound");








    }
    public void CheckLevelUnlock()
    {
        Data data = DataSystem.LoadData();
        if (data.ListLevelPlayerPref.Find(x => x.Index == Level) == null && data.ListLevelPlayerPref.Find(x => x.Index == Level - 1) == null)
        {
            gameObject.GetComponent<Button>().interactable = false;

        }
        else if (data.ListLevelPlayerPref.Find(x => x.Index == Level) != null || data.ListLevelPlayerPref.Find(x => x.Index == Level - 1) != null)
        {
            if (LevelManager.Instance.ListLevel.Find(x => x.Index == Level) == null)
            {
                gameObject.GetComponent<Button>().interactable = false;

            }
            else
            {
                gameObject.GetComponent<Button>().interactable = true;
                isUnlock = true;

                if (data.ListLevelPlayerPref.Find(x => x.Index == Level) == null)
                {
                    Star = 0;
                    UpdateStarAchievement();

                }
                else
                {

                    gameObject.GetComponent<Button>().interactable = true;
                    Star = data.ListLevelPlayerPref.Find(x => x.Index == Level).Star;
                    UpdateStarAchievement();
                }

            }





        }

    }
    public void UpdateStarAchievement()
    {
        if (Star == 3)
        {
            Star1.sprite = SpriteOn;
            Star2.sprite = SpriteOn;
            Star3.sprite = SpriteOn;

        }
        else if (Star == 2)
        {
            Star1.sprite = SpriteOn;
            Star2.sprite = SpriteOn;
            Star3.sprite = SpriteNull;
        }
        else if (Star == 1)
        {
            Star1.sprite = SpriteOn;
            Star2.sprite = SpriteNull;
            Star3.sprite = SpriteNull;
        }
        else if (Star == 0)
        {
            Star1.sprite = SpriteNull;
            Star2.sprite = SpriteNull;
            Star3.sprite = SpriteNull;
        }



    }


}
