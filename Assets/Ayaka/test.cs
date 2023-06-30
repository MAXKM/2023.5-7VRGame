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
    
    public GameInformation information; //コインの枚数
    public GameObject Coin = null;      //テキストオブジェクト
    */

     
    [SerializeField] ParticleSystem particle;

    //public void Play()
    //{
     //   particle.Play();
    //}

    // Start is called before the first frame update
    void Start()
    {
        //button.SetActive(false);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //Play();
        particle.IsAlive(true);

        /*
        //コインの値獲得する
        //float Coin_count = 0.0f;
        //Coin_count = information.havingTotalCoin;
        GameObject CoinCount = GameObject.Find("GameInformation");
        information = CoinCount.GetComponent<GameInformation>();

        Debug.Log(information.havingTotalCoin);

        //オブジェクトからTextコンポーネントを取得
        Text CoinText = Coin.GetComponent<Text>();

        //テキストの表示を入れ替える
        CoinText.text = "獲得コイン数：" + information.havingTotalCoin;
        */
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

