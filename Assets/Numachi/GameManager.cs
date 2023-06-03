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

    [SerializeField] NormalMonitorManager normalMonitorManager;

    private STATE state;

    public bool usableSkill; //レーザー、n秒強化が使えるかの判定 <= ボス戦のみ使用可能

    private void Start()
    {
        state = STATE.ON_THE_WAY;
        usableSkill = false;
    }

    void Update()
    {
        //switch分で状態遷移を管理
        switch (state)
        {
            //titleの処理
            case STATE.TITLE:

                break;

            //道中の処理
            case STATE.ON_THE_WAY:
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
    }
}
