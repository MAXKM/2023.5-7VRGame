using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus;

public class HandDetection : MonoBehaviour
{
    MeshRenderer meshRenderer;

    //攻撃可能か、スキル発動可能かを判別
    //中指のトリガーを押すことでtrue
    private bool attackable;

    //ｎ秒強化状態化を判定
    public bool strengthenMode;

    //手のTransform
    [SerializeField] Transform rightHandTf,leftHandTf;

    //手の座標
    Vector3 rightHandPos,leftHandPos;

    //ロケット発動のトリガーポイント
    const float ROCKET_ACTIVATION_POINT = 0.3f;

    //ロケット発動状態を判定
    public bool rocketMode;

    private void Start()
    {
        attackable = false;
        strengthenMode = false;
        rocketMode = false;
    }

    private void Update()
    {
        //右中指のトリガーを押したら
        if (OVRInput.Get(OVRInput.RawButton.RHandTrigger))
        {
            attackable = true;
        }
        else
        {
            attackable = false;
        }

        //HandPosに両手の座標を代入
        rightHandPos = rightHandTf.localPosition;
        leftHandPos = leftHandTf.localPosition;

        //両手の高さがロケットのトリガーポイントを超えたらロケット発動
        if(rightHandPos.y > ROCKET_ACTIVATION_POINT && leftHandPos.y > ROCKET_ACTIVATION_POINT)
        {
            rocketMode = true;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "hand" && attackable)
        {
            //n秒強化状態に入る
            strengthenMode = true;
        }
    }
}
