using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus;

public class HandDetection : MonoBehaviour
{
    MeshRenderer meshRenderer;

    //�U���\���A�X�L�������\���𔻕�
    //���w�̃g���K�[���������Ƃ�true
    private bool attackable;

    //���b������ԉ��𔻒�
    public bool strengthenMode;

    private void Start()
    {
        attackable = false;
        strengthenMode = false;
    }

    private void Update()
    {
        //�E���w�̃g���K�[����������
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
            //n�b������Ԃɓ���
            strengthenMode = true;
        }
    }
}
