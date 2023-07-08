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

    [SerializeField] GameObject[] clearText;
    [SerializeField] ParticleSystem particle;

    [SerializeField] TextMeshProUGUI CoinText;

    public void ParticlePlay()
    {
        particle.IsAlive(true);
    }

    public void Coin_Text(int coin)
    {
        Coin.SetActive(true);
        clearText[0].SetActive(true);

        //�R�C���̒l�l������
        GameObject CoinCount = GameObject.Find("GameInformation");
        information = CoinCount.GetComponent<GameInformation>();

        //Debug.Log(information.havingTotalCoin);

        //�e�L�X�g�̕\�������ւ���
        CoinText.text =  coin + "�R�C���Q�b�g!";
        //CoinText.text = "Conguraturation!!\n" + "Coin:" + coin;
    }

    public void LastClearText()
    {
        clearText[1].SetActive(true);
    }

    public IEnumerator SceneChange(int time)
    {
        //3�b������
        yield return new WaitForSeconds(time);

        //3�b��������̏���
        SceneManager.LoadScene("GameScene");
    }

}
