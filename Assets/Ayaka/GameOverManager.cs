using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public GameInformation information; //コインの枚数

    public GameObject Coin;
    public GameObject button;

    public float timerCount;
    public GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    public void Coin_Text(int coin)
    {
        gameOverPanel.SetActive(true);

        //コインの値獲得する
        GameObject CoinCount = GameObject.Find("GameInformation");
        information = CoinCount.GetComponent<GameInformation>();

        //Debug.Log(information.havingTotalCoin);

        //オブジェクトからTextコンポーネントを取得
        TextMeshProUGUI CoinText = Coin.GetComponent<TextMeshProUGUI>();

        //テキストの表示を入れ替える
        //CoinText.text = "獲得コイン数：" + coin;
        CoinText.text = "GameOver\n" + "Coin:" + coin;
    }

    public void ButtonDisplay()
    {
        timerCount += Time.deltaTime;
        if (timerCount >= 3.0f)
        {
            button.SetActive(true);
        }
    }

    //ボタンを表示させる関数
    public void OnClickStartButton()
    {
        //ボタン押されたらシーン遷移
        SceneManager.LoadScene("GameScene");
    }
}
