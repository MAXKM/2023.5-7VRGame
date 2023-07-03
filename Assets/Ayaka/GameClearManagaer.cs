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

    [SerializeField] ParticleSystem particle;

    public void ParticlePlay()
    {
        particle.IsAlive(true);
    }

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

    IEnumerator SceneChange()
    {
        //3秒数える
        yield return new WaitForSeconds(3.0f);

        //3秒立った後の処理
        SceneManager.LoadScene("GameScene");
    }

}
