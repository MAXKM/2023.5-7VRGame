using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameInformation Gameinformation;
    public int Number;
    private string[] PleaseCoin = { "Please 90 Coin", "Please 350 Coin", "Please 1200 Coin", "Please 300 Coin", "Please 2000 Coin", "Please 400 Coin", "Please 800 Coin" };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        text.enabled = true;
        Debug.Log(Number);
        switch (Number)
        {
            case 0:
                if (Gameinformation.coinUpLevel==1)
                {
                    text.text=PleaseCoin[0];
                }
                else if (Gameinformation.coinUpLevel == 2)
                {
                    text.text = PleaseCoin[1];
                }
                else if (Gameinformation.coinUpLevel == 3)
                {
                    text.text = PleaseCoin[2];
                }
                else if (Gameinformation.coinUpLevel == 4)
                {
                    text.text = PleaseCoin[2];
                }
                else
                {
                    text.enabled = false;
                }
                break;
            case 1:
                if (Gameinformation.goldEnemyProbabilityLevel == 1)
                {
                    text.text = PleaseCoin[0];
                }
                else if (Gameinformation.goldEnemyProbabilityLevel == 2)
                {
                    text.text = PleaseCoin[1];
                }
                else if (Gameinformation.goldEnemyProbabilityLevel == 3)
                {
                    text.text = PleaseCoin[2];
                }
                else if (Gameinformation.goldEnemyProbabilityLevel == 4)
                {
                    text.text = PleaseCoin[2];
                }
                else
                {
                    text.enabled = false;
                }
                break;
            case 2:
                if (Gameinformation.bossBattleTimeLevel == 1)
                {
                    text.text = PleaseCoin[0];
                }
                else if (Gameinformation.bossBattleTimeLevel == 2)
                {
                    text.text = PleaseCoin[1];
                }
                else if (Gameinformation.bossBattleTimeLevel == 3)
                {
                    text.text = PleaseCoin[2];
                }
                else if (Gameinformation.bossBattleTimeLevel == 4)
                {
                    text.text = PleaseCoin[2];
                }
                else
                {
                    text.enabled = false;
                }
                break;
            case 3:
                if (Gameinformation.rocketMagnificationLevel == 1)
                {
                    text.text = PleaseCoin[0];
                }
                else if (Gameinformation.rocketMagnificationLevel == 2)
                {
                    text.text = PleaseCoin[1];
                }
                else if (Gameinformation.rocketMagnificationLevel == 3)
                {
                    text.text = PleaseCoin[2];
                }
                else if (Gameinformation.rocketMagnificationLevel == 4)
                {
                    text.text = PleaseCoin[2];
                }
                else
                {
                    text.enabled = false;
                }
                break;
            case 4:
                if (Gameinformation.powerUpLevel == 1)
                {
                    text.text = PleaseCoin[0];
                }
                else if (Gameinformation.powerUpLevel == 2)
                {
                    text.text = PleaseCoin[1];
                }
                else if (Gameinformation.powerUpLevel == 3)
                {
                    text.text = PleaseCoin[2];
                }
                else if (Gameinformation.powerUpLevel == 4)
                {
                    text.text = PleaseCoin[2];
                }
                else
                {
                    text.enabled = false;
                }
                break;
            case 5:
                if (Gameinformation.powerUpTimeLevel == 1)
                {
                    text.text = PleaseCoin[0];
                }
                else if (Gameinformation.powerUpTimeLevel == 2)
                {
                    text.text = PleaseCoin[1];
                }
                else if (Gameinformation.powerUpTimeLevel == 3)
                {
                    text.text = PleaseCoin[2];
                }
                else if (Gameinformation.powerUpTimeLevel == 4)
                {
                    text.text = PleaseCoin[2];
                }
                else
                {
                    text.enabled = false;
                }
                break;
            case 6:
                if (Gameinformation.rocketNumLevel == 1)
                {
                    text.text = PleaseCoin[5];
                }
                else if (Gameinformation.rocketNumLevel == 2)
                {
                    text.text = PleaseCoin[6];
                }
                else
                {
                    text.enabled = false;
                }
                break;
            case 7:
                if (Gameinformation.weakPointNumLevel == 1)
                {
                    text.text = PleaseCoin[3];
                }
                else if (Gameinformation.weakPointNumLevel == 2)
                {
                    text.text = PleaseCoin[4];
                }
                else
                {
                    text.enabled = false;
                }
                break;
            case 8:
                if (Gameinformation.weakPointMagnificationLevel == 1)
                {
                    text.text = PleaseCoin[0];
                }
                else if (Gameinformation.weakPointMagnificationLevel == 2)
                {
                    text.text = PleaseCoin[1];
                }
                else if (Gameinformation.weakPointMagnificationLevel == 3)
                {
                    text.text = PleaseCoin[2];
                }
                else if (Gameinformation.weakPointMagnificationLevel == 4)
                {
                    text.text = PleaseCoin[2];
                }
                else
                {
                    text.enabled = false;
                }
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        text.enabled = false;
    }
}
