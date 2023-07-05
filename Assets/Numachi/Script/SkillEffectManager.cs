using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkillEffectManager : MonoBehaviour
{
    [SerializeField] HandDetection handDetection;

    [SerializeField] GameInformation gameInformation;

    [SerializeField] SkillManager skillManager;

    [SerializeField] ParticleSystem rocketParticle,rightFire,leftFire;

    //n�b�������̕b��
    [SerializeField] TextMeshProUGUI timeText;

    //�c��b��
    private float reminingSeconds = 0;

    //���x���ʐ�������
    private float limitSeconds;

    //���x���ʃ��P�b�g�c��
    private int rocketNum;


    private void Start()
    {
        //������Ԃ̓e�L�X�g�A�p�[�e�B�N�����\��
        timeText.gameObject.SetActive(false);
        rightFire.gameObject.SetActive(false);
        leftFire.gameObject.SetActive(false);

        //���x���ʐ������Ԃ��擾
        limitSeconds = skillManager.PowerTimeLimit(gameInformation.powerUpTimeLevel);
        Debug.Log("��������" + limitSeconds);

        //���P�b�g�̎c�����v�Z
        rocketNum = RocketNumCaluclation(gameInformation.rocketNumLevel);
        Debug.Log("��" + rocketNum);
    }
    private void Update()
    {
        if (handDetection.strengthenMode)
        {
            if(gameInformation.powerUpTimeLevel < 2)
            {
                return;
            }

            //���Ԍv���J�n
            reminingSeconds += Time.deltaTime;

            //������ԊJ�n
            StartStrengthenMode();

            //�e�L�X�g��\��
            DisplayTimeText(handDetection.strengthenMode);

            if (limitSeconds - reminingSeconds <= 0)
            {
                //0�b�ɂȂ����狭����ԏI��
                handDetection.strengthenMode = false;
                FinishStregnthenMode();

                //�e�L�X�g���\��
                DisplayTimeText(handDetection.strengthenMode);
            }
        }
    }

    //�e�L�X�g�̕\��/��\��
    private void DisplayTimeText(bool strMode)
    {
        timeText.gameObject.SetActive(strMode);
        timeText.text = (limitSeconds - reminingSeconds).ToString("n2");
    }

    //������Ԃ̏���
    private void StartStrengthenMode()
    {
        rightFire.gameObject.SetActive(true);
        rightFire.Play();
        leftFire.gameObject.SetActive(true);
        leftFire.Play();
    }

    //������ԏI���̏���
    private void FinishStregnthenMode()
    {
        rightFire.Stop();
        leftFire.Stop();
    }

    //���P�b�g����
    public void RocketLaunch()
    {
        //�c����0�������甭�����Ȃ�
        if (rocketNum <= 0) return;

        //���������������~������
        if(rocketParticle.isPlaying) rocketParticle.Stop();

        //���P�b�g��������
        rocketParticle.Play();

        //�c�������炷
        rocketNum--;
        Debug.Log("�c��" + rocketNum);
    }

    //���P�b�g�c�����v�Z
    private int RocketNumCaluclation(int level)
    {
        //�ő�c��
        int max = 3;

        //���x���ʂɎc�����v�Z
        for(int i = 1;i < max + 1; i++)
        {
            if(level == i)
            {
                rocketNum = i - 1;
            }
        }
        return rocketNum;
    }
}
