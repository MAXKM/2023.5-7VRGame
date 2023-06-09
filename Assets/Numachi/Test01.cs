using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class Test01 : MonoBehaviour
{
    NormalMonitorManager normalMonitorManager = NormalMonitorManager.instance;
    public bool Detection;
    private bool Detectionable;
    //SerializeFieldに変更
    [SerializeField] GameObject monitor;
    [SerializeField] Test02 monitoreffect;

    //追加
    MeshRenderer meshRenderer;
    //
    // Start is called before the first frame update
    void Start()
    {
        Detection = false;
        Debug.Log(Detection);
        Detectionable = false;
        monitor = transform.parent.gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        Detectionable = true;
        if (other.gameObject.tag == "Hand" && Detectionable == true)
        {
            //追加
            if (meshRenderer == null)
            {
                meshRenderer = monitor.gameObject.GetComponent<MeshRenderer>();
            }
            meshRenderer.enabled = false;
            //
            monitoreffect.MonitorDestoryParticl();
            normalMonitorManager.AppearanceObject();
            //追加
            StartCoroutine(HideCoroutine());
            //
            Detection = true;
            Debug.Log(Detection);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        Detectionable = false;
        if (other.gameObject.tag == "Hand" && Detectionable == false)
        {
            Detection = false;
            Debug.Log(Detection);
        }
    }

    //追加
    WaitForSeconds hideWait = new WaitForSeconds(0.7f);

    IEnumerator HideCoroutine()
    {
        yield return hideWait;
        normalMonitorManager.ReturnObjectToPool(monitor);
    }
    //
}

