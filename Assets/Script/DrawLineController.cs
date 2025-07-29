using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DrawLineController : MonoBehaviour
{
    public static DrawLineController Instance { private set; get; }
    public GameObject LinePrefab;
    public GameObject CurrentLine;
    public bool isFirstLine = false;
    public bool isInLevel = false;
    public List<GameObject> ListLine;
    public GameObject Pen;
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
    private void Start()
    {

    }


    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && isInLevel == true)
            {
                CurrentLine = Instantiate(LinePrefab);
                ListLine.Add(CurrentLine);


            }

            if (Input.GetMouseButtonUp(0) && isInLevel == true)
            {
                if (isFirstLine == false)
                {
                    isFirstLine = true;
                    ObserverManager.Notify("OpenSlotMachine");

                }
            }
        }



    }
    public void ClearLine()
    {
        for (int i = 0; i < ListLine.Count; i++)
        {
            Destroy(ListLine[i]);
        }
        ListLine.Clear();
    }

    // public void ResetVariableOutLevel()
    // {
    //     isInLevel = false;
    //     isFirstLine = false;
    //     for (int i = 0; i < ListLine.Count; i++)
    //     {
    //         Destroy(ListLine[i]);
    //     }
    //     ListLine.Clear();

    // }
    // public void ResetVariableInLevel()
    // {
    //     isInLevel = true;
    //     isFirstLine = false;
    //     for (int i = 0; i < ListLine.Count; i++)
    //     {
    //         Destroy(ListLine[i]);
    //     }
    //     ListLine.Clear();

    // }


}
