using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus;

public class HandDetection : MonoBehaviour
{
    [SerializeField] Material red,yellow;
    MeshRenderer meshRenderer;

    private bool isAttackable;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (OVRInput.Get(OVRInput.RawButton.RHandTrigger))
        {
            isAttackable = true;
        }
        else
        {
            isAttackable = false;
        }
        Debug.Log(isAttackable);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "hand" && isAttackable)
        {
            meshRenderer.material = red;
            Debug.Log("hit");
        }
    }
}
