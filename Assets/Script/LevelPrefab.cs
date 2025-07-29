using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPrefab : MonoBehaviour
{
    public GameObject Hint;
    private void Start()
    {
        Hint.SetActive(false);
    }

    public void TurnOnHint()
    {
        Hint.SetActive(true);

    }


}
