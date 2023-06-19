using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstMonitor : MonoBehaviour
{
    [SerializeField]GameManager gameManager;
    [SerializeField]NormalMonitorManager normalMonitorManager;
    [SerializeField] ParticleSystem Destroy;
    HandDetection handdetection;
    [SerializeField]SkillManager skillmanager;
    MeshRenderer meshRenderer;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        Vector3 contactPoint = other.ClosestPoint(transform.position);
        gameManager.gameStart = true;
        //normalMonitorManager.monitorCount++;
        if (meshRenderer == null)
        {
            meshRenderer = this.gameObject.GetComponent<MeshRenderer>();
        }
        
        if (other.gameObject.tag == "LeftHand")
        {
            if (handdetection == null)
            {
                GameObject obj = GameObject.FindGameObjectWithTag("RightHand");
                handdetection = obj.GetComponent<HandDetection>();
            }
            skillmanager.DDamage(contactPoint, handdetection.distanceLeft);
        }
        else if (other.gameObject.tag == "RightHand")
        {
            if (handdetection == null)
            {
                handdetection = other.gameObject.GetComponent<HandDetection>();
            }
            skillmanager.DDamage(contactPoint, handdetection.distanceRight);
        }
        meshRenderer.enabled = false;
        Destroy.Play();
        StartCoroutine(HideCoroutine());

    }
    WaitForSeconds hideWait = new WaitForSeconds(0.7f);

    IEnumerator HideCoroutine()
    {
        yield return hideWait;
        normalMonitorManager.ReturnObjectToPool(this.gameObject);
    }
}
