using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMonitorManager : MonoBehaviour
{
    //�v�[������I�u�W�F�N�g
    [SerializeField] GameObject prefab;

    //�v�[���̃I�u�W�F�N�g���X�g
    private List<GameObject> objectPool;

    //�v�[�������
    private const int initialSize = 2;

    //Awake�֐��ŃI�u�W�F�N�g�v�[���̏�����
    private void Awake()
    {
        objectPool = new List<GameObject>();

        for(int i = 0;i < initialSize; i++)
        {
            Debug.Log("test");
            GameObject obj = Instantiate(prefab);

            //�ŏ��̂ЂƂ����\��
            if (i == 0)
            {
                obj.SetActive(true);
            }
            else
            {
                obj.SetActive(false);
            }
            objectPool.Add(obj);
        }
    }

    //�I�u�W�F�N�g���v�[������擾
    private GameObject GetObjectFromPool()
    {
        for(int i = 0;i < objectPool.Count; i++)
        {
            //��\���ɂȂ��Ă�����̂�T���A��������ė��p
            if (!objectPool[i].activeSelf)
            {
                return objectPool[i];
            }
        }

        //��\���ɂȂ��Ă�����̂��Ȃ���ΐV�������
        GameObject newObj = Instantiate(prefab);
        objectPool.Add(newObj);
        return newObj;
    }

    //����Ȃ��Ȃ����I�u�W�F�N�g���v�[���ɖ߂�
    public void ReturnObjectToPool(GameObject obj)
    {
        obj.SetActive(false);
    }
}
