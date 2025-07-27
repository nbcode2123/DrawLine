
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CompleteCanvasStarEffect : MonoBehaviour
{
    public Image Star1;
    public Image Star2;
    public Image Star3;
    public int StarLevelComplete;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnEnable()
    {
        Star1.rectTransform.localScale = new Vector3(4, 4, 1);
        Star2.rectTransform.localScale = new Vector3(4, 4, 1);
        Star3.rectTransform.localScale = new Vector3(4, 4, 1);

        StarLevelComplete = LevelManager.Instance.StarCurrentLevel;
        Sequence sequence = DOTween.Sequence();
        sequence.AppendInterval(1.5f);
        sequence.AppendCallback(() =>
        {
            if (StarLevelComplete == 3)
            {
                ThreeStarAnimation();

            }
            else if (StarLevelComplete == 2)
            {
                TwoStarAnimation();
            }
            else if (StarLevelComplete == 1)
            {
                OneStarAnimation();
            }



        });



    }
    public void Reset()
    {
        Star1.rectTransform.localScale = new Vector3(4, 4, 1);
        Star2.rectTransform.localScale = new Vector3(4, 4, 1);
        Star3.rectTransform.localScale = new Vector3(4, 4, 1);
        Star1.DOFade(0f, 0.2f);
        Star2.DOFade(0f, 0.2f);
        Star3.DOFade(0f, 0.2f);



    }
    public void ThreeStarAnimation()
    {
        Star1.DOFade(1f, 0.5f);
        Star1.rectTransform.DOScale(1f, 0.5f);
        Star2.DOFade(1f, 0.5f);
        Star2.rectTransform.DOScale(1f, 0.5f);
        Star3.DOFade(1f, 0.5f);
        Star3.rectTransform.DOScale(1f, 0.5f);

    }
    public void TwoStarAnimation()
    {
        Star1.DOFade(1f, 0.5f);
        Star1.rectTransform.DOScale(1f, 0.5f);
        Star2.DOFade(1f, 0.5f);
        Star2.rectTransform.DOScale(1f, 0.5f);


    }
    public void OneStarAnimation()
    {
        Star1.DOFade(1f, 0.5f);
        Star1.rectTransform.DOScale(1f, 0.5f);



    }

}
