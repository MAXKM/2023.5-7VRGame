using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public float timerCount;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
