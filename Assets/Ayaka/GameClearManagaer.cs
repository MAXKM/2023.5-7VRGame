using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameClearManagaer : MonoBehaviour
{
    public GameInformation information; //コインの枚数
    public GameObject Coin = null;      //テキストオブジェクト

    public float timerCount;

    void Coin_Text()
    {
        //コインの値獲得する
        GameObject CoinCount = GameObject.Find("GameInformation");
        information = CoinCount.GetComponent<GameInformation>();

        Debug.Log(information.havingTotalCoin);

        //オブジェクトからTextコンポーネントを取得
        Text CoinText = Coin.GetComponent<Text>();

        //テキストの表示を入れ替える
        CoinText.text = "獲得コイン数：" + information.havingTotalCoin;
    }

    void SceneChange()
    {
        //3秒立ったらシーン遷移
        timerCount += Time.deltaTime;
        if (timerCount >= 3.0f)
        {
            SceneManager.LoadScene("StartScene");
        }
    }
}
