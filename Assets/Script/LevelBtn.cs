using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBtn : MonoBehaviour
{
    public int Level;

    // Start is called before the first frame update
    void Start()
    {
        CheckLevelUnlock();
        ObserverManager.AddListener("Level Complete", CheckLevelUnlock);



    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LevelBtnNotify()
    {
        SceneController.Instance.ChangeToLevelScene(Level);







    }
    public void CheckLevelUnlock()
    {
        // if (LevelManager.Instance.LevelUnlock.Contains(Level) == false)
        // {
        //     gameObject.GetComponent<Button>().interactable = false;

        // }
        // else
        // {
        //     gameObject.GetComponent<Button>().interactable = true;

        // }
    }
}
