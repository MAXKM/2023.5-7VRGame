using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorDetection : MonoBehaviour
{
    NormalMonitorManager normalMonitorManager = NormalMonitorManager.instance;
    public bool Detection;
    private bool Detectionable;
    GameObject monitor;
    [SerializeField] MonitorEffect monitoreffect;
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
        if (other.gameObject.tag=="Hand" && Detectionable == true)
        {
            normalMonitorManager.AppearanceObject();
            normalMonitorManager.ReturnObjectToPool(monitor);
            Detection = true;
            monitoreffect.MonitorDestoryParticl();
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
