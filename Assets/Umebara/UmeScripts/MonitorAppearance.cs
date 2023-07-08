using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MonitorAppearance : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject NM;//NomalMonitor
    public GameObject BM1;//BossMonitor1
    public GameObject BM2;//BossMonitor2
    public GameObject BM3;//BossMonitor3
    public GameObject FB;
    public GameObject E;//Effect
    GameObject[] BMA;//BossMonitorArray
    GameObject INM;//InstansiateÇ≈ê∂ê¨ÇµÇΩNM
    public GameObject IBM;//InstansiateÇ≈ê∂ê¨ÇµÇΩBM
    GameObject IE;//InstansiateÇ≈ê∂ê¨ÇµÇΩIE
    public GameObject hpGauge;
    //public bool hpSet;
    public GameObject weak;
    public bool MBCall;
    [SerializeField] HPGauge hpgauge;
    MIDDLE_BOSS middleboss;
    NewWeakPoint newweakpoint;
    [SerializeField] GameInformation gameinformation2;
    public bool BossAppear;
    public GameObject AP;
    GameObject NAP;
    [SerializeField] GameManager gamemanager;
    void Awake()
    {
        BMA = new GameObject[4];
        BMA[0] = BM1;
        BMA[1] = BM2;
        BMA[2] = BM3;
        BMA[3] = FB;
        BossAppear = false;

        if (gameinformation2.progress == 0)
        {
            INM = Instantiate(NM, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.Euler(0, 90, 0));
            INM.GetComponent<BoxCollider>().enabled = false;
            INM.transform.parent = this.transform;
            transform.position = new Vector3(0, 5, 0);
            this.transform.DOMove(new Vector3(0.0f, 0.75f, 0.0f), 1.5f);
            StartCoroutine(F(1.75f));
            StartCoroutine(ES(2.25f));
            StartCoroutine(SC(3.25f));
            StartCoroutine(SC2(4.5f));
            StartCoroutine(BA(6.5f));
            StartCoroutine(SC3(6.5f));
            StartCoroutine(CO(8.0f));
            MBCall = false;
        }
        if (gameinformation2.progress == 1)
        {
            INM = Instantiate(NM, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.Euler(0, 90, 0));
            INM.GetComponent<BoxCollider>().enabled = false;
            INM.transform.parent = this.transform;
            transform.position = new Vector3(0, 5, 0);
            this.transform.DOMove(new Vector3(0.0f, 0.75f, 0.0f), 1.5f);
            StartCoroutine(F_2(1.75f));
            StartCoroutine(ES_2(2.25f));
            StartCoroutine(SC_2(3.25f));
            StartCoroutine(SC2_2(4.5f));
            StartCoroutine(BA_2(6.5f));
            StartCoroutine(SC3_2(6.5f));
            StartCoroutine(CO_2(8.0f));
            MBCall = false;
        }

        if (gameinformation2.progress == 2)
        {
            INM = Instantiate(NM, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.Euler(0, 90, 0));
            INM.GetComponent<BoxCollider>().enabled = false;
            INM.transform.parent = this.transform;
            transform.position = new Vector3(0, 5, 0);
            this.transform.DOMove(new Vector3(0.0f, 0.75f, 0.0f), 1.5f);
            StartCoroutine(F_3(1.75f));
            StartCoroutine(ES_3(2.25f));
            StartCoroutine(SC_3(3.25f));
            StartCoroutine(SC2_3(4.5f));
            StartCoroutine(BA_3(6.5f));
            StartCoroutine(SC3_3(6.5f));
            StartCoroutine(CO_3(8.0f));
            MBCall = false;
        }

        if (gameinformation2.progress == 3)
        {
            weak.SetActive(true);
            newweakpoint = GameObject.FindGameObjectWithTag("Weak").GetComponent<NewWeakPoint>();
            IBM = Instantiate(BMA[gameinformation2.progress], new Vector3(0.0f, 0.5f, 0.0f), Quaternion.Euler(0, 90, 0));
            IBM.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(FBA(3.0f));
        }
    }
    IEnumerator F(float wait)//Float(ÉÇÉjÉ^Å[Ç™ïÇÇ´è„Ç™ÇÈ)
    {
        yield return new WaitForSeconds(wait);
        this.transform.DOMove(new Vector3(0.0f, 1.5f, 0.0f), 0.5f).SetEase(Ease.InOutQuart);
    }

    IEnumerator ES(float wait)//EffectÇstart
    {
        yield return new WaitForSeconds(wait);
        IE = Instantiate(E, new Vector3(0.0f, 3.5f, 0.0f), Quaternion.Euler(90, 0, 0));

    }

    IEnumerator SC(float wait)//ScaleÇChange
    {
        yield return new WaitForSeconds(wait);
        this.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        this.transform.DOScale(new Vector3(1.05f, 1.05f, 1.05f), 1.0f);
    }

    IEnumerator SC2(float wait)//ScaleÇChangeÇQ
    {
        yield return new WaitForSeconds(wait);
        this.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
        this.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 1.0f);
    }

    IEnumerator BA(float wait)//BossMonitorÇ™appear(åªÇÍÇÈ)
    {
        yield return new WaitForSeconds(wait);
        Destroy(INM);
        weak.SetActive(true);
        NAP = Instantiate(AP, new Vector3(0.0f, 0.5f, 0.0f), Quaternion.Euler(0, 0, 0));
        IBM = Instantiate(BMA[gameinformation2.progress], new Vector3(0.0f, 0.5f, 0.0f), Quaternion.Euler(0, 90, 0));
        IBM.GetComponent<BoxCollider>().enabled = false;
        IBM.transform.parent = this.transform;
        this.transform.position = new Vector3(0, 0.86f, 0);
        BossAppear = true;
    }

    IEnumerator SC3(float wait)//ScaleÇChangeÇR
    {
        yield return new WaitForSeconds(wait);
        //IBM.transform.localScale = Vector3.one * 0.5f;
        this.transform.localScale = Vector3.one * 0.6f;
        this.transform.DOScale(Vector3.one * 0.5f, 0.3f);
    }

    IEnumerator CO(float wait)//ColliderÇOnÇ…Ç∑ÇÈ
    {
        yield return new WaitForSeconds(wait);
        IBM.GetComponent<BoxCollider>().enabled = true;
        hpGauge.gameObject.SetActive(true);
        middleboss = GameObject.FindGameObjectWithTag("MB").GetComponent<MIDDLE_BOSS>();
        newweakpoint = GameObject.FindGameObjectWithTag("Weak").GetComponent<NewWeakPoint>();
        newweakpoint.WA();
        hpgauge.Set(middleboss.MiddleBossHp);
        gamemanager.usableSkill = true;
        //weak.SetActive(true);
        //hpSet = true;
        MBCall = true;
    }


    IEnumerator F_2(float wait)//Float(ÉÇÉjÉ^Å[Ç™ïÇÇ´è„Ç™ÇÈ)
    {
        yield return new WaitForSeconds(wait);
        this.transform.DOMove(new Vector3(0.0f, 1.5f, 0.0f), 0.5f).SetEase(Ease.InOutQuart);
    }

    IEnumerator ES_2(float wait)//EffectÇstart
    {
        yield return new WaitForSeconds(wait);
        IE = Instantiate(E, new Vector3(0.0f, 3.5f, 0.0f), Quaternion.Euler(90, 0, 0));

    }

    IEnumerator SC_2(float wait)//ScaleÇChange
    {
        yield return new WaitForSeconds(wait);
        this.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        this.transform.DOScale(new Vector3(1.05f, 1.05f, 1.05f), 1.0f);
    }

    IEnumerator SC2_2(float wait)//ScaleÇChangeÇQ
    {
        yield return new WaitForSeconds(wait);
        this.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
        this.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 1.0f);
    }

    IEnumerator BA_2(float wait)//BossMonitorÇ™appear(åªÇÍÇÈ)
    {
        yield return new WaitForSeconds(wait);
        Destroy(INM);
        weak.SetActive(true);
        NAP = Instantiate(AP, new Vector3(0.0f, 0.5f, 0.0f), Quaternion.Euler(0, 0, 0));
        IBM = Instantiate(BMA[gameinformation2.progress], new Vector3(0.0f, 0.5f, 0.0f), Quaternion.Euler(0, 90, 0));
        IBM.GetComponent<BoxCollider>().enabled = false;
        IBM.transform.parent = this.transform;
        this.transform.position = new Vector3(0, 1f, 0);
        BossAppear = true;
    }

    IEnumerator SC3_2(float wait)//ScaleÇChangeÇR
    {
        yield return new WaitForSeconds(wait);
        //IBM.transform.localScale = Vector3.one * 0.5f;
        this.transform.localScale = Vector3.one * 0.6f;
        this.transform.DOScale(Vector3.one * 0.5f, 0.3f);
    }

    IEnumerator CO_2(float wait)//ColliderÇOnÇ…Ç∑ÇÈ
    {
        yield return new WaitForSeconds(wait);
        IBM.GetComponent<BoxCollider>().enabled = true;
        hpGauge.gameObject.SetActive(true);
        middleboss = GameObject.FindGameObjectWithTag("MB").GetComponent<MIDDLE_BOSS>();
        newweakpoint= GameObject.FindGameObjectWithTag("Weak").GetComponent<NewWeakPoint>();
        newweakpoint.WA();
        hpgauge.Set(middleboss.MiddleBossHp);
        gamemanager.usableSkill = true;
        //weak.SetActive(true);
        //hpSet = true;
        MBCall = true;
    }

    IEnumerator F_3(float wait)//Float(ÉÇÉjÉ^Å[Ç™ïÇÇ´è„Ç™ÇÈ)
    {
        yield return new WaitForSeconds(wait);
        this.transform.DOMove(new Vector3(0.0f, 1.5f, 0.0f), 0.5f).SetEase(Ease.InOutQuart);
    }

    IEnumerator ES_3(float wait)//EffectÇstart
    {
        yield return new WaitForSeconds(wait);
        IE = Instantiate(E, new Vector3(0.0f, 3.5f, 0.0f), Quaternion.Euler(90, 0, 0));

    }

    IEnumerator SC_3(float wait)//ScaleÇChange
    {
        yield return new WaitForSeconds(wait);
        this.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        this.transform.DOScale(new Vector3(1.05f, 1.05f, 1.05f), 1.0f);
    }

    IEnumerator SC2_3(float wait)//ScaleÇChangeÇQ
    {
        yield return new WaitForSeconds(wait);
        this.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
        this.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 1.0f);
    }

    IEnumerator BA_3(float wait)//BossMonitorÇ™appear(åªÇÍÇÈ)
    {
        yield return new WaitForSeconds(wait);
        Destroy(INM);
        weak.SetActive(true);
        NAP = Instantiate(AP, new Vector3(0.0f, 0.5f, 0.0f), Quaternion.Euler(0, 0, 0));
        IBM = Instantiate(BMA[gameinformation2.progress], new Vector3(0.0f, 0.5f, 0.0f), Quaternion.Euler(0, 90, 0));
        IBM.GetComponent<BoxCollider>().enabled = false;
        IBM.transform.parent = this.transform;
        this.transform.position = new Vector3(0, 1.23f, 0);
        BossAppear = true;
    }

    IEnumerator SC3_3(float wait)//ScaleÇChangeÇR
    {
        yield return new WaitForSeconds(wait);
        //IBM.transform.localScale = Vector3.one * 0.5f;
        this.transform.localScale = Vector3.one * 0.9f;
        this.transform.DOScale(Vector3.one * 0.8f, 0.3f);
    }

    IEnumerator CO_3(float wait)//ColliderÇOnÇ…Ç∑ÇÈ
    {
        yield return new WaitForSeconds(wait);
        IBM.GetComponent<BoxCollider>().enabled = true;
        hpGauge.gameObject.SetActive(true);
        middleboss = GameObject.FindGameObjectWithTag("MB").GetComponent<MIDDLE_BOSS>();
        newweakpoint = GameObject.FindGameObjectWithTag("Weak").GetComponent<NewWeakPoint>();
        newweakpoint.WA();
        hpgauge.Set(middleboss.MiddleBossHp);
        gamemanager.usableSkill = true;
        //weak.SetActive(true);
        //hpSet = true;
        MBCall = true;
    }
    IEnumerator FBA(float wait)
    {
        yield return new WaitForSeconds(wait);
        IBM.GetComponent<BoxCollider>().enabled = true;
        hpGauge.gameObject.SetActive(true);
        middleboss = GameObject.FindGameObjectWithTag("MB").GetComponent<MIDDLE_BOSS>();
        newweakpoint.WA();
        hpgauge.Set(middleboss.MiddleBossHp);
        BossAppear = true;
        MBCall = true;
    }
}
