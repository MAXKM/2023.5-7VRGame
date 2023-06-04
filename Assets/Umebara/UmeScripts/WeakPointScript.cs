using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPointScript : MonoBehaviour
{
    //�C���X�^���X
    static public WeakPointScript instance;
    //���딻��
    public bool weak;
    // ��������v���n�u�i�[�p
    public GameObject prefabWeak;

    /*GI���擾
    public GameInformation gameInformation;*/

    //weakpoint�̐����`
    private int weakQuantity;

    private void Awake()
    {
        //�C���X�^���X��
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        weak = false;

        /*GI�ɂ���weakPointNumLevel��weakQuantity�ɒu������
        weakQuantity = gameInformation.weakPointNumLevel;*/

        weakQuantity = 2;

        //��_����
        for (int i = 0; i < weakQuantity; i++)
        {
            float x = Random.Range(-5.0f, 5.0f);
            float y = Random.Range(-5.0f, 5.0f);
            Vector3 pos = new Vector3(x, y, 1.3f);
            Instantiate(prefabWeak, pos, Quaternion.identity);
        }
    }

    void Update()
    {
        
    }

    //����������
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("hand") && weak == false)
        {
            weak = true;
            Changed();
            weak = false;
        }
    }

    //��_���ړ�������
    public void Changed()
    {
        Transform myTransform = this.transform;
        float x = Random.Range(-5.0f, 5.0f);
        float y = Random.Range(-5.0f, 5.0f);
        Vector3 pos = new Vector3(x, y, 1.3f);
        myTransform.position = pos;
    }
}
