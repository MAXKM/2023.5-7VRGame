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
    GameObject INM;//InstansiatÇ≈ê∂ê¨ÇµÇΩNM
    GameObject[] IE;//InstansiatÇ≈ê∂ê¨ÇµÇΩE
    GameObject IBM;//InstansiatÇ≈ê∂ê¨ÇµÇΩBM
    void Start()
    {
        BMA = new GameObject[3];
        BMA[0] = BM1;
        BMA[1] = BM2;
        BMA[2] = BM3;
        IE = new GameObject[3];

        INM = Instantiate(NM, new Vector3(0.0f, 5.0f, 0.0f), Quaternion.Euler(0, 0, 0));
        INM.transform.parent = this.transform;
        this.transform.DOMove(new Vector3(0.0f, 0.75f, 0.0f), 1.5f);
        StartCoroutine(F(1.75f));
        StartCoroutine(ES(2.25f));
        StartCoroutine(SC(3.25f));
        StartCoroutine(SC2(4.5f));
        StartCoroutine(BA(6.5f));
        StartCoroutine(SC3(6.5f));
    }

    IEnumerator F(float wait)
    {
        yield return new WaitForSeconds(wait);
        this.transform.DOMove(new Vector3(0.0f, 1.5f, 0.0f), 0.5f).SetEase(Ease.InOutQuart);
    }

    IEnumerator ES(float wait)
    {
        yield return new WaitForSeconds(wait);
        IE[0] = Instantiate(E, new Vector3(0.0f, 1.5f, 0.0f), Quaternion.Euler(0, 0, 0));
    }

    IEnumerator SC(float wait)
    {
        yield return new WaitForSeconds(wait);
        this.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        this.transform.DOScale(new Vector3(1.05f, 1.05f, 1.05f), 1.0f);
        IE[1] = Instantiate(E, new Vector3(0.0f, 1.5f, 0.0f), Quaternion.Euler(0, 0, 0));
    }

    IEnumerator SC2(float wait)
    {
        yield return new WaitForSeconds(wait);
        this.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
        this.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 1.0f);
        IE[2] = Instantiate(E, new Vector3(0.0f, 1.5f, 0.0f), Quaternion.Euler(0, 0, 0));
    }

    IEnumerator BA(float wait)
    {
        yield return new WaitForSeconds(wait);
        Destroy(INM);
        IBM = Instantiate(BMA[0], new Vector3(0.0f, 1.75f, 0.0f), Quaternion.Euler(0, 0, 0));
        IBM.transform.parent = this.transform;

    }

    IEnumerator SC3(float wait)
    {
        yield return new WaitForSeconds(wait);
        IBM.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        this.transform.DOScale(new Vector3(1.0f, 1.0f, 1.0f), 1.5f);
        Destroy(IE[0]);Destroy(IE[1]); Destroy(IE[2]);
    }
}
