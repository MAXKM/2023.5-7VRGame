using Oculus.Voice.Core.Utilities;
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

    //�Q�[�����ɏ��������R�C��
    private int currentCoin;

    [SerializeField] NormalMonitorManager normalMonitorManager;

    [SerializeField] MonitorAppearance monitorAppearance;

    [SerializeField] GameClearManagaer clearManager;
    [SerializeField] GameOverManager gameOverManager;
    MIDDLE_BOSS middleBoss;

    WaitForSeconds waitToBoss;

    [SerializeField] private STATE state;

    public bool usableSkill; //���[�U�[�An�b�������g���邩�̔��� <= �{�X��̂ݎg�p�\


    private void Start()
    {
        //state = STATE.TITLE;

        usableSkill = false;
        gameStart = false;
        waitToBoss = new WaitForSeconds(0.5f);
        currentCoin = 0;
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
                    StartCoroutine(ToBossBattle());
                }

                break;

            //���{�X�̏���
            case STATE.MIDDLE_BOSS:
                

                //Boss���j�^�[�̐���
                monitorAppearance.gameObject.SetActive(true);

                //���{�X�Ǘ��̃X�N���v�g���Ăяo���邩�𔻒�
                if (monitorAppearance.MBCall)
                {
                    //�󂾂�����Ăяo��
                    if (middleBoss == null)
                    {
                        middleBoss = GameObject.FindGameObjectWithTag("MB").GetComponent<MIDDLE_BOSS>();
                    }
                }
                else
                {
                    //�Ăяo�����ԂɂȂ�܂�return��������
                    return;
                }

                usableSkill = true;

                //�{�X��|�������𔻒�
                if (middleBoss.defeated == 1)
                {
                
                    state = STATE.CLEAR;
                }
                    
                else if(middleBoss.defeated == 2)
                    state = STATE.GAME_OVER;

                break;

            //��{�X�̏���
            case STATE.LAST_BOSS:

                usableSkill = true;

                break;

            //�N���A���̏���
            case STATE.CLEAR:

                //�N���A�̃e�L�X�g��\��
                clearManager.Coin_Text(currentCoin);

                //�^�C�g���փV�[���J��
                clearManager.SceneChange();

                break;

            //�Q�[���I�[�o�[���̏���
            case STATE.GAME_OVER:

                //�Q�[���I�[�o�[��UI��\��
                gameOverManager.Coin_Text(currentCoin);
                gameOverManager.ButtonDisplay();

                break;
        }
    }



    //0.5�b�҂��Ă���{�X�֑J��
    IEnumerator ToBossBattle()
    {
        yield return waitToBoss;
        state = STATE.MIDDLE_BOSS;

        //�����ŉ҂����R�C�����擾
        currentCoin = normalMonitorManager._currentCoin;
    }
}
