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

    //���Transform
    [SerializeField] Transform rightHandTf,leftHandTf;

    //��̍��W
    Vector3 rightHandPos,leftHandPos;

    //���P�b�g�����̃g���K�[�|�C���g
    const float ROCKET_ACTIVATION_POINT = 0.3f;

    //���P�b�g������Ԃ𔻒�
    public bool rocketMode;

    private void Start()
    {
        attackable = false;
        strengthenMode = false;
        rocketMode = false;
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

        //HandPos�ɗ���̍��W����
        rightHandPos = rightHandTf.localPosition;
        leftHandPos = leftHandTf.localPosition;

        //����̍��������P�b�g�̃g���K�[�|�C���g�𒴂����烍�P�b�g����
        if(rightHandPos.y > ROCKET_ACTIVATION_POINT && leftHandPos.y > ROCKET_ACTIVATION_POINT)
        {
            rocketMode = true;
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
