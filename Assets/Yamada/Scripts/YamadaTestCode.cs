using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YamadaTestCode : MonoBehaviour
{
    //�e�X�g�p�R�[�h

    [SerializeField] DamagePopUpTextManager _damage;
    [SerializeField] HPGauge _gauge;
    void Start()
    {
        
    }

    float ranDamage = 0, ranX = 0f, ranY = 0f;
    void Update()
    {
        if (Input.anyKeyDown)
        {
            ranDamage = Random.Range(1, 20);
            ranX = Random.Range(-2f, 2f);
            ranY = Random.Range(-2f, 2f);
            _damage.Active(new Vector3(ranX, ranY, 0), ranDamage);
            _gauge.GaugeReduction(ranDamage);
        }
    }
}