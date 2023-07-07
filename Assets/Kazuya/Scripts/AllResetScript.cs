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
        length = DataName.Length;
    }

    // Update is called once per frame

    public void DataDelete()
    {
        for (int i = 0; i < length; i++ )
        {
            PlayerPrefs.DeleteKey(DataName[i]);
        }
        Reset();
        SceneManager.LoadScene("GameScene");
    }

    private void Reset()
    {
        gameInformation.coinUpLevel = PlayerPrefs.GetInt(DataName[0], 1);

        gameInformation.goldEnemyProbabilityLevel = PlayerPrefs.GetInt(DataName[1], 1);

        gameInformation.bossBattleTimeLevel = PlayerPrefs.GetInt(DataName[2], 1);

        gameInformation.rocketMagnificationLevel = PlayerPrefs.GetInt(DataName[3], 1);

        gameInformation.powerUpLevel = PlayerPrefs.GetInt(DataName[4], 1);

        gameInformation.powerUpTimeLevel = PlayerPrefs.GetInt(DataName[5], 1);

        gameInformation.rocketNumLevel = PlayerPrefs.GetInt(DataName[6], 1);

        gameInformation.weakPointNumLevel = PlayerPrefs.GetInt(DataName[7], 1);

        gameInformation.weakPointMagnificationLevel = PlayerPrefs.GetInt(DataName[8], 1);

        gameInformation.numberOfPlays = PlayerPrefs.GetInt(DataName[9], 0);

        gameInformation.progress = PlayerPrefs.GetInt(DataName[10], 0);

        gameInformation.havingTotalCoin = PlayerPrefs.GetInt(DataName[11], 0);

        
    }
}

