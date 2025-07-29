using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SlotMachine : MonoBehaviour
{
    public GameObject Pivot;
    public GameObject BallInSlot;
    public GameObject Ball;
    public GameObject Switch;
    public float TimeSpawn;
    public int BallAmount;



    // Start is called before the first frame update
    void Start()
    {
        ObserverManager.AddListener("OpenSlotMachine", SpawnBall);
    }
    private void OnDisable()
    {
        ObserverManager.RemoveListener("OpenSlotMachine", SpawnBall);

    }
    private void OnDestroy()
    {
        ObserverManager.RemoveListener("OpenSlotMachine", SpawnBall);

    }

    // Update is called once per frame
    void Update()
    {

    }
    public Tween AnimationSwitch()
    {
        return Switch.transform.DORotate(new Vector3(0, 0, 150f), 0.5f);
    }
    public void SpawnBall()
    {
        AnimationSwitch().OnComplete(() =>
        {
            AnimationBallInSlot();
            Sequence sequence = DOTween.Sequence();
            for (int i = 0; i < BallAmount; i++)
            {
                sequence.AppendCallback(() =>
                {
                    GameObject _tempBall = Instantiate(Ball, Pivot.transform);
                    _tempBall.transform.IsChildOf(gameObject.transform);


                });
                sequence.AppendInterval(TimeSpawn / BallAmount);
            }
        });


    }
    public void AnimationBallInSlot()
    {
        BallInSlot.transform.DOLocalMoveY(-0.2f, TimeSpawn);
    }
}
