using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    float a = 0, b = 0, c=1.5f, d=0; //a=パンチ威力 b=弱点倍率 c=攻撃バフ倍率 d=計算結果
    float Damage;       //ダメージ量
    bool powerd;        //仮：攻撃力強化状態か(HandDetectionから受け取る)
    bool weakpoint;     //仮：急所かどうか(BossMonitorManagerから受け取る)
    bool DDecision;     //仮：道中の当たり判定(MonitorDetectinから受け取る)
    bool BDecision;     //仮：ボスの当たり判定(BossMonitorManagerから受け取る)
    // Start is called before the first frame update
    void Start()
    {
        //GameInfomationからレベルを受け取る
        KariInfo gameinfomation;
        GameObject obj = GameObject.Find("KariInfObj");
        gameinfomation = obj.GetComponent<KariInfo>();

        //パンチ威力のレベルで威力を変える
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

        //弱点倍率レベルで倍率を変える
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
        //弱点などの切り替え
        //DDecision = true;
        BDecision = true;
        //weakpoint = true;
        powerd = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DDecision == true)  //道中の当たり判定が来たら
        {
            Damage = DDamage();
            Debug.Log(Damage);
        }

        if (BDecision == true)  //ボスの当たり判定が来たら
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
    public float DDamage()  //道中のダメージ計算
    {
        d = a;
        return d;
    }

    public float BDamage()  //ボスのダメージ計算
    {
        if(weakpoint == true && powerd == true)     //弱点かつ強化バフあり
        {
            d = a * b * c;
        }
        else if(weakpoint==true && powerd == false)     //弱点あり
        {
            d = a * b;
        }
        else if(weakpoint == false && powerd == true)       //強化バフあり
        {
            d = a * c;
        }
        else        //デフォルト
        {
            d = a;
        }
        return d;
    }


}
