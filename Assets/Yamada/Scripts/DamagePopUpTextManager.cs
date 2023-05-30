using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePopUpTextManager : MonoBehaviour
{
    [SerializeField] DamagePopUpText damageText;

    // �A�N�e�B�u�ȃe�L�X�g�̃��X�g
    private List<DamagePopUpText> activeList = new List<DamagePopUpText>();
    // ��A�N�e�B�u�ȃe�L�X�g�̃I�u�W�F�N�g�v�[��
    private Stack<DamagePopUpText> inactivePool = new Stack<DamagePopUpText>();

    private void Update()
    {
        // �t���Ƀ��[�v���񂵂āAactiveList�̗v�f���r���ō폜����Ă����������[�v�����悤�ɂ���
        for (int i = activeList.Count - 1; i >= 0; i--)
        {
            var damageText = activeList[i];
            if (!damageText.IsActive)
            {
                Remove(damageText);
            }
        }
    }

    // �e�L�X�g���A�N�e�B�u�����郁�\�b�h
    public void Remove(DamagePopUpText damageText)
    {
        activeList.Remove(damageText);
        inactivePool.Push(damageText);
    }

    // �e�L�X�g���A�N�e�B�u�����郁�\�b�h
    public void Active(Vector3 pos, float damage)
    {
        // ��A�N�e�B�u�̃e�L�X�g������Ύg���񂷁A�Ȃ���ΐ�������
        var DamageText = (inactivePool.Count > 0) ? inactivePool.Pop() : Instantiate(damageText, transform);

        DamageText.gameObject.SetActive(true);

        //�����ʒu�����̂܂܂ł͏�肭�s���Ȃ��J��
        DamageText.Init(pos, damage);
        activeList.Add(DamageText);
    }
}
