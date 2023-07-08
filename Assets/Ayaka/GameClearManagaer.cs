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

    [SerializeField] GameObject[] clearText;
    [SerializeField] ParticleSystem particle;

    [SerializeField] TextMeshProUGUI CoinText;

    public void ParticlePlay()
    {
        particle.IsAlive(true);
    }

    public void Coin_Text(int coin)
    {
        Coin.SetActive(true);
        clearText[0].SetActive(true);

        //コインの値獲得する
        GameObject CoinCount = GameObject.Find("GameInformation");
        information = CoinCount.GetComponent<GameInformation>();

        //Debug.Log(information.havingTotalCoin);

        //テキストの表示を入れ替える
        CoinText.text =  coin + "コインゲット!";
        //CoinText.text = "Conguraturation!!\n" + "Coin:" + coin;
    }

    public void LastClearText()
    {
        clearText[1].SetActive(true);
    }

    public IEnumerator SceneChange(int time)
    {
        //3秒数える
        yield return new WaitForSeconds(time);

        //3秒立った後の処理
        SceneManager.LoadScene("GameScene");
    }

}
