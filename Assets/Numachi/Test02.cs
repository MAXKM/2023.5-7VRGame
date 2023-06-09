using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Test02 : MonoBehaviour
{
    //public GameObject Monitor;
    MonitorDetection monitordetection;
    [SerializeField] ParticleSystem Destroy;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("MonitorMoving", 0);
        //GameObject obj = GameObject.Find("HandDetection");
        //monitordetection = obj.GetComponent<MonitorDetection>();

        //
    }

    //*’Ç‰Á*
    private void OnEnable()
    {
        MonitorMoving();
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
        Destroy.Play();
    }
}

