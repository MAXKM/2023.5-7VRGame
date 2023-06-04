using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPointGeneration : MonoBehaviour
{
    static public WeakPointGeneration instance;
    // ��������v���n�u�i�[�p
    public GameObject prefabWeak;
    //GI���擾
    public GameInformation gameInformation;
    //weakpoint�̐����`
    private int weakQuantity;
    private bool produce;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        //GI�ɂ���weakPointNumLevel��weakQuantity�ɒu������
        weakQuantity = gameInformation.weakPointNumLevel;
        weakQuantity = 2;
        // �v���n�u�𐶐�
        for (int i = 0; i < weakQuantity; i++)
        {
            float x = Random.Range(-5.0f, 5.0f);
            float y = Random.Range(-5.0f, 5.0f);
            Vector3 pos = new Vector3(x, y, 1.3f);
            Instantiate(prefabWeak, pos, Quaternion.identity);
        }

    }
    /*private void Update()
    {
        produce = WeakPointScript.instance.weak;
        if (produce == true)
        {
            Debug.Log("B");
            float x = Random.Range(-5.0f, 5.0f);
            float y = Random.Range(-5.0f, 5.0f);
            Vector3 pos = new Vector3(x, y, 1.3f);
            Instantiate(prefabWeak, pos, Quaternion.identity);
        }
    }
    */
    public void Changed()
    {
        Transform myTransform = this.transform;
        float x = Random.Range(-5.0f, 5.0f);
        float y = Random.Range(-5.0f, 5.0f);
        Vector3 pos = new Vector3(x, y, 1.3f);
        myTransform.position = pos;
    }
}
