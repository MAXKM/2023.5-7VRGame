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
    float RLevel=0;
    Vector3 vv;
    public float Damage;       //ダメージ量
    float Distance; //距離 (HandDetectionから受け取る)
    bool powerd;        //仮：攻撃力強化状態か(HandDetectionから受け取る)
    //bool weakpoint;     //仮：急所かどうか(BossMonitorManagerから受け取る)
    bool DDecision;     //仮：道中の当たり判定(MonitorDetectinから受け取る)
    bool BDecision;     //仮：ボスの当たり判定(BossMonitorManagerから受け取る)

    [SerializeField] HandDetection handDetection;
    [SerializeField] NewWeakPoint newweakpoint;
    // Start is called before the first frame update
    void Start()
    {
        a = PunchPower(gameinformation.powerUpLevel);   //パンチ威力割り当て
        //b = WeakPointMultiplier(gameinformation.weakPointMagnificationLevel);   //弱点倍率割り当て
        PowerdLimit =PowerTimeLimit(gameinformation.powerUpTimeLevel);  //n秒強化の割り当て
        RLevel = Rocket(gameinformation.rocketMagnificationLevel);

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

    //使わないかも
    //public void PowerUP()
    //{
    //    if (handDetection.strengthenMode)
    //    {
    //        powerd = true;
    //    }
    //}

    public void DDamage(Vector3 vv, float Distance,bool isAttack = true)  //道中のダメージ計算
    {
        a = PunchPower(gameinformation.powerUpLevel);   //パンチ威力割り当て
        PowerdLimit = PowerTimeLimit(gameinformation.powerUpTimeLevel);  //n秒強化の割り当て


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

        //テスト用に追加
        //Debug.Log("damage:" + Damage);
        //Debug.Log("a:" +a);
        damagepopuptextmanager.Active(vv, Damage);
    }

    public void BDamage(Vector3 vv, float Distance)  //ボスのダメージ計算
    {
        Distance = Mathf.Min(Distance,10) * 50;              //距離を100倍
        Distance = Mathf.Round(Distance) / 100; //100倍にした距離を四捨五入し、元に戻して小数点第2位までにした

        if (newweakpoint.weak == true && handDetection.strengthenMode == true)     //弱点かつ強化バフあり
        {
            Damage = a * b * c * (Distance + 0.5f);
        }
        else if(newweakpoint.weak == true && handDetection.strengthenMode == false)     //弱点あり
        {
            Damage = a * b * (Distance + 0.5f);
        }
        else if(newweakpoint.weak == false && handDetection.strengthenMode == true)       //強化バフあり
        {
            Damage = a * c * (Distance + 0.5f);
        }
        else        //デフォルト
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

    public float PowerTimeLimit(int level)
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
