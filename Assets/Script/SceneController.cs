
using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance { get; private set; }
    public Image FadeImage;
    public Color FadeImgColor;
    public Sequence ChangeSequence;
    private void Awake()
    {
        if (Instance != this && Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
        FadeImgColor = FadeImage.color;




    }
    public void ChangeEffect<T>(Action<T> action, T value)
    {
        ChangeSequence = DOTween.Sequence();
        ChangeSequence.Append(DOTween.To(() => 0f, x =>
        {
            FadeImgColor.a = x;
            FadeImage.color = FadeImgColor;


        }, 1f, 1f).SetEase(Ease.Linear).OnComplete(() => { action?.Invoke(value); }));
        ChangeSequence.AppendInterval(0.5f);
        ChangeSequence.Append(DOTween.To(() => 1f, x =>
        {
            FadeImgColor.a = x;
            FadeImage.color = FadeImgColor;


        }, 0f, 1f));


    }
    public void ChangeToLevelScene(int level)
    {
        ChangeEffect(LevelManager.Instance.RunLevel, level);

    }


}
