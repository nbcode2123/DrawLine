using System.Collections.Generic;
using UnityEngine;

public class DrawLineController : MonoBehaviour
{
    public static DrawLineController Instance { private set; get; }
    public GameObject LinePrefab;
    public GameObject CurrentLine;
    public bool isFirstLine = false;
    public bool isInLevel = false;
    public List<GameObject> ListLine;
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
        // ObserverManager.AddListener("Level Complete", LevelCompleteAction);

    }


    void Update()
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
                ObserverManager.Notify("OpenSquare");

            }
        }


    }
    public void ResetVariable()
    {
        isInLevel = false;
        isFirstLine = false;
        for (int i = 0; i < ListLine.Count; i++)
        {
            Destroy(ListLine[i]);
        }
        ListLine.Clear();

    }



}
