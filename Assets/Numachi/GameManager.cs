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
    public bool gameStart;

    [SerializeField] NormalMonitorManager normalMonitorManager;

    private STATE state;

    public bool usableSkill; //レーザー、n秒強化が使えるかの判定 <= ボス戦のみ使用可能

    private void Start()
    {
        state = STATE.TITLE;
        usableSkill = false;
        gameStart = false;
    }

    void Update()
    {
        //switch分で状態遷移を管理
        switch (state)
        {
            //titleの処理
            case STATE.TITLE:

                //ゲーム開始の合図が出されたら道中へ移行
                if (gameStart)
                {
                    state = STATE.ON_THE_WAY;
                }

                break;

            //道中の処理
            case STATE.ON_THE_WAY:

                //NormalMonitorManagerによるモニターの生成開始
                normalMonitorManager.gameObject.SetActive(true);

                //19体目を倒したらボス戦へ移行
                if(normalMonitorManager.monitorCount == 19)
                {
                    state = STATE.MIDDLE_BOSS;
                }

                break;

            //中ボスの処理
            case STATE.MIDDLE_BOSS:

                Debug.Log("中ボスだよ");
                usableSkill = true;

                break;

            //大ボスの処理
            case STATE.LAST_BOSS:

                usableSkill = true;

                break;

            //クリア時の処理
            case STATE.CLEAR:

                break;

            //ゲームオーバー時の処理
            case STATE.GAME_OVER:

                break;
        }
        Debug.Log(state);
    }
}
