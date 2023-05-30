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

    GameObject monitor;
    // Start is called before the first frame update
    void Start()
    {
        monitor = transform.parent.gameObject;
        Detection = false;
        Debug.Log(Detection);
        Detectionable = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        Detectionable = true;
        if (other.gameObject.tag == "Hand" && Detectionable == true)
        {
            normalMonitorManager.AppearanceObject();
            normalMonitorManager.ReturnObjectToPool(monitor);
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

}

