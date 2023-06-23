using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class GameStartAnimation : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasgroup ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Fadetext()
    {
        canvasgroup.DOFade(0,1f);
    }
}
