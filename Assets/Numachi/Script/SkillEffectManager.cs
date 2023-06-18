using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkillEffectManager : MonoBehaviour
{
    [SerializeField] HandDetection handDetection;

    [SerializeField] GameInformation gameInformation;

    [SerializeField] SkillManager skillManager;

    //���E������MeshRenderer
    [SerializeField] MeshRenderer meshRendererR,meshRendererL;

    //n�b������Ԏ��̃}�e���A��
    [SerializeField] Material strengthenColor,normalColor;

    //n�b�������̕b��
    [SerializeField] TextMeshProUGUI timeText,rocketText;

    //�c��b��
    private float reminingSeconds = 0;

    //���x���ʐ�������
    private float limitSeconds;

    //���x���ʃ��P�b�g�c��
    private int rocketNum;

    //Update�֐����Ŏc����1�������炷���߂̃t���O�ϐ�
    private bool isDecrease = false;

    private void Start()
    {
        //������Ԃ̓e�L�X�g���\��
        timeText.gameObject.SetActive(false);
        rocketText.gameObject.SetActive(false);

        //���x���ʐ������Ԃ��擾
        limitSeconds = skillManager.PowerTimeLimit(gameInformation.powerUpTimeLevel);

        //���P�b�g�̎c�����v�Z
        rocketNum = RocketNumCaluclation(gameInformation.rocketNumLevel);
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

        if (handDetection.rocketMode)
        {
            RocketLaunch();
        }
        else
        {
            isDecrease = false;
        }
        Debug.Log(rocketNum);
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
        //�����ԂɕύX
        meshRendererL.material = strengthenColor;
        meshRendererR.material = strengthenColor;
    }

    //������ԏI���̏���
    private void FinishStregnthenMode()
    {
        //����𔒂ɕύX
        meshRendererL.material = normalColor;
        meshRendererR.material = normalColor;
    }

    //���x���ʂ̐������Ԃ��v�Z
    //private float LimitTimeCalculation(int level)
    //{
    //    //���x���ʂɐ������Ԃ��v�Z
    //    switch (level)
    //    {
    //        case 1:
    //            limitSeconds = 0;
    //            break;
    //        case 2:
    //            limitSeconds = 1.5f;
    //            break;
    //        case 3:
    //            limitSeconds = 3f;
    //            break;
    //        case 4:
    //            limitSeconds = 4.5f;
    //            break;
    //        case 5:
    //            limitSeconds = 6f;
    //            break;
    //    }

    //    return limitSeconds;
    //}

    //���P�b�g����
    private void RocketLaunch()
    {
        //�c����0�������甭�����Ȃ�
        if(rocketNum <= 0)
        {
            return;
        }

        //���P�b�g��������
        rocketText.gameObject.SetActive(true);
        rocketText.text = "Rocket!!";

        //�c�������炷
        if (!isDecrease)
        {
            isDecrease = true;
            rocketNum--;
        }

        //���P�b�g��Ԃ��~�i�e�X�g�j
        StartCoroutine(RocketTest());
    }

    //�e�X�g�p
    IEnumerator RocketTest()
    {
        yield return new WaitForSeconds(3f);
        rocketText.gameObject.SetActive(false);
        handDetection.rocketMode = false;
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
