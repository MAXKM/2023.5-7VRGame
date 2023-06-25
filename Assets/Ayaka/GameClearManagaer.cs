using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameClearManagaer : MonoBehaviour
{
    public GameInformation information; //�R�C���̖���
    public GameObject Coin = null;      //�e�L�X�g�I�u�W�F�N�g

    public float timerCount;

    void Coin_Text()
    {
        //�R�C���̒l�l������
        GameObject CoinCount = GameObject.Find("GameInformation");
        information = CoinCount.GetComponent<GameInformation>();

        Debug.Log(information.havingTotalCoin);

        //�I�u�W�F�N�g����Text�R���|�[�l���g���擾
        Text CoinText = Coin.GetComponent<Text>();

        //�e�L�X�g�̕\�������ւ���
        CoinText.text = "�l���R�C�����F" + information.havingTotalCoin;
    }

    void SceneChange()
    {
        //3�b��������V�[���J��
        timerCount += Time.deltaTime;
        if (timerCount >= 3.0f)
        {
            SceneManager.LoadScene("StartScene");
        }
    }
}
