using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketTriggerArea : MonoBehaviour
{
    public GameObject Victory;
    // Start is called before the first frame update
    void Start()
    {
        ObserverManager.AddListener("Level Complete", ActiveVictory);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            LevelManager.Instance.BallCounterIncrease();
            Destroy(other.gameObject);

        }
    }
    public void ActiveVictory()
    {
        Victory.SetActive(true);
    }
    private void OnDestroy()
    {
        ObserverManager.RemoveListener("Level Complete", ActiveVictory);

    }
    private void OnDisable()
    {


        {
            ObserverManager.RemoveListener("Level Complete", ActiveVictory);

        }
    }
}

