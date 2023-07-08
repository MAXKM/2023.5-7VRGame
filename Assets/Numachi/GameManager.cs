using Meta.WitAi;
using Oculus.Voice.Core.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //管理する状態
    public enum STATE
    {
        TITLE, //タイトル
        ON_THE_WAY, //道中
        MIDDLE_BOSS, //中ボス
        LAST_BOSS, //大ボス
        CLEAR, //ゲームクリア
        GAME_OVER　//ゲームオーバー
    }

    //ゲームの開始を合図するbool変数
    //public bool gameStart;

    //ゲーム中に所持したコイン
    private int currentCoin;

    //総周回数、進捗度
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

    [SerializeField] ParticleSystem lightParticle;

    [SerializeField] public STATE state;

    public bool usableSkill; //レーザー、n秒強化が使えるかの判定 <= ボス戦のみ使用可能


    private void Start()
    { 
        usableSkill = false;
        currentCoin = 0;

        //進捗度、周回数をロード
        _progress = gameInformation.progress;
        _numberOfPlays = gameInformation.numberOfPlays;

        Debug.Log("所持コイン:" + gameInformation.havingTotalCoin + " 進行度:" + gameInformation.progress + " 周回数:" + gameInformation.numberOfPlays);

        SetState(STATE.TITLE);
    }

    public void SetState(STATE _state)
    {
        //switch分で状態遷移を管理
        switch (_state)
        {
            //titleの処理
            case STATE.TITLE:
                if (_progress == 0)
                {
                    //初めてプレイしたときだけタイトルアニメーションを再生
                    animator.enabled = true;
                    movie.SetActive(true);
                }
                else
                {
                    animator.enabled = false;
                    movie.SetActive(false);
                }

                break;

            //道中の処理
            case STATE.ON_THE_WAY:

                //NormalMonitorManagerによるモニターの生成開始
                normalMonitorManager.gameObject.SetActive(true);

                break;

            //中ボスの処理
            case STATE.MIDDLE_BOSS:
                //道中で稼いだコインを更新
                currentCoin = normalMonitorManager._currentCoin;

                //n秒強化、ロケットパンチのレベルをロード
                skillEffectManager.SkillLevelLoad();

                //HandDetectionを有効化
                handDetection.enabled = true;

                //Bossモニターの生成
                monitorAppearance.gameObject.SetActive(true);

                break;

            //大ボスの処理
            case STATE.LAST_BOSS:

                //HandDetectionを有効化
                handDetection.enabled = true;

                //n秒強化、ロケットパンチのレベルをロード
                skillEffectManager.SkillLevelLoad();

                //Bossモニターの生成
                monitorAppearance.gameObject.SetActive(true);

                break;

            //クリア時の処理
            case STATE.CLEAR:

                usableSkill = false;

                //HandDetectionの無効化
                handDetection.enabled = false;

                //獲得コインを所持コインへ
                PlayerPrefs.SetInt("TOTAL_COIN", gameInformation.havingTotalCoin + currentCoin);

                //進行度を進める
                _progress++;
                PlayerPrefs.SetInt("PROGRESS", _progress);

                //周回数をカウント
                _numberOfPlays++;
                PlayerPrefs.SetInt("NUMBER_OF_PLAYS", _numberOfPlays);
                PlayerPrefs.Save();

                //ラスボス(4体目のボス)を倒したら特殊演出
                if(_progress == 4)
                {
                    lightParticle.Play();
                }

                //クリアのテキストを表示
                clearManager.Coin_Text(currentCoin);

                //タイトルへシーン遷移
                StartCoroutine(clearManager.SceneChange());

                break;

            //ゲームオーバー時の処理
            case STATE.GAME_OVER:
                usableSkill = false;

                //HandDetectionの無効化
                handDetection.enabled = false;

                //獲得コインを所持コインへ
                PlayerPrefs.SetInt("TOTAL_COIN", gameInformation.havingTotalCoin + currentCoin);

                //周回数をカウント
                _numberOfPlays++;
                PlayerPrefs.SetInt("NUMBER_OF_PLAYS", _numberOfPlays);
                PlayerPrefs.Save();

                //ゲームオーバーのUIを表示
                gameOverManager.Coin_Text(currentCoin);
                StartCoroutine(gameOverManager.ButtonDisplay());

                break;
        }
    }
}
