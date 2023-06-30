using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FirstMonitor : MonoBehaviour
{
    [SerializeField]GameManager gameManager;
    [SerializeField]NormalMonitorManager normalMonitorManager;
    [SerializeField] ParticleSystem Destroy;
    HandDetection handdetection;
    [SerializeField]SkillManager skillmanager;
    MeshRenderer meshRenderer;
    [SerializeField] TextMeshProUGUI counttext;
    [SerializeField] GameStartAnimation gamestartanimation;
    // Start is called before the first frame update

    private void Start()
    {
        if (handdetection == null)
        {
            GameObject obj = GameObject.FindGameObjectWithTag("RightHand");
            handdetection = obj.GetComponent<HandDetection>();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "LeftHand" && other.gameObject.tag != "RightHand")
        {
            return;
        }
        Vector3 contactPoint = other.ClosestPoint(transform.position);
        gameManager.gameStart = true;
        //normalMonitorManager.monitorCount++;
        if (meshRenderer == null)
        {
            meshRenderer = this.gameObject.transform.GetChild(0).GetComponent<MeshRenderer>();
        }
        
        if (other.gameObject.tag == "LeftHand")
        {
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
        counttext.gameObject.SetActive(false);
        gamestartanimation.Fadetext();
        gamestartanimation.HideArrow();
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
