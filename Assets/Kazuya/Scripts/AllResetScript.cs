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
        PlayerPrefs.SetInt(DataName[0], 1);

        PlayerPrefs.SetInt(DataName[1], 1);

        PlayerPrefs.SetInt(DataName[2], 1);

        PlayerPrefs.SetInt(DataName[3], 1);

        PlayerPrefs.SetInt(DataName[4], 1);

        PlayerPrefs.SetInt(DataName[5], 1);

        PlayerPrefs.SetInt(DataName[6], 1);

        PlayerPrefs.SetInt(DataName[7], 1);

        PlayerPrefs.SetInt(DataName[8], 1);

        PlayerPrefs.SetInt(DataName[9], 0);

        PlayerPrefs.SetInt(DataName[10], 0);

        PlayerPrefs.SetInt(DataName[11], 0);

        
    }
}

