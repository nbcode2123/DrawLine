
using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }
    public List<GameObject> Level;
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
        Debug.Log(1);
        ObserverManager.Notify("ChangeToLevelScene");


    }



}
