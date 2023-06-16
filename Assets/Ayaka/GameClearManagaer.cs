using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClearManagaer : MonoBehaviour
{
    public float timerCount;

    public GameInformation information;
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

        //3•b—§‚Á‚½‚çƒV[ƒ“‘JˆÚ
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
