using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameClearManagaer : MonoBehaviour
{
    public GameInformation information; //コインの枚数
    public GameObject Coin = null;      //テキストオブジェクト

    public float timerCount;

    public void Coin_Text(int coin)
    {
        Coin.SetActive(true);

        //コインの値獲得する
        GameObject CoinCount = GameObject.Find("GameInformation");
        information = CoinCount.GetComponent<GameInformation>();

        Debug.Log(information.havingTotalCoin);

        //オブジェクトからTextコンポーネントを取得
        TextMeshProUGUI CoinText = Coin.GetComponent<TextMeshProUGUI>();

        //テキストの表示を入れ替える
        //CoinText.text = "獲得コイン数：" + coin;
        CoinText.text = "Conguraturation!!\n" + "Coin:" + coin;
    }

    public void SceneChange()
    {
        //3秒立ったらシーン遷移
        timerCount += Time.deltaTime;
        if (timerCount >= 3.0f)
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
