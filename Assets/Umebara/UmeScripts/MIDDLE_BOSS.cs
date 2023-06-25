using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MIDDLE_BOSS : MonoBehaviour
{
    // Start is called before the first frame update
    MonitorAppearance monitorappearance;
    SkillManager skillmanager;
    GameInformation gameinformation;
    HPGauge hpgauge;
    public float MiddleBossHp;
    private float bossBattleTime;
    public bool defeated;
    public bool Detection;
    private bool Detectionable;
    HandDetection handdetection;
    private float damage;
    void Awake()
    {
        monitorappearance = GameObject.FindGameObjectWithTag("MAM").GetComponent<MonitorAppearance>();
        skillmanager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SkillManager>();
        gameinformation = GameObject.FindGameObjectWithTag("GI").GetComponent<GameInformation>();
        hpgauge = GameObject.FindGameObjectWithTag("HG").GetComponent<HPGauge>();
        switch (gameinformation.bossBattleTimeLevel)
        {
            case 0:
                bossBattleTime = 5.0f;
                break;
            case 1:
                bossBattleTime = 7.5f;
                break;
            case 2:
                bossBattleTime = 10.0f;
                break;
            case 3:
                bossBattleTime = 12.5f;
                break;
            case 4:
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
        Detection = false;
        Detectionable = false;
        hpgauge.Set(MiddleBossHp);
    }

    // Update is called once per frame
    void Update()
    {
        if(monitorappearance.IBM.GetComponent<BoxCollider>().enabled == true)
        bossBattleTime -= Time.deltaTime;
        if (MiddleBossHp <= 0 && bossBattleTime >= 0)
        {
            defeated = true;

        }
        else if (bossBattleTime <= 0)
        {
            defeated = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Detectionable = true;
        if ((other.gameObject.tag == "LeftHand" || other.gameObject.tag == "RightHand") && Detectionable == true)
        {
            Vector3 contactPoint = other.ClosestPoint(transform.position);
            Debug.Log(contactPoint);
            //SkillManager‚ÉÚG’Ê’m‚ð‘—‚éA‹——£‚Ì’l‚ð‘—‚é
            if (other.gameObject.tag == "LeftHand")
            {
                if (handdetection == null)
                {
                    GameObject obj = GameObject.FindGameObjectWithTag("RightHand");
                    handdetection = obj.GetComponent<HandDetection>();
                }
                if (handdetection.distanceLeft < 0.5f)
                {
                    handdetection.ResetDistance();
                    skillmanager.BDamage(contactPoint, handdetection.distanceLeft);
                    return;
                }
                skillmanager.BDamage(contactPoint, handdetection.distanceLeft);
            }
            else if (other.gameObject.tag == "RightHand")
            {
                if (handdetection == null)
                {
                    handdetection = other.gameObject.GetComponent<HandDetection>();
                }
                if (handdetection.distanceRight < 0.5f)
                {
                    handdetection.ResetDistance();
                    skillmanager.BDamage(contactPoint, handdetection.distanceRight);
                    return;
                }
                skillmanager.BDamage(contactPoint, handdetection.distanceRight);
            }
            handdetection.ResetDistance();
            MiddleBossHp -= skillmanager.Damage;
            hpgauge.GaugeReduction(skillmanager.Damage);
            Detection = true;
        }

    }
}
