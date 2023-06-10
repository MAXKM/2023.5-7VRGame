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

    private void Start()
    {
        attackable = false;
        strengthenMode = false;
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
