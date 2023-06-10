using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkillEffectManager : MonoBehaviour
{
    [SerializeField] HandDetection handDetection;

    //���E������MeshRenderer
    [SerializeField] MeshRenderer meshRendererR,meshRendererL;

    //n�b������Ԏ��̃}�e���A��
    [SerializeField] Material strengthenColor,normalColor;

    //n�b�������̕b��
    [SerializeField] TextMeshProUGUI timeText;

    //�c��b��
    float reminingSeconds = 0;

    //���x���ʐ�������
    float limitSeconds = 1.5f;

    private void Start()
    {
        timeText.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (handDetection.strengthenMode)
        {
            //���Ԍv���J�n
            reminingSeconds += Time.deltaTime;

            //������ԊJ�n
            StartStrengthenMode();

            //�e�L�X�g��\��
            DisplayTimeText(handDetection.strengthenMode);
        }

        if(limitSeconds - reminingSeconds <= 0)
        {
            //0�b�ɂȂ����狭����ԏI��
            handDetection.strengthenMode = false;
            FinishStregnthenMode();

            //�e�L�X�g���\��
            DisplayTimeText(handDetection.strengthenMode);
        }
    }

    void DisplayTimeText(bool strMode)
    {
        timeText.gameObject.SetActive(strMode);
        timeText.text = reminingSeconds.ToString("n2");
    }

    //������Ԃ̏���
    void StartStrengthenMode()
    {
        //�����ԂɕύX
        meshRendererL.material = strengthenColor;
        meshRendererR.material = strengthenColor;
    }

    //������ԏI���̏���
    void FinishStregnthenMode()
    {
        //����𔒂ɕύX
        meshRendererL.material = normalColor;
        meshRendererR.material = normalColor;
    }
}
