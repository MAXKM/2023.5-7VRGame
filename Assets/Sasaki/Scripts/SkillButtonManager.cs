using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillButtonManager : MonoBehaviour
{
    [SerializeField] GameInformation gameInformation;
    [SerializeField] SkillManager skillManager;
    [SerializeField] PlayerManager playerManagerL;      //左グローブのPlayerManagerスクリプト
    [SerializeField] PlayerManager playerManagerR;      //右グローブのPlayerManagerスクリプト
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] TextMeshProUGUI text2;
    private Image mImage;
    public Sprite[] Ssprite;
    public int ButtonNumber;
    private string[] SkillName = { "Coinup", "GoldEnemy", "BossTime", "RocketM", "Powerup", "PowerupTime", "RocketNum", "WeakNum", "WeakPointM" };
    private string[] PleaseCoin = { "90", "350", "1200", "1200", "300", "2000", "400", "800", "0"};
    private int i;
    public bool ResetButton;
    private AudioSource pinpon;
    // Start is called before the first frame update
    void Start()
    {
        mImage = GetComponent<Image>();
        pinpon = GetComponent<AudioSource>();
        if (ResetButton == true)
        {
            PlayerPrefs.DeleteKey(SkillName[ButtonNumber]);
        }
        Road();
        text.text= "Coin:" + gameInformation.havingTotalCoin;
    }

    // Update is called once per frame
    //void Update()
    //{

    //}

    private void Road()
    {
        if (ButtonNumber == 0)
        {
            gameInformation.coinUpLevel = PlayerPrefs.GetInt(SkillName[0], 5);  //変更1→5にすることでセーブデータがない時、レベル５
            mImage.sprite = Ssprite[gameInformation.coinUpLevel - 1];
            text2.text = PleaseCoin[gameInformation.coinUpLevel-1];
            if (gameInformation.coinUpLevel == 5)
            {
                text2.text = "MAX";
            }
        }

        if (ButtonNumber == 1)
        {
            gameInformation.goldEnemyProbabilityLevel = PlayerPrefs.GetInt(SkillName[1], 5);
            mImage.sprite = Ssprite[gameInformation.goldEnemyProbabilityLevel - 1];
            text2.text =PleaseCoin[gameInformation.goldEnemyProbabilityLevel - 1];
            if (gameInformation.goldEnemyProbabilityLevel == 5)
            {
                text2.text = "MAX";
            }
        }

        if (ButtonNumber == 2)
        {
            gameInformation.bossBattleTimeLevel = PlayerPrefs.GetInt(SkillName[2], 5);
            mImage.sprite = Ssprite[gameInformation.bossBattleTimeLevel - 1];
            text2.text = PleaseCoin[gameInformation.bossBattleTimeLevel - 1];
            if (gameInformation.bossBattleTimeLevel == 5)
            {
                text2.text = "MAX";
            }
        }

        if (ButtonNumber == 3)
        {
            gameInformation.rocketMagnificationLevel = PlayerPrefs.GetInt(SkillName[3], 5);
            mImage.sprite = Ssprite[gameInformation.rocketMagnificationLevel - 1];
            skillManager.RSLevel(4);
            text2.text = PleaseCoin[gameInformation.rocketMagnificationLevel - 1];
            if (gameInformation.rocketMagnificationLevel == 5)
            {
                text2.text = "MAX";
            }
        }

        if (ButtonNumber == 4)
        {
            gameInformation.powerUpLevel = PlayerPrefs.GetInt(SkillName[4], 5);
            mImage.sprite = Ssprite[gameInformation.powerUpLevel - 1];
            playerManagerL.SScale(gameInformation.powerUpLevel);        //左グローブのサイズ変更の関数を呼び出す
            playerManagerR.SScale(gameInformation.powerUpLevel);        //右グローブのサイズ変更の関数を呼び出す
            skillManager.RSLevel(1);
            text2.text = PleaseCoin[gameInformation.powerUpLevel - 1];
            if (gameInformation.powerUpLevel == 5)
            {
                text2.text = "MAX";
            }

        }

        if (ButtonNumber == 5)
        {
            gameInformation.powerUpTimeLevel = PlayerPrefs.GetInt(SkillName[5], 5);
            mImage.sprite = Ssprite[gameInformation.powerUpTimeLevel - 1];
            skillManager.RSLevel(2);
            text2.text = PleaseCoin[gameInformation.powerUpTimeLevel - 1];
            if (gameInformation.powerUpTimeLevel == 5)
            {
                text2.text = "MAX";
            }
        }

        if (ButtonNumber == 6)
        {
            gameInformation.rocketNumLevel = PlayerPrefs.GetInt(SkillName[6], 3);
            mImage.sprite = Ssprite[gameInformation.rocketNumLevel - 1];
            text2.text = PleaseCoin[gameInformation.rocketNumLevel + 5];
            if (gameInformation.rocketNumLevel == 3)
            {
                text2.text = "MAX";
            }
        }

        if (ButtonNumber == 7)
        {
            gameInformation.weakPointNumLevel = PlayerPrefs.GetInt(SkillName[7], 3);
            mImage.sprite = Ssprite[gameInformation.weakPointNumLevel - 1];
            text2.text = PleaseCoin[gameInformation.weakPointNumLevel + 3];
            if (gameInformation.weakPointNumLevel == 3)
            {
                text2.text = "MAX";
            }
        }
        if (ButtonNumber == 8)
        {
            gameInformation.weakPointMagnificationLevel = PlayerPrefs.GetInt(SkillName[8], 5);
            mImage.sprite = Ssprite[gameInformation.weakPointMagnificationLevel - 1];
            skillManager.RSLevel(3);
            text2.text = PleaseCoin[gameInformation.weakPointMagnificationLevel - 1];
            if (gameInformation.weakPointMagnificationLevel == 5)
            {
                text2.text = "MAX";
            }
        }

    }

    public void OnClick(string button)
    {
        pinpon.PlayOneShot(pinpon.clip);
        switch (button)
        {
            case "Coinup":
                if (gameInformation.coinUpLevel == 1 && gameInformation.havingTotalCoin >= 90)
                {
                    gameInformation.coinUpLevel = 2;
                    gameInformation.havingTotalCoin = gameInformation.havingTotalCoin - 90;
                    mImage.sprite = Ssprite[1];
                    Debug.Log(1);
                }
                else if (gameInformation.coinUpLevel == 2 && gameInformation.havingTotalCoin >= 350)
                {
                    gameInformation.coinUpLevel = 3;
                    gameInformation.havingTotalCoin = gameInformation.havingTotalCoin - 350;
                    mImage.sprite = Ssprite[2];
                }
                else if (gameInformation.coinUpLevel == 3 && gameInformation.havingTotalCoin >= 1200)
                {
                    gameInformation.coinUpLevel = 4;
                    gameInformation.havingTotalCoin = gameInformation.havingTotalCoin - 1200;
                    mImage.sprite = Ssprite[3];
                }
                else if (gameInformation.coinUpLevel == 4 && gameInformation.havingTotalCoin >= 1200)
                {
                    gameInformation.coinUpLevel = 5;
                    gameInformation.havingTotalCoin = gameInformation.havingTotalCoin - 1200;
                    mImage.sprite = Ssprite[4];
                }
                PlayerPrefs.SetInt(SkillName[0], gameInformation.coinUpLevel);

                text2.text =  PleaseCoin[gameInformation.coinUpLevel - 1];
                if (gameInformation.coinUpLevel == 5)
                {
                    text2.text = "MAX";
                }
                break;
            case "GoldEnemy":
                if (gameInformation.goldEnemyProbabilityLevel == 1 && gameInformation.havingTotalCoin >= 90)
                {
                    gameInformation.goldEnemyProbabilityLevel = 2;
                    gameInformation.havingTotalCoin = gameInformation.havingTotalCoin - 90;
                    mImage.sprite = Ssprite[1];
                }
                else if (gameInformation.goldEnemyProbabilityLevel == 2 && gameInformation.havingTotalCoin >= 350)
                {
                    gameInformation.goldEnemyProbabilityLevel = 3;
                    gameInformation.havingTotalCoin = gameInformation.havingTotalCoin - 350;
                    mImage.sprite = Ssprite[2];
                }
                else if (gameInformation.goldEnemyProbabilityLevel == 3 && gameInformation.havingTotalCoin >= 1200)
                {
                    gameInformation.goldEnemyProbabilityLevel = 4;
                    gameInformation.havingTotalCoin = gameInformation.havingTotalCoin - 1200;
                    mImage.sprite = Ssprite[3];
                }
                else if (gameInformation.goldEnemyProbabilityLevel == 4 && gameInformation.havingTotalCoin >= 1200)
                {
                    gameInformation.goldEnemyProbabilityLevel = 5;
                    gameInformation.havingTotalCoin = gameInformation.havingTotalCoin - 1200;
                    mImage.sprite = Ssprite[4];
                }
                PlayerPrefs.SetInt(SkillName[1], gameInformation.goldEnemyProbabilityLevel);

                text2.text = PleaseCoin[gameInformation.goldEnemyProbabilityLevel - 1];
                if (gameInformation.goldEnemyProbabilityLevel == 5)
                {
                    text2.text = "MAX";
                }
                break;
            case "BossTime":
                if (gameInformation.bossBattleTimeLevel == 1 && gameInformation.havingTotalCoin >= 90)
                {
                    gameInformation.bossBattleTimeLevel = 2;
                    gameInformation.havingTotalCoin = gameInformation.havingTotalCoin - 90;
                    mImage.sprite = Ssprite[1];
                }
                else if (gameInformation.bossBattleTimeLevel == 2 && gameInformation.havingTotalCoin >= 350)
                {
                    gameInformation.bossBattleTimeLevel = 3;
                    gameInformation.havingTotalCoin = gameInformation.havingTotalCoin - 350;
                    mImage.sprite = Ssprite[2];
                }
                else if (gameInformation.bossBattleTimeLevel == 3 && gameInformation.havingTotalCoin >= 1200)
                {
                    gameInformation.bossBattleTimeLevel = 4;
                    gameInformation.havingTotalCoin = gameInformation.havingTotalCoin - 1200;
                    mImage.sprite = Ssprite[3];
                }
                else if (gameInformation.bossBattleTimeLevel == 4 && gameInformation.havingTotalCoin >= 1200)
                {
                    gameInformation.bossBattleTimeLevel = 5;
                    gameInformation.havingTotalCoin = gameInformation.havingTotalCoin - 1200;
                    mImage.sprite = Ssprite[4];
                }
                PlayerPrefs.SetInt(SkillName[2], gameInformation.bossBattleTimeLevel);

                text2.text = PleaseCoin[gameInformation.bossBattleTimeLevel - 1];
                if (gameInformation.bossBattleTimeLevel == 5)
                {
                    text2.text = "MAX";
                }
                break;
            case "RocketM":
                if (gameInformation.rocketMagnificationLevel == 1 && gameInformation.havingTotalCoin >= 90)
                {
                    gameInformation.rocketMagnificationLevel = 2;
                    gameInformation.havingTotalCoin = gameInformation.havingTotalCoin - 90;
                    mImage.sprite = Ssprite[1];
                }
                else if (gameInformation.rocketMagnificationLevel == 2 && gameInformation.havingTotalCoin >= 350)
                {
                    gameInformation.rocketMagnificationLevel = 3;
                    gameInformation.havingTotalCoin = gameInformation.havingTotalCoin - 350;
                    mImage.sprite = Ssprite[2];
                }
                else if (gameInformation.rocketMagnificationLevel == 3 && gameInformation.havingTotalCoin >= 1200)
                {
                    gameInformation.rocketMagnificationLevel = 4;
                    gameInformation.havingTotalCoin = gameInformation.havingTotalCoin - 1200;
                    mImage.sprite = Ssprite[3];
                }
                else if (gameInformation.rocketMagnificationLevel == 4 && gameInformation.havingTotalCoin >= 1200)
                {
                    gameInformation.rocketMagnificationLevel = 5;
                    gameInformation.havingTotalCoin = gameInformation.havingTotalCoin - 1200;
                    mImage.sprite = Ssprite[4];
                }
                PlayerPrefs.SetInt(SkillName[3], gameInformation.rocketMagnificationLevel);

                text2.text = PleaseCoin[gameInformation.rocketMagnificationLevel - 1];
                if (gameInformation.rocketMagnificationLevel == 5)
                {
                    text2.text = "MAX";
                }
                skillManager.RSLevel(4);
                break;
            case "Powerup":
                if (gameInformation.powerUpLevel == 1 && gameInformation.havingTotalCoin >= 90)
                {
                    gameInformation.powerUpLevel = 2;
                    gameInformation.havingTotalCoin = gameInformation.havingTotalCoin - 90;
                    mImage.sprite = Ssprite[1];
                }
                else if (gameInformation.powerUpLevel == 2 && gameInformation.havingTotalCoin >= 350)
                {
                    gameInformation.powerUpLevel = 3;
                    gameInformation.havingTotalCoin = gameInformation.havingTotalCoin - 350;
                    mImage.sprite = Ssprite[2];
                }
                else if (gameInformation.powerUpLevel == 3 && gameInformation.havingTotalCoin >= 1200)
                {
                    gameInformation.powerUpLevel = 4;
                    gameInformation.havingTotalCoin = gameInformation.havingTotalCoin - 1200;
                    mImage.sprite = Ssprite[3];
                }
                else if (gameInformation.powerUpLevel == 4 && gameInformation.havingTotalCoin >= 1200)
                {
                    gameInformation.powerUpLevel = 5;
                    gameInformation.havingTotalCoin = gameInformation.havingTotalCoin - 1200;
                    mImage.sprite = Ssprite[4];
                }
                PlayerPrefs.SetInt(SkillName[4], gameInformation.powerUpLevel);
                playerManagerL.SScale(gameInformation.powerUpLevel);        //左グローブのサイズ変更の関数を呼び出す
                playerManagerR.SScale(gameInformation.powerUpLevel);        //右グローブのサイズ変更の関数を呼び出す

                text2.text = PleaseCoin[gameInformation.powerUpLevel - 1];
                if (gameInformation.powerUpLevel == 5)
                {
                    text2.text = "MAX";
                }
                skillManager.RSLevel(1);
                break;
            case "PowerupTime":
                if (gameInformation.powerUpTimeLevel == 1 && gameInformation.havingTotalCoin >= 90)
                {
                    gameInformation.powerUpTimeLevel = 2;
                    gameInformation.havingTotalCoin = gameInformation.havingTotalCoin - 90;
                    mImage.sprite = Ssprite[1];
                }
                else if (gameInformation.powerUpTimeLevel == 2 && gameInformation.havingTotalCoin >= 350)
                {
                    gameInformation.powerUpTimeLevel = 3;
                    gameInformation.havingTotalCoin = gameInformation.havingTotalCoin - 350;
                    mImage.sprite = Ssprite[2];
                }
                else if (gameInformation.powerUpTimeLevel == 3 && gameInformation.havingTotalCoin >= 1200)
                {
                    gameInformation.powerUpTimeLevel = 4;
                    gameInformation.havingTotalCoin = gameInformation.havingTotalCoin - 1200;
                    mImage.sprite = Ssprite[3];
                }
                else if (gameInformation.powerUpTimeLevel == 4 && gameInformation.havingTotalCoin >= 1200)
                {
                    gameInformation.powerUpTimeLevel = 5;
                    gameInformation.havingTotalCoin = gameInformation.havingTotalCoin - 1200;
                    mImage.sprite = Ssprite[4];
                }
                PlayerPrefs.SetInt(SkillName[5], gameInformation.powerUpTimeLevel);
                skillManager.RSLevel(2);

                text2.text = PleaseCoin[gameInformation.powerUpTimeLevel - 1];
                if (gameInformation.powerUpTimeLevel == 5)
                {
                    text2.text = "MAX";
                }
                break;
            case "RocketNum":
                if (gameInformation.rocketNumLevel == 1 && gameInformation.havingTotalCoin >= 400)
                {
                    gameInformation.rocketNumLevel = 2;
                    gameInformation.havingTotalCoin = gameInformation.havingTotalCoin - 400;
                    mImage.sprite = Ssprite[1];
                }
                else if (gameInformation.rocketNumLevel == 2 && gameInformation.havingTotalCoin >= 800)
                {
                    gameInformation.rocketNumLevel = 3;
                    gameInformation.havingTotalCoin = gameInformation.havingTotalCoin - 800;
                    mImage.sprite = Ssprite[2];
                }
                PlayerPrefs.SetInt(SkillName[6], gameInformation.rocketNumLevel);

                text2.text =PleaseCoin[gameInformation.rocketNumLevel + 5];
                if (gameInformation.rocketNumLevel == 3)
                {
                    text2.text = "MAX";
                }
                break;
            case "WeakNum":
                if (gameInformation.weakPointNumLevel == 1 && gameInformation.havingTotalCoin >= 300)
                {
                    gameInformation.weakPointNumLevel = 2;
                    gameInformation.havingTotalCoin = gameInformation.havingTotalCoin - 300;
                    mImage.sprite = Ssprite[1];
                }
                else if (gameInformation.weakPointNumLevel == 2 && gameInformation.havingTotalCoin >= 2000)
                {
                    gameInformation.weakPointNumLevel = 3;
                    gameInformation.havingTotalCoin = gameInformation.havingTotalCoin - 2000;
                    mImage.sprite = Ssprite[2];
                }
                PlayerPrefs.SetInt(SkillName[7], gameInformation.weakPointNumLevel);

                text2.text = PleaseCoin[gameInformation.weakPointNumLevel + 3];
                if (gameInformation.weakPointNumLevel == 3)
                {
                    text2.text = "MAX";
                }
                break;
            case "WeakPointM":
                if (gameInformation.weakPointMagnificationLevel == 1 && gameInformation.havingTotalCoin >= 90)
                {
                    gameInformation.weakPointMagnificationLevel = 2;
                    gameInformation.havingTotalCoin = gameInformation.havingTotalCoin - 90;
                    mImage.sprite = Ssprite[1];
                }
                else if (gameInformation.weakPointMagnificationLevel == 2 && gameInformation.havingTotalCoin >= 350)
                {
                    gameInformation.weakPointMagnificationLevel = 3;
                    gameInformation.havingTotalCoin = gameInformation.havingTotalCoin - 350;
                    mImage.sprite = Ssprite[2];
                }
                else if (gameInformation.weakPointMagnificationLevel == 3 && gameInformation.havingTotalCoin >= 1200)
                {
                    gameInformation.weakPointMagnificationLevel = 4;
                    gameInformation.havingTotalCoin = gameInformation.havingTotalCoin - 1200;
                    mImage.sprite = Ssprite[3];
                }
                else if (gameInformation.weakPointMagnificationLevel == 4 && gameInformation.havingTotalCoin >= 1200)
                {
                    gameInformation.weakPointMagnificationLevel = 5;
                    gameInformation.havingTotalCoin = gameInformation.havingTotalCoin - 1200;
                    mImage.sprite = Ssprite[4];
                }
                PlayerPrefs.SetInt(SkillName[8], gameInformation.weakPointMagnificationLevel);
                skillManager.RSLevel(3);

                text2.text = PleaseCoin[gameInformation.weakPointMagnificationLevel - 1];
                if (gameInformation.weakPointMagnificationLevel == 5)
                {
                    text2.text = "MAX";
                }
                break;
        }
        PlayerPrefs.Save();
        text.text = "Coin:"+gameInformation.havingTotalCoin;
    }
}