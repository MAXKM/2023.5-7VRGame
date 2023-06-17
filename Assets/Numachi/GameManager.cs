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

    //�Q�[���̊J�n�����}����bool�ϐ�
    public bool gameStart;

    [SerializeField] NormalMonitorManager normalMonitorManager;

    private STATE state;

    public bool usableSkill; //���[�U�[�An�b�������g���邩�̔��� <= �{�X��̂ݎg�p�\

    private void Start()
    {
        state = STATE.TITLE;
        usableSkill = false;
        gameStart = false;
    }

    void Update()
    {
        //switch���ŏ�ԑJ�ڂ��Ǘ�
        switch (state)
        {
            //title�̏���
            case STATE.TITLE:

                //�Q�[���J�n�̍��}���o���ꂽ�瓹���ֈڍs
                if (gameStart)
                {
                    state = STATE.ON_THE_WAY;
                }

                break;

            //�����̏���
            case STATE.ON_THE_WAY:

                //NormalMonitorManager�ɂ�郂�j�^�[�̐����J�n
                normalMonitorManager.gameObject.SetActive(true);

                //19�̖ڂ�|������{�X��ֈڍs
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
        Debug.Log(state);
    }
}
