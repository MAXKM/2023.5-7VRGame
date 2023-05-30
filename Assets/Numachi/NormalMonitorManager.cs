using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMonitorManager : MonoBehaviour
{
    //NormalMonitorManaher�̃C���X�^���X
    public static NormalMonitorManager instance;

    //�v�[������I�u�W�F�N�g
    [SerializeField] GameObject prefab;

    //�v�[���̃I�u�W�F�N�g���X�g
    private List<GameObject> objectPool;

    //�v�[�������
    private const int initialSize = 2;

    //�I�u�W�F�N�g�̏o�����W
    Vector3 firstPos = new Vector3(0, 5, 0);

    //Awake�֐��ŃI�u�W�F�N�g�v�[���̏�����
    private void Awake()
    {
        //�C���X�^���X��
        if(instance == null)
        {
            instance = this;
        }

        objectPool = new List<GameObject>();

        //initialSize���ŏ��ɐ���
        for(int i = 0;i < initialSize; i++)
        {
            GameObject obj = Instantiate(prefab,firstPos,Quaternion.identity);

            //�ŏ��̂ЂƂ����\��
            if (i == 0)
            {
                obj.SetActive(true);
            }
            else
            {
                obj.SetActive(false);
            }

            //���X�g�Ƀ��j�^�[��ǉ�
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

    //�I�u�W�F�N�g��V�����\��
    public void AppearanceObject()
    {
        //�I�u�W�F�N�g�v�[�����玟�ɕ\������I�u�W�F�N�g���擾
        GameObject newObj = GetObjectFromPool();

        //�I�u�W�F�N�g�̍��W��������
        newObj.transform.position = firstPos;

        //�I�u�W�F�N�g��\��
        newObj.SetActive(true);
    }

    ////WaitForSeconds�̃L���b�V��
    //WaitForSeconds waitForSeconds = new WaitForSeconds(0.5f);

    ////�o���������j�^�[�̃R���C�_�[�𑗂点�ėL��������R���[�`��
    //private IEnumerator ColliderDelayCoroutine(GameObject obj)
    //{
    //    yield return waitForSeconds;
    //    obj.GetComponent<BoxCollider>().enabled = true;
    //}
}
