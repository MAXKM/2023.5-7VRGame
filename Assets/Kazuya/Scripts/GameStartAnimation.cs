using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class GameStartAnimation : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasgroup ;
    [SerializeField] CanvasGroup SkillPanel;
    [SerializeField] GameObject Leftarrow;
    [SerializeField] GameObject Rightarrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Fadetext()
    {
        canvasgroup.DOFade(0,1f);
        SkillPanel.DOFade(0,1f);
    }
    public void HideArrow()
    {
        Leftarrow.gameObject.SetActive(false);
        Rightarrow.gameObject.SetActive(false);
    }
}
