using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public GameInformation information; //�R�C���̖���

    public GameObject Coin;
    public GameObject button;

    public float timerCount;
    public GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    public void Coin_Text(int coin)
    {
        gameOverPanel.SetActive(true);

        //�R�C���̒l�l������
        GameObject CoinCount = GameObject.Find("GameInformation");
        information = CoinCount.GetComponent<GameInformation>();

        //Debug.Log(information.havingTotalCoin);

        //�I�u�W�F�N�g����Text�R���|�[�l���g���擾
        TextMeshProUGUI CoinText = Coin.GetComponent<TextMeshProUGUI>();

        //�e�L�X�g�̕\�������ւ���
        //CoinText.text = "�l���R�C�����F" + coin;
        CoinText.text = "GameOver\n" + "Coin:" + coin;
    }

    public void ButtonDisplay()
    {
        timerCount += Time.deltaTime;
        if (timerCount >= 3.0f)
        {
            button.SetActive(true);
        }
    }

    //�{�^����\��������֐�
    public void OnClickStartButton()
    {
        //�{�^�������ꂽ��V�[���J��
        SceneManager.LoadScene("GameScene");
    }
}
