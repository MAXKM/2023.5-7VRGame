using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameClearManagaer : MonoBehaviour
{
    public GameInformation information; //�R�C���̖���
    public GameObject Coin = null;      //�e�L�X�g�I�u�W�F�N�g

    public float timerCount;

    public void Coin_Text(int coin)
    {
        Coin.SetActive(true);

        //�R�C���̒l�l������
        GameObject CoinCount = GameObject.Find("GameInformation");
        information = CoinCount.GetComponent<GameInformation>();

        Debug.Log(information.havingTotalCoin);

        //�I�u�W�F�N�g����Text�R���|�[�l���g���擾
        TextMeshProUGUI CoinText = Coin.GetComponent<TextMeshProUGUI>();

        //�e�L�X�g�̕\�������ւ���
        //CoinText.text = "�l���R�C�����F" + coin;
        CoinText.text = "Conguraturation!!\n" + "Coin:" + coin;
    }

    public void SceneChange()
    {
        //3�b��������V�[���J��
        timerCount += Time.deltaTime;
        if (timerCount >= 3.0f)
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
