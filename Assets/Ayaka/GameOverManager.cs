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

    //�{�^����\��������֐�
    public void OnClickStartButton()
    {
        //�{�^�������ꂽ��V�[���J��
        SceneManager.LoadScene("StartScene");
    }
}
