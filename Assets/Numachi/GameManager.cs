using Meta.WitAi;
using Oculus.Voice.Core.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [SerializeField] MonitorAppearance monitorAppearance;

    [SerializeField] GameClearManagaer clearManager;
    [SerializeField] GameOverManager gameOverManager;
    [SerializeField] GameInformation gameInformation;

    MIDDLE_BOSS middleBoss;

    WaitForSeconds waitToBoss;

    [SerializeField] public STATE state;

    public bool usableSkill; //レーザー、n秒強化が使えるかの判定 <= ボス戦のみ使用可能


    private void Start()
    {
        usableSkill = false;
        //gameStart = false;
        waitToBoss = new WaitForSeconds(0.5f);
        currentCoin = 0;
        gameInformation.havingTotalCoin = gameInformation.Refresh("TOTAL_COIN");
        SetState(STATE.TITLE);
    }

    public void SetState(STATE _state)
    {
        //switch分で状態遷移を管理
        switch (_state)
        {
            //titleの処理
            case STATE.TITLE:

                break;

            //道中の処理
            case STATE.ON_THE_WAY:

                //NormalMonitorManagerによるモニターの生成開始
                normalMonitorManager.gameObject.SetActive(true);

                //19体目を倒したらボス戦へ移行
                if (normalMonitorManager.monitorCount == 19)
                {
                    StartCoroutine(ToBossBattle());
                }

                break;

            //中ボスの処理
            case STATE.MIDDLE_BOSS:


                //Bossモニターの生成
                monitorAppearance.gameObject.SetActive(true);

                //中ボス管理のスクリプトを呼び出せるかを判定
                if (monitorAppearance.MBCall)
                {
                    //空だったら呼び出す
                    if (middleBoss == null)
                    {
                        middleBoss = GameObject.FindGameObjectWithTag("MB").GetComponent<MIDDLE_BOSS>();
                    }
                }
                else
                {
                    //呼び出せる状態になるまでreturnし続ける
                    return;
                }

                usableSkill = true;

                //ボスを倒したかを判定
                
                /*if (middleBoss.defeated == 1)
                {

                    state = STATE.CLEAR;
                }

                else if (middleBoss.defeated == 2)
                    state = STATE.GAME_OVER;
                */
                break;

            //大ボスの処理
            case STATE.LAST_BOSS:

                usableSkill = true;

                break;

            //クリア時の処理
            case STATE.CLEAR:

                //クリアのテキストを表示
                clearManager.Coin_Text(currentCoin);

                //獲得コインを所持コインへ
                PlayerPrefs.SetInt("TOTAL_COIN", currentCoin);

                //進行度を進める
                _progress++;
                PlayerPrefs.SetInt("PROGRESS", _progress);

                //周回数をカウント
                _numberOfPlays++;
                PlayerPrefs.SetInt("NUMBER_OF_PLAYS", _numberOfPlays);
                PlayerPrefs.Save();

                //タイトルへシーン遷移
                clearManager.SceneChange();

                break;

            //ゲームオーバー時の処理
            case STATE.GAME_OVER:

                //獲得コインを所持コインへ
                PlayerPrefs.SetInt("TOTAL_COIN", currentCoin);

                //周回数をカウント
                _numberOfPlays++;
                PlayerPrefs.SetInt("NUMBER_OF_PLAYS", _numberOfPlays);
                PlayerPrefs.Save();

                //ゲームオーバーのUIを表示
                gameOverManager.Coin_Text(currentCoin);
                gameOverManager.ButtonDisplay();

                break;
        }
    }

    //void Update()
    //{
    //    //switch分で状態遷移を管理
    //    switch (state)
    //    {
    //        //titleの処理
    //        case STATE.TITLE:

    //            //ゲーム開始の合図が出されたら道中へ移行
    //            if (gameStart)
    //            {
    //                state = STATE.ON_THE_WAY;
    //            }

    //            break;

    //        //道中の処理
    //        case STATE.ON_THE_WAY:

    //            //NormalMonitorManagerによるモニターの生成開始
    //            normalMonitorManager.gameObject.SetActive(true);

    //            //19体目を倒したらボス戦へ移行
    //            if(normalMonitorManager.monitorCount == 19)
    //            {
    //                StartCoroutine(ToBossBattle());
    //            }

    //            break;

    //        //中ボスの処理
    //        case STATE.MIDDLE_BOSS:


    //            //Bossモニターの生成
    //            monitorAppearance.gameObject.SetActive(true);

    //            //中ボス管理のスクリプトを呼び出せるかを判定
    //            if (monitorAppearance.MBCall)
    //            {
    //                //空だったら呼び出す
    //                if (middleBoss == null)
    //                {
    //                    middleBoss = GameObject.FindGameObjectWithTag("MB").GetComponent<MIDDLE_BOSS>();
    //                }
    //            }
    //            else
    //            {
    //                //呼び出せる状態になるまでreturnし続ける
    //                return;
    //            }

    //            usableSkill = true;

    //            //ボスを倒したかを判定
    //            if (middleBoss.defeated == 1)
    //            {

    //                state = STATE.CLEAR;
    //            }

    //            else if(middleBoss.defeated == 2)
    //                state = STATE.GAME_OVER;

    //            break;

    //        //大ボスの処理
    //        case STATE.LAST_BOSS:

    //            usableSkill = true;

    //            break;

    //        //クリア時の処理
    //        case STATE.CLEAR:

    //            //クリアのテキストを表示
    //            clearManager.Coin_Text(currentCoin);

    //            //獲得コインを所持コインへ
    //            PlayerPrefs.SetInt("TOTAL_COIN",currentCoin);

    //            //進行度を進める
    //            _progress++;
    //            PlayerPrefs.SetInt("PROGRESS",_progress);

    //            //周回数をカウント
    //            _numberOfPlays++;
    //            PlayerPrefs.SetInt("NUMBER_OF_PLAYS", _numberOfPlays);
    //            PlayerPrefs.Save();

    //            //タイトルへシーン遷移
    //            clearManager.SceneChange();

    //            break;

    //        //ゲームオーバー時の処理
    //        case STATE.GAME_OVER:

    //            //獲得コインを所持コインへ
    //            PlayerPrefs.SetInt("TOTAL_COIN", currentCoin);

    //            //周回数をカウント
    //            _numberOfPlays++;
    //            PlayerPrefs.SetInt("NUMBER_OF_PLAYS", _numberOfPlays);
    //            PlayerPrefs.Save();

    //            //ゲームオーバーのUIを表示
    //            gameOverManager.Coin_Text(currentCoin);
    //            gameOverManager.ButtonDisplay();

    //            break;
    //    }
    //}

    //0.5秒待ってからボスへ遷移
    IEnumerator ToBossBattle()
    {
        yield return waitToBoss;
        state = STATE.MIDDLE_BOSS;

        //道中で稼いだコインを取得
        currentCoin = normalMonitorManager._currentCoin;
    }
}
