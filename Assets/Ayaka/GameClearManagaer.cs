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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int Coin_count = 0;
        Coin_count = information.havingTotalCoin;

        Debug.Log(Coin_count);

        //3秒立ったらシーン遷移
        timerCount += Time.deltaTime;
        if (timerCount >= 3.0f)
        {
            SceneChange();
        }
        
    }
    void SceneChange()
    {
        SceneManager.LoadScene("StartScene");
    }
}
