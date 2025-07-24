using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareBall : MonoBehaviour
{
    public GameObject Bottom;
    // Start is called before the first frame update
    void Start()
    {
        ObserverManager.AddListener("OpenSquare", TurnOffBottom);
    }
    public void TurnOffBottom()
    {
        Bottom.SetActive(false);

    }
    private void OnDestroy()
    {
        ObserverManager.RemoveListener("OpenSquare", TurnOffBottom);

    }
    private void OnDisable()

    {
        ObserverManager.RemoveListener("OpenSquare", TurnOffBottom);

    }

}
