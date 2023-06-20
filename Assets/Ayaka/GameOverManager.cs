using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject button;

    //ボタンを表示させる関数
    public void OnClickStartButton()
    {
        //ボタン押されたらシーン遷移
        SceneManager.LoadScene("StartScene");
    }
}
