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
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBomb()
    {
        bomb = Instantiate(Bomb, new Vector3(0.0f, 0.6f, 0.0f), Quaternion.Euler(0, 90, 0));
        StartCoroutine(C1(1.0f));
        StartCoroutine(C2(2.0f));
        StartCoroutine(C3(3.0f));
        StartCoroutine(C4(4.0f));
        StartCoroutine(C5(5.0f));
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
}
