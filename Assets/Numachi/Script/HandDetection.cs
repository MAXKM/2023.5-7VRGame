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

    //���E�̎�̈ړ�����
    public float distanceRight,distanceLeft;

    //�O�t���[���̍��W(�����v�Z�̍ۂɎg�p)
    private Vector3 previousPosRight, previousPosLeft;

    private void Start()
    {
        attackable = false;
        rocketMode = false;
        strengthenMode = false;
        ResetDistance();
        previousPosRight = rightHandTf.localPosition;
        previousPosLeft = leftHandTf.localPosition;
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

        distanceRight = DistanceCalculationRight(distanceRight);
        distanceLeft = DistanceCaluculationLeft(distanceLeft);
        //Debug.Log("�E����" + distanceRight);
        //Debug.Log("������" + distanceLeft);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "LeftHand"&& attackable)
        {
            //n�b������Ԃɓ���
            strengthenMode = true;
        }
    }

    //�E��̈ړ��������v�Z

    private float DistanceCalculationRight(float distance)
    {
        //���݂̍��W����U�ۑ�
        Vector3 currentPos = rightHandPos;

        //���݂̍��W�ƕۑ����Ă��������W�̍����̋������v�Z
        float currentDistance = Vector3.Distance(currentPos,previousPosRight);

        //���ړ������ɉ��Z
        distance += currentDistance;

        //���݂̍��W��ۑ�
        previousPosRight = currentPos;

        return distance;
    }

    //����̈ړ��������v�Z
    private float DistanceCaluculationLeft(float distance)
    {
        //���݂̍��W����U�ۑ�
        Vector3 currentPos = leftHandPos;

        //���݂̍��W�ƕۑ����Ă��������W�̍����̋������v�Z
        float currentDistance = Vector3.Distance(currentPos, previousPosLeft);

        //���ړ������ɉ��Z
        distance += currentDistance;

        //���݂̍��W��ۑ�
        previousPosLeft = currentPos;

        return distance;
    }

    //������0�ɏ���������֐�
    public void ResetDistance()
    {
        distanceLeft = 0;
        distanceRight = 0;
    }
}
