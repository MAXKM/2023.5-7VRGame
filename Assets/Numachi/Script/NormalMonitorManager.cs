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
    private const int initialSize = 1;

    //�I�u�W�F�N�g�̏o�����W
    Vector3 firstPos = new Vector3(0, 5, 0);

    //���̖ڂ̓G�����J�E���g
    public int monitorCount = 1;

    //�G��Monitor��Material
    [SerializeField] Material[] color = new Material[8];

    //�G����MeshRenderer
    private MeshRenderer meshRenderer;

    //�S�[���h�G�o���m��
    private int goldEnemyProbability = 1;

    [SerializeField] private GameInformation gameInformation;

    private void Start()
    {
        monitorCount = 1;
    }

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

            meshRenderer = obj.GetComponent<MeshRenderer>();
            meshRenderer.material = color[Random.Range(0, 7)];

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

    private void Update()
    {
        Debug.Log(monitorCount);
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
        //��\��
        obj.SetActive(false);
    }

    //�I�u�W�F�N�g��V�����\��
    public void AppearanceObject()
    {
        //���̖ڂ����J�E���g
        monitorCount++;

        //19�̓|���Əo�����Ȃ��Ȃ�
        if(monitorCount > 19)
        {
            return;
        }
        //�I�u�W�F�N�g�v�[�����玟�ɕ\������I�u�W�F�N�g���擾
        GameObject newObj = GetObjectFromPool();

        //�I�u�W�F�N�g�̍��W��������
        newObj.transform.position = firstPos;

        //MeshREnderer����\����������\��������
        //if (!meshRenderer.enabled)
        //{
        //    meshRenderer.enabled = true;
        //}

        //�F��ύX
        meshRenderer = newObj.GetComponent<MeshRenderer>();

        //�S�[���h�G�̊m�����v�Z
        goldEnemyProbability = GoldEnemyProbabilityCalculation(gameInformation.goldEnemyProbabilityLevel);

        //�m���ŃS�[���h�G���o��
        if (Random.Range(0,10) < goldEnemyProbability)
        {
            //7�Ԗڂ̃}�e���A�����S�[���h
            //�}�e���A�����S�[���h�ɕύX
            meshRenderer.material = color[7]; 
        }
        else
        {
            //�ʏ�̃��j�^�[�̐F�������_���ŕύX
            meshRenderer.material = color[Random.Range(0,7)];
        }

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

    //�S�[���h�G�̊m�����v�Z
    private int GoldEnemyProbabilityCalculation(int level)
    {
        //���x���ʂɊm�����v�Z
        switch (level)
        {
            case 1:
                goldEnemyProbability = 1;
                break;
            case 2:
                goldEnemyProbability = 2;
                break;
            case 3:
                goldEnemyProbability = 3;
                break;
            case 4:
                goldEnemyProbability = 4;
                break;
            case 5:
                goldEnemyProbability = 5;
                break;
        }

        return goldEnemyProbability;
    }
}
