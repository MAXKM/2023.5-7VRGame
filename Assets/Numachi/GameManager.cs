using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //�Ǘ�������
    public enum STATE
    {
        TITLE, //�^�C�g��
        ON_THE_WAY, //����
        MIDDLE_BOSS, //���{�X
        LAST_BOSS, //��{�X
        CLEAR, //�Q�[���N���A
        GAME_OVER�@//�Q�[���I�[�o�[
    }

    [SerializeField] NormalMonitorManager normalMonitorManager;

    private STATE state;

    public bool usableSkill; //���[�U�[�An�b�������g���邩�̔��� <= �{�X��̂ݎg�p�\

    private void Start()
    {
        state = STATE.ON_THE_WAY;
        usableSkill = false;
    }

    void Update()
    {
        //switch���ŏ�ԑJ�ڂ��Ǘ�
        switch (state)
        {
            //title�̏���
            case STATE.TITLE:

                break;

            //�����̏���
            case STATE.ON_THE_WAY:
                if(normalMonitorManager.monitorCount == 19)
                {
                    state = STATE.MIDDLE_BOSS;
                }

                break;

            //���{�X�̏���
            case STATE.MIDDLE_BOSS:

                Debug.Log("���{�X����");
                usableSkill = true;

                break;

            //��{�X�̏���
            case STATE.LAST_BOSS:

                usableSkill = true;

                break;

            //�N���A���̏���
            case STATE.CLEAR:

                break;

            //�Q�[���I�[�o�[���̏���
            case STATE.GAME_OVER:

                break;
        }
    }
}
