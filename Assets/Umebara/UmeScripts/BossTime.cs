using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTime : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Bomb;
    public GameObject Ex;
    GameObject bomb;
    GameObject ex;

    public void SetBomb()
    {
        bomb = Instantiate(Bomb, new Vector3(0.05f, 0.345f, 0.0f), Quaternion.Euler(0, 90, 0));
        StartCoroutine(C1(1.0f));
        StartCoroutine(C2(2.0f));
        StartCoroutine(C3(3.0f));
        StartCoroutine(C4(4.0f));
        StartCoroutine(C5(4.75f));
    }

    IEnumerator C1(float wait)
    {
        yield return new WaitForSeconds(wait);
        bomb.transform.localScale = new Vector3(0.2f, 0.2f, 1.0f);
        bomb.GetComponent<Renderer>().material.color = Color.red;
        bomb.transform.DOScale(new Vector3(0.175f, 0.175f, 1.0f), 0.5f);
        bomb.GetComponent<Renderer>().material.DOColor(Color.white, 0.5f);
    }

    IEnumerator C2(float wait)
    {
        yield return new WaitForSeconds(wait);
        bomb.transform.localScale = new Vector3(0.225f, 0.225f, 1.0f);
        bomb.GetComponent<Renderer>().material.color = Color.red;
        bomb.transform.DOScale(new Vector3(0.2f, 0.2f, 1.0f), 0.5f);
        bomb.GetComponent<Renderer>().material.DOColor(Color.white, 0.5f);
    }

    IEnumerator C3(float wait)
    {
        yield return new WaitForSeconds(wait);
        bomb.transform.localScale = new Vector3(0.25f, 0.25f, 1.0f);
        bomb.GetComponent<Renderer>().material.color = Color.red;
        bomb.transform.DOScale(new Vector3(0.225f, 0.225f, 1.0f), 0.5f);
        bomb.GetComponent<Renderer>().material.DOColor(Color.white, 0.5f);
    }

    IEnumerator C4(float wait)
    {
        yield return new WaitForSeconds(wait);
        bomb.transform.localScale = new Vector3(0.275f, 0.275f, 1.0f);
        bomb.GetComponent<Renderer>().material.color = Color.red;
        bomb.transform.DOScale(new Vector3(0.25f, 0.25f, 1.0f), 0.5f);
        bomb.GetComponent<Renderer>().material.DOColor(Color.white, 0.5f);
    }

    IEnumerator C5(float wait)
    {
        yield return new WaitForSeconds(wait);
        ex = Instantiate(Ex, new Vector3(0.0f, 0.5f, 0.0f), Quaternion.Euler(0, 90, 0));
        Destroy(bomb);
    }
    public void SetBomb2()
    {
        bomb = Instantiate(Bomb, new Vector3(0.05f, 0.6f, 0.0f), Quaternion.Euler(0, 90, 0));
        StartCoroutine(C1(1.0f));
        StartCoroutine(C2(2.0f));
        StartCoroutine(C3(3.0f));
        StartCoroutine(C4(4.0f));
        StartCoroutine(C5(4.75f));
    }

    public void SetBomb3()
    {
        bomb = Instantiate(Bomb, new Vector3(0.05f, 0.455f, 0.0f), Quaternion.Euler(0, 90, 0));
        StartCoroutine(C1(1.0f));
        StartCoroutine(C2(2.0f));
        StartCoroutine(C3(3.0f));
        StartCoroutine(C4(4.0f));
        StartCoroutine(C5(4.75f));
    }

    public void FinalSetBomb()
    {
        bomb = Instantiate(Bomb, new Vector3(0.13f, 0.35f, 0.0f), Quaternion.Euler(0, 90, 0));
        StartCoroutine(FC1(1.0f));
        StartCoroutine(FC2(2.0f));
        StartCoroutine(FC3(3.0f));
        StartCoroutine(FC4(4.0f));
        StartCoroutine(FC5(4.75f));
    }

    IEnumerator FC1(float wait)
    {
        yield return new WaitForSeconds(wait);
        bomb.transform.localScale = new Vector3(0.25f, 0.25f, 1.0f);
        bomb.GetComponent<Renderer>().material.color = Color.red;
        bomb.transform.DOScale(new Vector3(0.175f, 0.175f, 1.0f), 0.5f);
        bomb.GetComponent<Renderer>().material.DOColor(Color.white, 0.5f);
    }

    IEnumerator FC2(float wait)
    {
        yield return new WaitForSeconds(wait);
        bomb.transform.localScale = new Vector3(0.30f, 0.30f, 1.0f);
        bomb.GetComponent<Renderer>().material.color = Color.red;
        bomb.transform.DOScale(new Vector3(0.225f, 0.225f, 1.0f), 0.5f);
        bomb.GetComponent<Renderer>().material.DOColor(Color.white, 0.5f);
    }

    IEnumerator FC3(float wait)
    {
        yield return new WaitForSeconds(wait);
        bomb.transform.localScale = new Vector3(0.35f, 0.35f, 1.0f);
        bomb.GetComponent<Renderer>().material.color = Color.red;
        bomb.transform.DOScale(new Vector3(0.275f, 0.275f, 1.0f), 0.5f);
        bomb.GetComponent<Renderer>().material.DOColor(Color.white, 0.5f);
    }

    IEnumerator FC4(float wait)
    {
        yield return new WaitForSeconds(wait);
        bomb.transform.localScale = new Vector3(0.4f, 0.4f, 1.0f);
        bomb.GetComponent<Renderer>().material.color = Color.red;
        bomb.transform.DOScale(new Vector3(0.325f, 0.325f, 1.0f), 0.5f);
        bomb.GetComponent<Renderer>().material.DOColor(Color.white, 0.5f);
    }

    IEnumerator FC5(float wait)
    {
        yield return new WaitForSeconds(wait);
        ex = Instantiate(Ex, new Vector3(0.0f, 0.5f, 0.0f), Quaternion.Euler(0, 90, 0));
        Destroy(bomb);
    }
}
