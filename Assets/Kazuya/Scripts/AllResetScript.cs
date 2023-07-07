using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllResetScript : MonoBehaviour
{
    [SerializeField] GameInformation gameInformation;
    private string[] DataName = { "coinUpLevel", "goldEnemyProbabilityLevel", "bossBattleTimeLevel", "rocketMagnificationLevel", "powerUpLevel", "powerUpTimeLevel", 
                                    "rocketNumLevel", "weakPointNumLevel", "weakPointMagnificationLevel" , "numberOfPlays", "progress", "havingTotalCoin" };
    int length = 0;
    // Start is called before the first frame update
    void Start()
    {
        //length = DataName.Length;
    }

    // Update is called once per frame

    public void DataDelete()
    {
        PlayerPrefs.DeleteKey("coinUpLevel");
        PlayerPrefs.DeleteKey("goldEnemyProbabilityLevel");
        PlayerPrefs.DeleteKey("bossBattleTimeLevel");
        PlayerPrefs.DeleteKey("rocketMagnificationLevel");
        PlayerPrefs.DeleteKey("powerUpLevel");
        PlayerPrefs.DeleteKey("powerUpTimeLevel");
        PlayerPrefs.DeleteKey("rocketNumLevel");
        PlayerPrefs.DeleteKey("weakPointNumLevel");
        PlayerPrefs.DeleteKey("weakPointMagnificationLevel");
        PlayerPrefs.DeleteKey("NUMBER_OF_PLAYS");
        PlayerPrefs.DeleteKey("PROGRESS");
        PlayerPrefs.DeleteKey("TOTAL_COIN");

        Reset();
        SceneManager.LoadScene("GameScene");
    }

    private void Reset()
    {
        PlayerPrefs.SetInt("coinUpLevel",1);
        PlayerPrefs.SetInt("goldEnemyProbabilityLevel", 1);
        PlayerPrefs.SetInt("bossBattleTimeLevel", 1);
        PlayerPrefs.SetInt("rocketMagnificationLevel", 1);
        PlayerPrefs.SetInt("powerUpLevel", 1);
        PlayerPrefs.SetInt("powerUpTimeLevel", 1);
        PlayerPrefs.SetInt("rocketNumLevel", 1);
        PlayerPrefs.SetInt("weakPointNumLevel", 1);
        PlayerPrefs.SetInt("weakPointMagnificationLevel", 1);
        PlayerPrefs.SetInt("NUMBER_OF_PLAYS", 0);
        PlayerPrefs.SetInt("PROGRESS", 0);
        PlayerPrefs.SetInt("TOTAL_COIN", 0);

        gameInformation.coinUpLevel = PlayerPrefs.GetInt("coinUpLevel", 1);
        gameInformation.goldEnemyProbabilityLevel = PlayerPrefs.GetInt("goldEnemyProbabilityLevel", 1);
        gameInformation.bossBattleTimeLevel = PlayerPrefs.GetInt("bossBattleTimeLevel", 1);
        gameInformation.rocketMagnificationLevel = PlayerPrefs.GetInt("rocketMagnificationLevel", 1);
        gameInformation.powerUpLevel = PlayerPrefs.GetInt("powerUpLevel", 1);
        gameInformation.powerUpTimeLevel = PlayerPrefs.GetInt("powerUpTimeLevel", 1);
        gameInformation.rocketNumLevel = PlayerPrefs.GetInt("rocketNumLevel", 1);
        gameInformation.weakPointNumLevel = PlayerPrefs.GetInt("weakPointNumLevel", 1);
        gameInformation.weakPointMagnificationLevel = PlayerPrefs.GetInt("weakPointMagnificationLevel", 1);
        gameInformation.numberOfPlays = PlayerPrefs.GetInt("NUMBER_OF_PLAYS", 0);
        gameInformation.progress = PlayerPrefs.GetInt("PROGRESS", 0);
        gameInformation.havingTotalCoin = PlayerPrefs.GetInt("TOTAL_COIN", 0);
        
    }
}

