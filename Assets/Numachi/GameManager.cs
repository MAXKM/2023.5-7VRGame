using Meta.WitAi;
using Oculus.Voice.Core.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    //public bool gameStart;

    //�Q�[�����ɏ��������R�C��
    private int currentCoin;

    //�����񐔁A�i���x
    private int _numberOfPlays = 0, _progress = 0;

    [SerializeField] NormalMonitorManager normalMonitorManager;

    [SerializeField] MonitorAppearance monitorAppearance;

    [SerializeField] GameClearManagaer clearManager;
    [SerializeField] GameOverManager gameOverManager;
    [SerializeField] GameInformation gameInformation;
    [SerializeField] HandDetection handDetection;

    WaitForSeconds waitToTitle;

    [SerializeField] public STATE state;

    public bool usableSkill; //���[�U�[�An�b�������g���邩�̔��� <= �{�X��̂ݎg�p�\


    private void Start()
    {
        //usableSkill = false;
        waitToTitle = new WaitForSeconds(5);
        currentCoin = 0;
        SetState(STATE.TITLE);

        //�i���x�A���񐔂����[�h
        _progress = gameInformation.progress;
        _numberOfPlays = gameInformation.numberOfPlays;

        Debug.Log("�����R�C��:" + gameInformation.havingTotalCoin + " �i�s�x:" + gameInformation.progress + " ����:" + gameInformation.numberOfPlays);
    }

    public void SetState(STATE _state)
    {
        //switch���ŏ�ԑJ�ڂ��Ǘ�
        switch (_state)
        {
            //title�̏���
            case STATE.TITLE:

                break;

            //�����̏���
            case STATE.ON_THE_WAY:

                //NormalMonitorManager�ɂ�郂�j�^�[�̐����J�n
                normalMonitorManager.gameObject.SetActive(true);

                break;

            //���{�X�̏���
            case STATE.MIDDLE_BOSS:
                //�����ŉ҂����R�C�����X�V
                currentCoin = normalMonitorManager._currentCoin;

                //HandDetection��L����
                handDetection.enabled = true;

                //Boss���j�^�[�̐���
                monitorAppearance.gameObject.SetActive(true);

                //�X�L���g�p�\
                usableSkill = true;

                break;

            //��{�X�̏���
            case STATE.LAST_BOSS:

                //HandDetection��L����
                handDetection.enabled = true;
                usableSkill = true;

                //Boss���j�^�[�̐���
                monitorAppearance.gameObject.SetActive(true);

                break;

            //�N���A���̏���
            case STATE.CLEAR:

                //HandDetection�̖�����
                handDetection.enabled = false;

                //�N���A�̃e�L�X�g��\��
                clearManager.Coin_Text(currentCoin);

                //�l���R�C���������R�C����
                PlayerPrefs.SetInt("TOTAL_COIN", gameInformation.havingTotalCoin + currentCoin);

                //�i�s�x��i�߂�
                _progress++;
                PlayerPrefs.SetInt("PROGRESS", _progress);

                //���񐔂��J�E���g
                _numberOfPlays++;
                PlayerPrefs.SetInt("NUMBER_OF_PLAYS", _numberOfPlays);
                PlayerPrefs.Save();

                //�^�C�g���փV�[���J��
                StartCoroutine(ToTitle());

                break;

            //�Q�[���I�[�o�[���̏���
            case STATE.GAME_OVER:
                //HandDetection�̖�����
                handDetection.enabled = false;

                //�l���R�C���������R�C����
                PlayerPrefs.SetInt("TOTAL_COIN", gameInformation.havingTotalCoin + currentCoin);

                //���񐔂��J�E���g
                _numberOfPlays++;
                PlayerPrefs.SetInt("NUMBER_OF_PLAYS",  _numberOfPlays);
                PlayerPrefs.Save();

                //�Q�[���I�[�o�[��UI��\��
                gameOverManager.Coin_Text(currentCoin);
                gameOverManager.ButtonDisplay();

                break;
        }
    }

    //5�b�҂��Ă���^�C�g���֖߂�
    IEnumerator ToTitle()
    {
        yield return waitToTitle;
        //clearManager.SceneChange();
        //����
        SceneManager.LoadScene("GameScene");
    }

    //void Update()
    //{
    //    //switch���ŏ�ԑJ�ڂ��Ǘ�
    //    switch (state)
    //    {
    //        //title�̏���
    //        case STATE.TITLE:

    //            //�Q�[���J�n�̍��}���o���ꂽ�瓹���ֈڍs
    //            if (gameStart)
    //            {
    //                state = STATE.ON_THE_WAY;
    //            }

    //            break;

    //        //�����̏���
    //        case STATE.ON_THE_WAY:

    //            //NormalMonitorManager�ɂ�郂�j�^�[�̐����J�n
    //            normalMonitorManager.gameObject.SetActive(true);

    //            //19�̖ڂ�|������{�X��ֈڍs
    //            if(normalMonitorManager.monitorCount == 19)
    //            {
    //                StartCoroutine(ToBossBattle());
    //            }

    //            break;

    //        //���{�X�̏���
    //        case STATE.MIDDLE_BOSS:


    //            //Boss���j�^�[�̐���
    //            monitorAppearance.gameObject.SetActive(true);

    //            //���{�X�Ǘ��̃X�N���v�g���Ăяo���邩�𔻒�
    //            if (monitorAppearance.MBCall)
    //            {
    //                //�󂾂�����Ăяo��
    //                if (middleBoss == null)
    //                {
    //                    middleBoss = GameObject.FindGameObjectWithTag("MB").GetComponent<MIDDLE_BOSS>();
    //                }
    //            }
    //            else
    //            {
    //                //�Ăяo�����ԂɂȂ�܂�return��������
    //                return;
    //            }

    //            usableSkill = true;

    //            //�{�X��|�������𔻒�
    //            if (middleBoss.defeated == 1)
    //            {

    //                state = STATE.CLEAR;
    //            }

    //            else if(middleBoss.defeated == 2)
    //                state = STATE.GAME_OVER;

    //            break;

    //        //��{�X�̏���
    //        case STATE.LAST_BOSS:

    //            usableSkill = true;

    //            break;

    //        //�N���A���̏���
    //        case STATE.CLEAR:

    //            //�N���A�̃e�L�X�g��\��
    //            clearManager.Coin_Text(currentCoin);

    //            //�l���R�C���������R�C����
    //            PlayerPrefs.SetInt("TOTAL_COIN",currentCoin);

    //            //�i�s�x��i�߂�
    //            _progress++;
    //            PlayerPrefs.SetInt("PROGRESS",_progress);

    //            //���񐔂��J�E���g
    //            _numberOfPlays++;
    //            PlayerPrefs.SetInt("NUMBER_OF_PLAYS", _numberOfPlays);
    //            PlayerPrefs.Save();

    //            //�^�C�g���փV�[���J��
    //            clearManager.SceneChange();

    //            break;

    //        //�Q�[���I�[�o�[���̏���
    //        case STATE.GAME_OVER:

    //            //�l���R�C���������R�C����
    //            PlayerPrefs.SetInt("TOTAL_COIN", currentCoin);

    //            //���񐔂��J�E���g
    //            _numberOfPlays++;
    //            PlayerPrefs.SetInt("NUMBER_OF_PLAYS", _numberOfPlays);
    //            PlayerPrefs.Save();

    //            //�Q�[���I�[�o�[��UI��\��
    //            gameOverManager.Coin_Text(currentCoin);
    //            gameOverManager.ButtonDisplay();

    //            break;
    //    }
    //}
}
