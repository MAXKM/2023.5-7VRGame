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
    [SerializeField] SkillEffectManager skillEffectManager;
    [SerializeField] MonitorAppearance monitorAppearance;

    [SerializeField] GameClearManagaer clearManager;
    [SerializeField] GameOverManager gameOverManager;
    [SerializeField] GameInformation gameInformation;
    [SerializeField] HandDetection handDetection;
    [SerializeField] Animator animator;
    [SerializeField] GameObject movie;

    [SerializeField] public STATE state;

    public bool usableSkill; //���[�U�[�An�b�������g���邩�̔��� <= �{�X��̂ݎg�p�\


    private void Start()
    { 
        //usableSkill = false;
        currentCoin = 0;

        //�i���x�A���񐔂����[�h
        _progress = gameInformation.progress;
        _numberOfPlays = gameInformation.numberOfPlays;

        Debug.Log("�����R�C��:" + gameInformation.havingTotalCoin + " �i�s�x:" + gameInformation.progress + " ����:" + gameInformation.numberOfPlays);

        SetState(STATE.TITLE);
    }

    public void SetState(STATE _state)
    {
        //switch���ŏ�ԑJ�ڂ��Ǘ�
        switch (_state)
        {
            //title�̏���
            case STATE.TITLE:
                if (_progress == 0)
                {
                    //���߂ăv���C�����Ƃ������^�C�g���A�j���[�V�������Đ�
                    animator.enabled = true;
                    movie.SetActive(true);
                }
                else
                {
                    animator.enabled = false;
                    movie.SetActive(false);
                }

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

                //n�b�����A���P�b�g�p���`�̃��x�������[�h
                skillEffectManager.SkillLevelLoad();

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

                //n�b�����A���P�b�g�p���`�̃��x�������[�h
                skillEffectManager.SkillLevelLoad();

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
                StartCoroutine(clearManager.SceneChange());

                break;

            //�Q�[���I�[�o�[���̏���
            case STATE.GAME_OVER:
                //HandDetection�̖�����
                handDetection.enabled = false;

                //�l���R�C���������R�C����
                PlayerPrefs.SetInt("TOTAL_COIN", gameInformation.havingTotalCoin + currentCoin);

                //���񐔂��J�E���g
                _numberOfPlays++;
                PlayerPrefs.SetInt("NUMBER_OF_PLAYS", _numberOfPlays);
                PlayerPrefs.Save();

                //�Q�[���I�[�o�[��UI��\��
                gameOverManager.Coin_Text(currentCoin);
                StartCoroutine(gameOverManager.ButtonDisplay());

                break;
        }
    }
}
