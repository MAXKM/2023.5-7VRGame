using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    float a = 0, b = 0, c=1.5f, d=0; //a=�p���`�З� b=��_�{�� c=�U���o�t�{�� d=�v�Z����
    float Damage;       //�_���[�W��
    bool powerd;        //���F�U���͋�����Ԃ�(HandDetection����󂯎��)
    bool weakpoint;     //���F�}�����ǂ���(BossMonitorManager����󂯎��)
    bool DDecision;     //���F�����̓����蔻��(MonitorDetectin����󂯎��)
    bool BDecision;     //���F�{�X�̓����蔻��(BossMonitorManager����󂯎��)
    // Start is called before the first frame update
    void Start()
    {
        //GameInfomation���烌�x�����󂯎��
        KariInfo gameinfomation;
        GameObject obj = GameObject.Find("KariInfObj");
        gameinfomation = obj.GetComponent<KariInfo>();

        //�p���`�З͂̃��x���ňЗ͂�ς���
        if (gameinfomation.powerUpLevel == 1)
        {
            a = 10;
        }
        else if (gameinfomation.powerUpLevel == 2)
        {
            a = 12.5f;
        }
        else if (gameinfomation.powerUpLevel == 3)
        {
            a = 15;
        }
        else if (gameinfomation.powerUpLevel == 4)
        {
            a = 17.5f;
        }
        else
        {
            a = 20;
        }

        //��_�{�����x���Ŕ{����ς���
        if(gameinfomation.weakPointMagnificationLevel == 1)
        {
            b = 5;
        }
        else if (gameinfomation.weakPointMagnificationLevel == 2)
        {
            b = 7.5f;
        }
        else if (gameinfomation.weakPointMagnificationLevel == 3)
        {
            b = 10;
        }
        else if (gameinfomation.weakPointMagnificationLevel == 4)
        {
            b = 12.5f;
        }
        else
        {
            b = 15;
        }
        //��_�Ȃǂ̐؂�ւ�
        //DDecision = true;
        BDecision = true;
        //weakpoint = true;
        powerd = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DDecision == true)  //�����̓����蔻�肪������
        {
            Damage = DDamage();
            Debug.Log(Damage);
        }

        if (BDecision == true)  //�{�X�̓����蔻�肪������
        {
            Damage = BDamage();
            Debug.Log(Damage);
        }
        
    }

    //public void shutoku()
    //{
    //    KariInfo gameinfomation;
    //    GameObject obj = GameObject.Find("KariInfObj");
    //    gameinfomation = obj.GetComponent<KariInfo>();
    //}
    public float DDamage()  //�����̃_���[�W�v�Z
    {
        d = a;
        return d;
    }

    public float BDamage()  //�{�X�̃_���[�W�v�Z
    {
        if(weakpoint == true && powerd == true)     //��_�������o�t����
        {
            d = a * b * c;
        }
        else if(weakpoint==true && powerd == false)     //��_����
        {
            d = a * b;
        }
        else if(weakpoint == false && powerd == true)       //�����o�t����
        {
            d = a * c;
        }
        else        //�f�t�H���g
        {
            d = a;
        }
        return d;
    }


}
