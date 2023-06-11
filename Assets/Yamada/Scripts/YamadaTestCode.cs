using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YamadaTestCode : MonoBehaviour
{
    //テスト用コード

    [SerializeField] DamagePopUpTextManager _damage;
    [SerializeField] HPGauge _gauge;
    void Start()
    {
        _gauge.Set(100);
    }

    float ranDamage = 0, ranX = 0f, ranY = 0f;
    void Update()
    {
        if (Input.anyKeyDown)
        {
            ranDamage = Random.Range(1, 20);
            ranX = Random.Range(-1f, 1f);
            ranY = Random.Range(0, 1f);
            _damage.Active(new Vector3(ranX, ranY, 0), ranDamage);
            _gauge.GaugeReduction(ranDamage);
        }
    }
}
