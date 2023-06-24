using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MIDDLE_BOSS : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] MonitorAppearance monitorappearance;
    [SerializeField] SkillManager skillmanager;
    [SerializeField] GameInformation gameinformation;
    public float MiddleBossHp;
    private float bossBattleTime;
    public bool defeated;
    void Start()
    {
        switch (gameinformation.bossBattleTimeLevel)
        {
            case 1:
                bossBattleTime = 5.0f;
                break;
            case 2:
                bossBattleTime = 7.5f;
                break;
            case 3:
                bossBattleTime = 10.0f;
                break;
            case 4:
                bossBattleTime = 12.5f;
                break;
            case 5:
                bossBattleTime = 15.0f;
                break;
        }

        switch (monitorappearance.count)
        {
            case 0:
                MiddleBossHp = 300;
                break;

            case 1:
                MiddleBossHp = 550;
                break;

            case 2:
                MiddleBossHp = 1200;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        bossBattleTime -= Time.deltaTime;

        if (MiddleBossHp <= 0 && bossBattleTime >= 0)
        {
            defeated = true;

        }else if(bossBattleTime <= 0)
        {
            defeated = false;
        }
    }


}
