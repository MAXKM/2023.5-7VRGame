using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    /*
    public float timerCount;
    public GameObject button;
    
    public GameInformation information; //�R�C���̖���
    public GameObject Coin = null;      //�e�L�X�g�I�u�W�F�N�g
    */

     
    [SerializeField] ParticleSystem particle;

    //public void Play()
    //{
     //   particle.Play();
    //}

    // Start is called before the first frame update
    void Start()
    {
        //button.SetActive(false);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //Play();
        particle.IsAlive(true);

        /*
        //�R�C���̒l�l������
        //float Coin_count = 0.0f;
        //Coin_count = information.havingTotalCoin;
        GameObject CoinCount = GameObject.Find("GameInformation");
        information = CoinCount.GetComponent<GameInformation>();

        Debug.Log(information.havingTotalCoin);

        //�I�u�W�F�N�g����Text�R���|�[�l���g���擾
        Text CoinText = Coin.GetComponent<Text>();

        //�e�L�X�g�̕\�������ւ���
        CoinText.text = "�l���R�C�����F" + information.havingTotalCoin;
        */
    }

    /*
    timerCount += Time.deltaTime;
    if (timerCount >= 3.0f)
    {
        ButtonDisplay();
    }
    */
}
    /*
    public void ButtonDisplay()
    {
        button.SetActive(true);
    }
    */

