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
    public GameObject E;//Effect
    GameObject[] BMA;//BossMonitorArray
    GameObject INM;//Instansiateで生成したNM
    public GameObject IBM;//Instansiateで生成したBM
    GameObject IE;//Instansiateで生成したIE
    public int count;//BossMonitorの番号
    public GameObject hpGauge;
    //public bool hpSet;
    void Awake()
    {
        BMA = new GameObject[3];
        BMA[0] = BM1;
        BMA[1] = BM2;
        BMA[2] = BM3;
        count = 0;

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
    }

    IEnumerator F(float wait)//Float(モニターが浮き上がる)
    {
        yield return new WaitForSeconds(wait);
        this.transform.DOMove(new Vector3(0.0f, 1.5f, 0.0f), 0.5f).SetEase(Ease.InOutQuart);
    }

    IEnumerator ES(float wait)//Effectをstart
    {
        yield return new WaitForSeconds(wait);
        IE = Instantiate(E, new Vector3(0.0f, 3.5f, 0.0f), Quaternion.Euler(90, 0, 0));

    }

    IEnumerator SC(float wait)//ScaleをChange
    {
        yield return new WaitForSeconds(wait);
        this.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        this.transform.DOScale(new Vector3(1.05f, 1.05f, 1.05f), 1.0f);
    }

    IEnumerator SC2(float wait)//ScaleをChange２
    {
        yield return new WaitForSeconds(wait);
        this.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
        this.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 1.0f);
    }

    IEnumerator BA(float wait)//BossMonitorがappear(現れる)
    {
        yield return new WaitForSeconds(wait);
        Destroy(INM);
        IBM = Instantiate(BMA[count], new Vector3(0.0f, 0.5f, 0.0f), Quaternion.Euler(0, 90, 0));
        IBM.GetComponent<BoxCollider>().enabled = false;
        IBM.transform.parent = this.transform;
        this.transform.position = new Vector3(0, 1f, 0);
    }

    IEnumerator SC3(float wait)//ScaleをChange３
    {
        yield return new WaitForSeconds(wait);
        //IBM.transform.localScale = Vector3.one * 0.5f;
        this.transform.localScale = Vector3.one * 0.6f;
        this.transform.DOScale(Vector3.one * 0.5f, 0.3f);
    }

    IEnumerator CO(float wait)//ColliderをOnにする
    {
        yield return new WaitForSeconds(wait);
        IBM.GetComponent<BoxCollider>().enabled = true;
        hpGauge.gameObject.SetActive(true);
        //hpSet = true;
        count += 1;
    }
}
