using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HPGauge : MonoBehaviour
{
    private float MaxHP;//最大HP
    public float CurrentHP { private set; get; }//現在のHP

    [SerializeField] GameObject HPGauges;
    [SerializeField] Image GreenGauge;
    [SerializeField] Image RedGauge;
    
    private Tween _redGaugeTween;

    private void Awake()
    {
        HPGauges.SetActive(false);
    }

    //開始時にBOSSに呼んでもらう
    public void Set(float HPNum)
    {
        MaxHP = HPNum;
        CurrentHP = MaxHP;
        HPGauges.SetActive(true);
    }

    //HPゲージ減少(緑部分が消える→赤がゆっくり消える)
    public void GaugeReduction(float reducationValue, float time = 0.5f)
    {
        float valueFrom = CurrentHP / MaxHP;

        CurrentHP = CurrentHP - reducationValue;
        float valueTo;
        if (CurrentHP <= 0)
            valueTo = 0;
        else
            valueTo = CurrentHP / MaxHP;

        // 緑ゲージ減少
        GreenGauge.fillAmount = valueTo;

        if (_redGaugeTween != null)
        {
            _redGaugeTween.Kill();
        }

        // 赤ゲージ減少
        _redGaugeTween = DOTween.To(
            () => valueFrom,
            x =>
            {
                RedGauge.fillAmount = x;
            },
            valueTo,
            time
        );
    }
}