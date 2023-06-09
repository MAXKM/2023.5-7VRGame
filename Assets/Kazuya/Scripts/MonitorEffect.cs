using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class MonitorEffect : MonoBehaviour
{
    //public GameObject Monitor;
    NormalMonitorManager normalMonitorManager = NormalMonitorManager.instance;
    MonitorDetection monitordetection;
    [SerializeField] ParticleSystem Destroy;
    [SerializeField] TextMeshProUGUI counttext;

    //�ǉ�
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] BoxCollider collider;
    [SerializeField] AudioClip hitsounds;
    [SerializeField] AudioClip breaksounds;
    [SerializeField] AudioSource audiosource;
    [SerializeField] AudioSource audiosource2;

    //
    // Start is called before the first frame update
    void Start()
    {
        Invoke("MonitorMoving", 0);
        //GameObject obj = GameObject.Find("HandDetection");
        //monitordetection = obj.GetComponent<MonitorDetection>();
    }

    //*�ǉ�*
    private void OnEnable()
    {
        if (!meshRenderer.enabled)
        {
            meshRenderer.enabled = true;
        }
        if (!collider.enabled)
        {
            collider.enabled = true;
        }

        MonitorMoving();
        counttext.gameObject.SetActive(true);
        CountText();
    }

    // Update is called once per frame
    void Update()
    {
        //if(monitordetection.Detection == true)
        //{
        //    //Destroy(this.gameObject);
        //}
    }

    void MonitorMoving()
    {
        transform.DOLocalMoveY(0f, 1f);
        transform.DOScale(new Vector3(1f, 1f, 1f), 1f);
    }
    public void MonitorDestoryParticl()
    {
        audiosource.PlayOneShot(hitsounds);
        audiosource2.PlayOneShot(breaksounds);
        Destroy.Play();
    }

    public void CountText()
    {
        counttext.text = (normalMonitorManager.monitorCount + 1).ToString();
    }

    public void HideText()
    {
        counttext.gameObject.SetActive(false);
    }
}
