using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    //public KariInfo gameinformation;
    public GameInformation gameinformation;
    [SerializeField] DamagePopUpTextManager damagepopuptextmanager;
    //public MonitorDetection monitordetection;
    //public BossMonitorManager bossmonitormager;
    //public HandDetection handdetection;
    float a = 0, b = 0, c = 1.5f; //a=�p���`�З� b=��_�{�� c=�U���o�t�{��
    float PowerdLimit=0;
    float RLevel=0;
    Vector3 vv;
    public float Damage;       //�_���[�W��
    float Distance; //���� (HandDetection����󂯎��)
    bool powerd;        //���F�U���͋�����Ԃ�(HandDetection����󂯎��)
    //bool weakpoint;     //���F�}�����ǂ���(BossMonitorManager����󂯎��)
    bool DDecision;     //���F�����̓����蔻��(MonitorDetectin����󂯎��)
    bool BDecision;     //���F�{�X�̓����蔻��(BossMonitorManager����󂯎��)

    [SerializeField] HandDetection handDetection;
    [SerializeField] NewWeakPoint newweakpoint;
    // Start is called before the first frame update
    void Start()
    {
        a = PunchPower(gameinformation.powerUpLevel);   //�p���`�З͊��蓖��
        //b = WeakPointMultiplier(gameinformation.weakPointMagnificationLevel);   //��_�{�����蓖��
        PowerdLimit =PowerTimeLimit(gameinformation.powerUpTimeLevel);  //n�b�����̊��蓖��
        RLevel = Rocket(gameinformation.rocketMagnificationLevel);

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

    //�g��Ȃ�����
    //public void PowerUP()
    //{
    //    if (handDetection.strengthenMode)
    //    {
    //        powerd = true;
    //    }
    //}

    public void DDamage(Vector3 vv, float Distance,bool isAttack = true)  //�����̃_���[�W�v�Z
    {
        a = PunchPower(gameinformation.powerUpLevel);   //�p���`�З͊��蓖��
        PowerdLimit = PowerTimeLimit(gameinformation.powerUpTimeLevel);  //n�b�����̊��蓖��


        if (isAttack)
        {
            Distance = Mathf.Min(Distance,10) * 50;
            Distance = Mathf.Round(Distance) / 100;
            Damage = a * (Distance + 0.5f);
        }
        else
        {
            Damage = 0;
        }

        //�e�X�g�p�ɒǉ�
        //Debug.Log("damage:" + Damage);
        //Debug.Log("a:" +a);
        damagepopuptextmanager.Active(vv, Damage);
    }

    public void BDamage(Vector3 vv, float Distance)  //�{�X�̃_���[�W�v�Z
    {
        Distance = Mathf.Min(Distance,10) * 50;              //������100�{
        Distance = Mathf.Round(Distance) / 100; //100�{�ɂ����������l�̌ܓ����A���ɖ߂��ď����_��2�ʂ܂łɂ���

        if (newweakpoint.weak == true && handDetection.strengthenMode == true)     //��_�������o�t����
        {
            Damage = a * b * c * (Distance + 0.5f);
        }
        else if(newweakpoint.weak == true && handDetection.strengthenMode == false)     //��_����
        {
            Damage = a * b * (Distance + 0.5f);
        }
        else if(newweakpoint.weak == false && handDetection.strengthenMode == true)       //�����o�t����
        {
            Damage = a * c * (Distance + 0.5f);
        }
        else        //�f�t�H���g
        {
            Damage = a * (Distance + 0.5f);
        }

        damagepopuptextmanager.Active(vv, Damage);
    }

    public void RDamege()
    {
        Damage = RLevel;
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

    public float PowerTimeLimit(int level)
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

    private float Rocket(int level)
    {
        //
        switch (level)
        {
            case 1:
                RLevel = 300;
                break;
            case 2:
                RLevel = 400;
                break;
            case 3:
                RLevel = 500;
                break;
            case 4:
                RLevel = 600;
                break;
            case 5:
                RLevel = 700;
                break;
        }
        return b;
    }
}
