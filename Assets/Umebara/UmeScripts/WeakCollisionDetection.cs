using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakCollisionDetection : MonoBehaviour
{
    // Start is called before the first frame update
    NewWeakPoint newweakpoint;
    public bool HandOver;
    SkillManager skillmanager;
    HandDetection handdetection;
    HPGauge hpgauge;
    MIDDLE_BOSS middleboss;
    void Start()
    {
        newweakpoint = GameObject.FindGameObjectWithTag("Weak").GetComponent<NewWeakPoint>();
        skillmanager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SkillManager>();
        middleboss = GameObject.FindGameObjectWithTag("MB").GetComponent<MIDDLE_BOSS>();
        hpgauge = GameObject.FindGameObjectWithTag("HG").GetComponent<HPGauge>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LeftHand") || other.gameObject.CompareTag("RightHand") && newweakpoint.weak == false)
        {
            newweakpoint.weak = true;
            Changed();
            Vector3 contactPoint = other.ClosestPoint(transform.position);
            if (other.gameObject.tag == "LeftHand")
            {
                if (handdetection == null)
                {
                    GameObject obj = GameObject.FindGameObjectWithTag("RightHand");
                    handdetection = obj.GetComponent<HandDetection>();
                }
                if (handdetection.distanceLeft < 0.5f)
                {
                    handdetection.ResetDistance();
                    skillmanager.BDamage(contactPoint, handdetection.distanceLeft);
                    return;
                }
                skillmanager.BDamage(contactPoint, handdetection.distanceLeft);
            }
            else if (other.gameObject.tag == "RightHand")
            {
                if (handdetection == null)
                {
                    handdetection = other.gameObject.GetComponent<HandDetection>();
                }
                if (handdetection.distanceRight < 0.5f)
                {
                    handdetection.ResetDistance();
                    skillmanager.BDamage(contactPoint, handdetection.distanceRight);
                    return;
                }
                skillmanager.BDamage(contactPoint, handdetection.distanceRight);
            }
            handdetection.ResetDistance();
            middleboss.MiddleBossHp -= skillmanager.Damage;
            hpgauge.GaugeReduction(skillmanager.Damage);
            Changed();
        }
    }
    public void Changed()
    {
        Transform myTransform = this.transform;
        float y = Random.Range(0.19f, 0.6f);
        float z = Random.Range(-0.71f, 0.68f);
        Vector3 pos = new Vector3(0.1f, y, z);
        myTransform.position = pos;
        newweakpoint.weak = false;
    }
}
