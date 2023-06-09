using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorDetection : MonoBehaviour
{
    NormalMonitorManager normalMonitorManager = NormalMonitorManager.instance;
    public bool Detection;
    private bool Detectionable;
    //SerializeField�ɕύX
    [SerializeField] GameObject monitor;
    [SerializeField] MonitorEffect monitoreffect;
    //

    //�ǉ�
    MeshRenderer meshRenderer;
    //
    // Start is called before the first frame update
    void Start()
    {
        Detection = false;
        Debug.Log(Detection);
        Detectionable = false;
        monitor = transform.parent.gameObject;
        monitoreffect.CountText();
    }
    private void OnTriggerEnter(Collider other)
    {
        Detectionable = true;
        if (other.gameObject.tag == "Hand" && Detectionable == true)
        {
            //�ǉ�
            if (meshRenderer == null)
            {
                meshRenderer = monitor.gameObject.GetComponent<MeshRenderer>();
            }
            meshRenderer.enabled = false;
            monitoreffect.HideText();
            //
            monitoreffect.MonitorDestoryParticl();
            monitoreffect.CountText();
            normalMonitorManager.AppearanceObject();
          
            //�ǉ�
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

    //�ǉ�
    WaitForSeconds hideWait = new WaitForSeconds(0.7f);

    IEnumerator HideCoroutine()
    {
        yield return hideWait;
        normalMonitorManager.ReturnObjectToPool(monitor);
    }
    //
}
