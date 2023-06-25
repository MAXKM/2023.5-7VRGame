using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public GameInformation information; //�R�C���̖���
    public GameObject Coin = null;      //�e�L�X�g�I�u�W�F�N�g

    public float timerCount;
    public GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        button.SetActive(false);
    }

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
        SceneManager.LoadScene("StartScene");
    }
}
