using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus;

public class HandDetection : MonoBehaviour
{
    MeshRenderer meshRenderer;

    //GameManagerのunableSkillで攻撃可能か、スキル発動可能かを判別
    [SerializeField] GameManager gameManager;


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

    //左右の手の移動距離
    public float distanceRight,distanceLeft;

    //前フレームの座標(距離計算の際に使用)
    private Vector3 previousPosRight, previousPosLeft;

    private void Start()
    {
        rocketMode = false;
        strengthenMode = false;
        ResetDistance();
        previousPosRight = rightHandTf.localPosition;
        previousPosLeft = leftHandTf.localPosition;
    }

    private void Update()
    {
        //HandPosに両手の座標を代入
        rightHandPos = rightHandTf.localPosition;
        leftHandPos = leftHandTf.localPosition;

        //両手の高さがロケットのトリガーポイントを超えたらロケット発動
        if(rightHandPos.y > ROCKET_ACTIVATION_POINT && leftHandPos.y > ROCKET_ACTIVATION_POINT && gameManager.usableSkill)
        {
            rocketMode = true;
        }

        distanceRight = DistanceCalculationRight(distanceRight);
        distanceLeft = DistanceCaluculationLeft(distanceLeft);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "LeftHand" && gameManager.usableSkill)
        {
            //n秒強化状態に入る
            strengthenMode = true;
        }
    }

    //右手の移動距離を計算
    private float DistanceCalculationRight(float distance)
    {
        //現在の座標を一旦保存
        Vector3 currentPos = rightHandPos;

        //現在の座標と保存しておいた座標の差分の距離を計算
        float currentDistance = Vector3.Distance(currentPos,previousPosRight);

        //総移動距離に加算
        distance += currentDistance;

        //現在の座標を保存
        previousPosRight = currentPos;

        return distance;
    }

    //左手の移動距離を計算
    private float DistanceCaluculationLeft(float distance)
    {
        //現在の座標を一旦保存
        Vector3 currentPos = leftHandPos;

        //現在の座標と保存しておいた座標の差分の距離を計算
        float currentDistance = Vector3.Distance(currentPos, previousPosLeft);

        //総移動距離に加算
        distance += currentDistance;

        //現在の座標を保存
        previousPosLeft = currentPos;

        return distance;
    }

    //距離を0に初期化する関数
    public void ResetDistance()
    {
        distanceLeft = 0;
        distanceRight = 0;
    }
}
