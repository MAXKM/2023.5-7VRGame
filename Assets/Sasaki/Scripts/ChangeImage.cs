using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeImage : MonoBehaviour
{
    [SerializeField] private GameObject FarstSprite;
    [SerializeField] private Sprite SecondSprite;

    public void OnClick()
    {
        if (FarstSprite == null)
        {
            Debug.Log("���x���Q");
        }
        if (SecondSprite == null)
        {
            Debug.Log("���x���P");
        }
        var spriteRenderer = FarstSprite.GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = SecondSprite;
    }
}
