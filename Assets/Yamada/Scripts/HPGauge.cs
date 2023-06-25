using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HPGauge : MonoBehaviour
{
    private float MaxHP;//�ő�HP
    public float CurrentHP { private set; get; }//���݂�HP

    [SerializeField] GameObject HPGauges;
    [SerializeField] Image GreenGauge;
    [SerializeField] Image RedGauge;
    
    private Tween _redGaugeTween;

    private void Awake()
    {
        HPGauges.SetActive(false);
    }

    //�J�n����BOSS�ɌĂ�ł��炤
    public void Set(float HPNum)
    {
        MaxHP = HPNum;
        CurrentHP = MaxHP;
        HPGauges.SetActive(true);
    }

    //HP�Q�[�W����(�Ε����������遨�Ԃ�������������)
    public void GaugeReduction(float reducationValue, float time = 0.5f)
    {
        float valueFrom = CurrentHP / MaxHP;

        CurrentHP = CurrentHP - reducationValue;
        float valueTo;
        if (CurrentHP <= 0)
            valueTo = 0;
        else
            valueTo = CurrentHP / MaxHP;

        // �΃Q�[�W����
        GreenGauge.fillAmount = valueTo;

        if (_redGaugeTween != null)
        {
            _redGaugeTween.Kill();
        }

        // �ԃQ�[�W����
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