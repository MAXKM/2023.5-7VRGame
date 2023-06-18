using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorDetection : MonoBehaviour
{
    NormalMonitorManager normalMonitorManager = NormalMonitorManager.instance;
    HandDetection handdetection;
    SkillManager skillmanager;
    public bool Detection;
    private bool Detectionable;
    //SerializeFieldに変更
    [SerializeField] GameObject monitor;
    [SerializeField] MonitorEffect monitoreffect;
    //

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
        monitoreffect.CountText();
        GameObject obj = GameObject.FindGameObjectWithTag("GameController");
        skillmanager = obj.GetComponent<SkillManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Detectionable = true;
        if ((other.gameObject.tag == "LeftHand" || other.gameObject.tag == "RightHand") && Detectionable == true)
        {
            //追加
            if (meshRenderer == null)
            {
                meshRenderer = monitor.gameObject.GetComponent<MeshRenderer>();
            }
            meshRenderer.enabled = false;
            monitoreffect.HideText();
            //SkillManagerに接触通知を送る、距離の値を送る
            if (other.gameObject.tag == "LeftHand" ){
                if(handdetection == null)
                {
                    GameObject obj = GameObject.FindGameObjectWithTag("RightHand");
                    handdetection = obj.GetComponent<HandDetection>();
                }
                skillmanager.DDamage(other.ClosestPointOnBounds(this.transform.position), handdetection.distanceLeft) ;
            }else if(other.gameObject.tag == "RightHand")
            {
                if (handdetection == null)
                {
                    handdetection = other.gameObject.GetComponent<HandDetection>();
                }
                skillmanager.DDamage(other.ClosestPointOnBounds(this.transform.position) , handdetection.distanceRight);
            }
            handdetection.ResetDistance();
            monitoreffect.MonitorDestoryParticl();
            monitoreffect.CountText();
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
