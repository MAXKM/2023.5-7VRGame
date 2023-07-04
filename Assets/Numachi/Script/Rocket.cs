using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] SkillManager skillManager;
    [SerializeField] ParticleSystem rocketParticle;

    //void OnEnabled()
    //{
    //    rocketParticle.Play();
    //}

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("ok");
        if (other.gameObject.CompareTag("MB"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
