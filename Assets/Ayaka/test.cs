using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    /*
    public float timerCount;
    public GameObject button;
    */
    public GameInformation information; //コインの枚数
    public GameObject Coin = null;      //テキストオブジェクト

    // Start is called before the first frame update
    void Start()
    {
        //button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //コインの値獲得する
        float Coin_count = 0.0f;
        Coin_count = information.havingTotalCoin;

        Debug.Log(Coin_count);

        //オブジェクトからTextコンポーネントを取得
        Text CoinText = Coin.GetComponent<Text>();

        //テキストの表示を入れ替える
        CoinText.text = "獲得コイン数：" + Coin_count;
        //CoinText.text = "獲得コイン数：00000";
    }

    /*
    timerCount += Time.deltaTime;
    if (timerCount >= 3.0f)
    {
        ButtonDisplay();
    }
    */
}
    /*
    public void ButtonDisplay()
    {
        button.SetActive(true);
    }
    */

