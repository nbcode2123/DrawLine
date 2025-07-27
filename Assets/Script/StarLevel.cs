using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarLevel : MonoBehaviour
{
    public Sprite Sprite1;
    public Sprite Sprite2;
    public Image Image;
    public void Start()
    {
        Image.sprite = Sprite1;

    }

    public void OnSprite()
    {
        Image.sprite = Sprite1;

    }
    public void OffSprite()
    {
        Image.sprite = Sprite2;

    }
}
