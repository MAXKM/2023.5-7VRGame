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
