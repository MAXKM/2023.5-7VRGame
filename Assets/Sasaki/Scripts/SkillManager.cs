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
    float a = 0, b = 0, c = 1.5f; //a=パンチ威力 b=弱点倍率 c=攻撃バフ倍率
    float PowerdLimit=0;
    Vector3 vv;
    float Damage;       //ダメージ量
    float Distance; //距離 (HandDetectionから受け取る)
    bool powerd;        //仮：攻撃力強化状態か(HandDetectionから受け取る)
    bool weakpoint;     //仮：急所かどうか(BossMonitorManagerから受け取る)
    bool DDecision;     //仮：道中の当たり判定(MonitorDetectinから受け取る)
    bool BDecision;     //仮：ボスの当たり判定(BossMonitorManagerから受け取る)
    // Start is called before the first frame update
    void Start()
    {

        //a = PunchPower(gameinformation.powerUpLevel);   //パンチ威力割り当て
        //b = WeakPointMultiplier(gameinformation.weakPointMagnificationLevel);   //弱点倍率割り当て
        //PowerdLimit =PowerTimeLimit(gameinformation.powerUpTimeLevel);  //n秒強化の割り当て

        //弱点などの切り替え
        //DDecision = true;
        //BDecision = true;
        //weakpoint = true;
        //powerd = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        //powerd = handdetection.strengthenMode;

        //if (DDecision == true)  //道中の当たり判定が来たら
        //{
        //    Damage = DDamage();
        //    Debug.Log(Damage);
        //}

        //if (BDecision == true)  //ボスの当たり判定が来たら
        //{
        //    Damage = BDamage();
        //    Debug.Log(Damage);
        //}

    }

    public void DDamage(float Distance)  //道中のダメージ計算
    {
        Damage = a * Distance;
        damagepopuptextmanager.Active(vv, Damage);
    }

    public void BDamage(float Distance)  //ボスのダメージ計算
    {
        if(weakpoint == true && powerd == true)     //弱点かつ強化バフあり
        {
            Damage = a * b * c * Distance;
        }
        else if(weakpoint==true && powerd == false)     //弱点あり
        {
            Damage = a * b * Distance;
        }
        else if(weakpoint == false && powerd == true)       //強化バフあり
        {
            Damage = a * c * Distance;
        }
        else        //デフォルト
        {
            Damage = a * Distance;
        }

        damagepopuptextmanager.Active(vv, Damage);
    }

    private float PunchPower(int level)
    {
        //パンチ威力のレベルで威力を変える
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
        //弱点倍率レベルで倍率を変える
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
        //弱点倍率レベルで倍率を変える
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
