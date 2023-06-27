using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class GameStartAnimation : MonoBehaviour
{
    [SerializeField] CanvasGroup title ;
    [SerializeField] CanvasGroup explain;
    [SerializeField] CanvasGroup RigthArrow_Explain;
    [SerializeField] CanvasGroup LeftArrow_Explain;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Fadetext()
    {
        title.DOFade(0,1f);
        explain.DOFade(0,1f);
        RigthArrow_Explain.DOFade(0,1f);
        LeftArrow_Explain.DOFade(0,1f);  
    }
}
