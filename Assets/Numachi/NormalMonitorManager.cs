using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMonitorManager : MonoBehaviour
{
    //NormalMonitorManaherのインスタンス
    public static NormalMonitorManager instance;

    //プールするオブジェクト
    [SerializeField] GameObject prefab;

    //プールのオブジェクトリスト
    private List<GameObject> objectPool;

    //プールする個数
    private const int initialSize = 2;

    //オブジェクトの出現座標
    Vector3 firstPos = new Vector3(0, 5, 0);

    //倒した数カウント
    public int monitorCount = 0;

    //雑魚MonitorのMaterial
    [SerializeField] Material[] color = new Material[8];

    //雑魚のMeshRenderer
    MeshRenderer meshRenderer;

    //ゴールド敵出現確率
    private int goldEnemyProbability = 1;

    //Awake関数でオブジェクトプールの初期化
    private void Awake()
    {
        //インスタンス化
        if(instance == null)
        {
            instance = this;
        }

        objectPool = new List<GameObject>();

        //initialSize分最初に生成
        for(int i = 0;i < initialSize; i++)
        {
            GameObject obj = Instantiate(prefab,firstPos,Quaternion.identity);

            meshRenderer = obj.GetComponent<MeshRenderer>();
            meshRenderer.material = color[Random.Range(0, 7)];

            //最初のひとつだけ表示
            if (i == 0)
            {
                obj.SetActive(true);
            }
            else
            {
                obj.SetActive(false);
            }

            //リストにモニターを追加
            objectPool.Add(obj);
        }
    }

    private void Update()
    {
        Debug.Log(monitorCount);
    }

    //オブジェクトをプールから取得
    private GameObject GetObjectFromPool()
    {
        for(int i = 0;i < objectPool.Count; i++)
        {
            //非表示になっているものを探し、あったら再利用
            if (!objectPool[i].activeSelf)
            {
                return objectPool[i];
            }
        }
        //非表示になっているものがなければ新しく作る
        GameObject newObj = Instantiate(prefab);
        objectPool.Add(newObj);
        return newObj;
    }

    //いらなくなったオブジェクトをプールに戻す
    public void ReturnObjectToPool(GameObject obj)
    {
        //敵を倒すたびにカウント
        monitorCount++;

        //非表示
        obj.SetActive(false);
    }

    //オブジェクトを新しく表示
    public void AppearanceObject()
    {
        //19体倒すと出現しなくなる
        if(monitorCount >= 19 - 1)
        {
            return;
        }
        //オブジェクトプールから次に表示するオブジェクトを取得
        GameObject newObj = GetObjectFromPool();

        //オブジェクトの座標を初期化
        newObj.transform.position = firstPos;

        //色を変更
        meshRenderer = newObj.GetComponent<MeshRenderer>();

        //確率でゴールド敵を出現
        if (Random.Range(0,10) < goldEnemyProbability)
        {
            //7番目のマテリアルがゴールド
            //マテリアルをゴールドに変更
            meshRenderer.material = color[7]; 
        }
        else
        {
            //通常のモニターの色をランダムで変更
            meshRenderer.material = color[Random.Range(0,7)];
        }

        //オブジェクトを表示
        newObj.SetActive(true);
    }

    ////WaitForSecondsのキャッシュ
    //WaitForSeconds waitForSeconds = new WaitForSeconds(0.5f);

    ////出現したモニターのコライダーを送らせて有効化するコルーチン
    //private IEnumerator ColliderDelayCoroutine(GameObject obj)
    //{
    //    yield return waitForSeconds;
    //    obj.GetComponent<BoxCollider>().enabled = true;
    //}
}
