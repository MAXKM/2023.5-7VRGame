using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test03 : MonoBehaviour
{
    //public KariInfo gameinformation;
    public GameInformation gameinformation;
    //[SerializeField] DamagePopUpTextManager damagepopuptextmanager;
    //public MonitorDetection monitordetection;
    //public BossMonitorManager bossmonitormager;
    //public HandDetection handdetection;
    float a = 0, b = 0, c = 1.5f; //a=�p���`�З� b=��_�{�� c=�U���o�t�{��
    float PowerdLimit = 0;
    Vector3 vv;
    float Damage;       //�_���[�W��
    float Distance; //���� (HandDetection����󂯎��)
    bool powerd;        //���F�U���͋�����Ԃ�(HandDetection����󂯎��)
    bool weakpoint;     //���F�}�����ǂ���(BossMonitorManager����󂯎��)
    bool DDecision;     //���F�����̓����蔻��(MonitorDetectin����󂯎��)
    bool BDecision;     //���F�{�X�̓����蔻��(BossMonitorManager����󂯎��)
    // Start is called before the first frame update
    void Start()
    {

        //a = PunchPower(gameinformation.powerUpLevel);   //�p���`�З͊��蓖��
        //b = WeakPointMultiplier(gameinformation.weakPointMagnificationLevel);   //��_�{�����蓖��
        //PowerdLimit =PowerTimeLimit(gameinformation.powerUpTimeLevel);  //n�b�����̊��蓖��

        //��_�Ȃǂ̐؂�ւ�
        //DDecision = true;
        //BDecision = true;
        //weakpoint = true;
        //powerd = false;

    }

    // Update is called once per frame
    void Update()
    {
        //powerd = handdetection.strengthenMode;

        //if (DDecision == true)  //�����̓����蔻�肪������
        //{
        //    Damage = DDamage();
        //    Debug.Log(Damage);
        //}

        //if (BDecision == true)  //�{�X�̓����蔻�肪������
        //{
        //    Damage = BDamage();
        //    Debug.Log(Damage);
        //}

    }

    public void PowerUP()
    {
        powerd = true;
    }

    public void DDamage(float Distance)  //�����̃_���[�W�v�Z
    {
        Damage = a * Distance;
        //damagepopuptextmanager.Active(vv, Damage);
    }

    public void BDamage(float Distance)  //�{�X�̃_���[�W�v�Z
    {
        if (weakpoint == true && powerd == true)     //��_�������o�t����
        {
            Damage = a * b * c * Distance;
        }
        else if (weakpoint == true && powerd == false)     //��_����
        {
            Damage = a * b * Distance;
        }
        else if (weakpoint == false && powerd == true)       //�����o�t����
        {
            Damage = a * c * Distance;
        }
        else        //�f�t�H���g
        {
            Damage = a * Distance;
        }

        //damagepopuptextmanager.Active(vv, Damage);
    }

    private float PunchPower(int level)
    {
        //�p���`�З͂̃��x���ňЗ͂�ς���
        switch (level)
        {
            case 1:
                a = 10;
                break;
            case 2:
                a = 12.5f;
                break;
            case 3:
                a = 15;
                break;
            case 4:
                a = 17.5f;
                break;
            case 5:
                a = 20;
                break;
        }
        return a;
    }

    private float WeakPointMultiplier(int level)
    {
        //��_�{�����x���Ŕ{����ς���
        switch (level)
        {
            case 1:
                b = 5;
                break;
            case 2:
                b = 7.5f;
                break;
            case 3:
                b = 10;
                break;
            case 4:
                b = 12.5f;
                break;
            case 5:
                b = 15;
                break;
        }
        return b;
    }

    private float PowerTimeLimit(int level)
    {
        //��_�{�����x���Ŕ{����ς���
        switch (level)
        {
            case 1:
                PowerdLimit = 0;
                break;
            case 2:
                PowerdLimit = 1.5f;
                break;
            case 3:
                PowerdLimit = 3;
                break;
            case 4:
                PowerdLimit = 4.5f;
                break;
            case 5:
                PowerdLimit = 6;
                break;
        }
        return PowerdLimit;
    }
}