using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButtonManager : MonoBehaviour
{
    [SerializeField] GameInformation gameInformation;
    private Image mImage;
    public Sprite[] Ssprite;
    // Start is called before the first frame update
    void Start()
    {
        mImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick(string button)
    {
        switch (button)
        {
            case "Coinup":
                if (gameInformation.coinUpLevel == 1 && gameInformation.havingTotalCoin >= 90)
                {
                    gameInformation.coinUpLevel = 2;
                    gameInformation.havingTotalCoin = gameInformation.havingTotalCoin - 90;
                    mImage.sprite = Ssprite[1];
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
                break;
            case "GoldEnemy":
                if (gameInformation.goldEnemyProbabilityLevel==1&&gameInformation.havingTotalCoin>=90)
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
                break;
        }
        
    }
}
