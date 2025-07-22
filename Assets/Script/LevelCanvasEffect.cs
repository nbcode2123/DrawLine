using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class LevelCanvasEffect : MonoBehaviour
{
    private RectTransform canvas;
    private float x;
    void Start()
    {
        ObserverManager.AddListener("PlayBtn", ActiveAnimationEffect);
        ObserverManager.AddListener("BackToMenuLevel", ActiveAnimationEffectReverse);
        ObserverManager.AddListener("ChangeToLevelScene", ActiveAnimationEffectReverse);




        canvas = gameObject.GetComponent<RectTransform>();
        x = canvas.anchoredPosition.x;


    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ActiveAnimationEffect()
    {
        canvas.DOAnchorPosX(0f, 0.5f);
    }
    public void ActiveAnimationEffectReverse()
    {
        canvas.DOAnchorPosX(x, 0.5f);

    }
    private void OnEnable()
    {
        ActiveAnimationEffectReverse();

    }

}
