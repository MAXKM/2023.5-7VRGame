using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MIDDLE_BOSS : MonoBehaviour
{
    MonitorAppearance monitorappearance;
    SkillManager skillmanager;
    GameInformation gameinformation;
    HPGauge hpgauge;
    NewWeakPoint newweakpoint;
    GameManager gamemanager;
    BossTime bosstime;
    public float MiddleBossHp;
    private float bossBattleTime;
    bool display;
    public bool Detection;
    private bool Detectionable;
    HandDetection handdetection;
    private float damage;
    int i;
    GameObject bomb;
    GameObject oyaparticle;
    GameObject particle;
    public int bosscoin;
    public AudioClip BossBlake;
    public AudioClip FinalBossBlake;
    public AudioClip at;
    public AudioClip BE;
    AudioSource audioSource;
    bool defeated;
    GameObject child;
    void Start()
    {
        child = this.transform.GetChild(0).gameObject;
        audioSource = GetComponent<AudioSource>();
        bomb = GameObject.FindGameObjectWithTag("BT");
        oyaparticle = GameObject.FindGameObjectWithTag("BDP");
        particle= oyaparticle.transform.Find("monitor_destroy").gameObject;
        particle.SetActive(false);
        particle.SetActive(false);
        bomb.SetActive(true);
        defeated = false;

        monitorappearance = GameObject.FindGameObjectWithTag("MAM").GetComponent<MonitorAppearance>();
        skillmanager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SkillManager>();
        gameinformation = GameObject.FindGameObjectWithTag("GI").GetComponent<GameInformation>();
        hpgauge = GameObject.FindGameObjectWithTag("HG").GetComponent<HPGauge>();
        newweakpoint = GameObject.FindGameObjectWithTag("Weak").GetComponent<NewWeakPoint>();
        gamemanager= GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        bosstime= GameObject.FindGameObjectWithTag("BT").GetComponent<BossTime>();

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

        switch (gameinformation.progress)
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

            case 3:
                MiddleBossHp = 40;//4000
                break;
        }
        Debug.Log("hp:" +MiddleBossHp);
        Detection = false;
        Detectionable = false;
        display = true;
    }
    void Update()
    {
        if(monitorappearance.IBM.GetComponent<BoxCollider>().enabled == true)
        {
            bossBattleTime -= Time.deltaTime;
        }
        if (MiddleBossHp <= 0 && bossBattleTime > 0 && gameinformation.progress <= 2 && defeated == false)
        {
            defeated = true;
            gamemanager.SetState(GameManager.STATE.CLEAR);
            bosscoin = CoinGet(bosscoin);//ボスのコイン取得
            monitorappearance.hpGauge.SetActive(false);
            monitorappearance.weak.SetActive(false);
            for(i = 0; i < gameinformation.weakPointNumLevel; i++){
                Destroy(newweakpoint.weakpoint[i]);
            }
            bomb.SetActive(false);
            bosstime.DeathBomb();
            audioSource.PlayOneShot(BossBlake);
            child.GetComponent<MeshRenderer>().enabled = false;
            monitorappearance.IBM.GetComponent<BoxCollider>().enabled = false;
            //this.gameObject.SetActive(false);
            StartCoroutine(SAF(1.0f));
            particle.SetActive(true);
        }
        if(MiddleBossHp <= 0 && bossBattleTime > 0 && gameinformation.progress == 3 && defeated == false)
        {
            defeated = true;
            gamemanager.SetState(GameManager.STATE.CLEAR);
            monitorappearance.hpGauge.SetActive(false);
            monitorappearance.weak.SetActive(false);
            for (i = 0; i < gameinformation.weakPointNumLevel; i++)
            {
                Destroy(newweakpoint.weakpoint[i]);
            }
            bomb.SetActive(false);
            bosstime.DeathBomb();
            audioSource.PlayOneShot(FinalBossBlake);
            monitorappearance.IBM.GetComponent<SkinnedMeshRenderer>().enabled = false;
            monitorappearance.IBM.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(SAF(3.0f));
            //this.gameObject.SetActive(false);
            particle.SetActive(true);
            monitorappearance.BBA();
        }
        if (bossBattleTime < 5 && display == true && gameinformation.progress == 0)
        {
            bosstime.SetBomb();
            display = false;
        }

        if (bossBattleTime < 5 && display == true && gameinformation.progress == 1)
        {
            bosstime.SetBomb2();
            display = false;
        }
        if (bossBattleTime < 5 && display == true && gameinformation.progress == 2)
        {
            bosstime.SetBomb3();
            display = false;
        }
        if (bossBattleTime < 5 && display == true && gameinformation.progress == 3)
        {
            bosstime.FinalSetBomb();
            display = false;
        }

        if (bossBattleTime <= 0 && defeated == false)
        {
            defeated = true;
            gamemanager.SetState(GameManager.STATE.GAME_OVER);
            monitorappearance.IBM.GetComponent<BoxCollider>().enabled = false;
            audioSource.PlayOneShot(BE);
            StartCoroutine(TSSAF(3.0f));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Detectionable = true;
        if ((other.gameObject.tag == "LeftHand" || other.gameObject.tag == "RightHand") && Detectionable == true)
        {
            audioSource.PlayOneShot(at);
            Vector3 contactPoint = other.ClosestPoint(transform.position);
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

    public int CoinGet(int bosscoin)
    {
        if (gameinformation.progress == 0)
        {
            bosscoin = 100;
        }
        else if (gameinformation.progress == 1)
        {
            bosscoin = 500;
        }
        else if (gameinformation.progress == 2)
        {
            bosscoin = 1000;
        }
        return bosscoin;
    }

    IEnumerator SAF(float wait)
    {
        yield return new WaitForSeconds(wait);
        this.gameObject.SetActive(false);
    }

    IEnumerator TSSAF(float wait)
    {
        yield return new WaitForSeconds(wait);
        this.enabled = false;
    }
}
