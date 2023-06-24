using Newtonsoft.Json.Linq;
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
    private const int initialSize = 1;

    //オブジェクトの出現座標
    Vector3 firstPos = new Vector3(0, 5, 0);

    //何体目の敵かをカウント
    public int monitorCount;

    //雑魚MonitorのMaterial
    [SerializeField] Material[] color = new Material[5];

    //雑魚Monitorのmesh
    [SerializeField] Mesh[] mesh = new Mesh[5];

    //雑魚のMeshRenderer
    private MeshRenderer meshRenderer;

    //雑魚のMeshfilter
    private MeshFilter meshFilter;

    //ゴールド敵出現確率
    private int goldEnemyProbability = 1;

    public int _currentCoin;

    [SerializeField] private GameInformation gameInformation;

    private void Start()
    {
        this.gameObject.SetActive(false);
        _currentCoin = 0;
    }

    //Awake関数でオブジェクトプールの初期化
    private void Awake()
    {
        //インスタンス化
        if(instance == null)
        {
            instance = this;
        }

        //2体目の敵からカウント
        monitorCount = 1;

        objectPool = new List<GameObject>();

        //initialSize分最初に生成
        for(int i = 0;i < initialSize; i++)
        {
            GameObject obj = Instantiate(prefab,firstPos,Quaternion.identity);

            meshRenderer = obj.transform.GetChild(0).GetComponent<MeshRenderer>();
            meshFilter = obj.transform.GetChild(0).GetComponent<MeshFilter>();

            int monitorNum = Random.Range(0, 5);
            meshRenderer.material = color[monitorNum];
            meshFilter.mesh = mesh[monitorNum];

            if(monitorNum == 4)
            {
                //4 => ゴールド敵
                //ゴールド敵のタグに変更
                obj.tag = "Gold";
            }
            else
            {
                obj.tag = "Normal";
            }

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
        Debug.Log("現在コイン:" + _currentCoin);
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
        //非表示
        obj.SetActive(false);

        //倒したタイミングでコイン加算
        CoinCalculation(obj);
    }

    //オブジェクトを新しく表示
    public void AppearanceObject()
    {
        //何体目かをカウント
        monitorCount++;

        //19体倒すと出現しなくなる
        if(monitorCount > 19 - 1)
        {
            return;
        }
        //オブジェクトプールから次に表示するオブジェクトを取得
        GameObject newObj = GetObjectFromPool();

        //オブジェクトの座標を初期化
        newObj.transform.position = firstPos;

        //色、形状を変更
        meshRenderer = newObj.transform.GetChild(0).GetComponent<MeshRenderer>();
        meshFilter = newObj.transform.GetChild(0).GetComponent<MeshFilter>();

        //ゴールド敵の確率を計算
        goldEnemyProbability = GoldEnemyProbabilityCalculation(gameInformation.goldEnemyProbabilityLevel);

        //確率でゴールド敵を出現
        if (Random.Range(0,10) < goldEnemyProbability)
        {
            //4番目のマテリアルがゴールド
            //マテリアルをゴールドに変更
            meshRenderer.material = color[4];

            //ゴールド敵の形状に変更
            meshFilter.mesh = mesh[4];

            //ゴールド敵用タグに変更
            newObj.tag = "Gold";
        }
        else
        {
            //通常のモニターの色をランダムで変更
            int monitorNum = Random.Range(0, 4);
            meshRenderer.material = color[monitorNum];
            meshFilter.mesh = mesh[monitorNum];

            //ノーマルタグに変更
            newObj.tag = "Normal";
        }

        //オブジェクトを表示
        newObj.SetActive(true);
    }

    private void CoinCalculation(GameObject monitor)
    {
        if (monitor.CompareTag("Normal"))
        {
            _currentCoin += 10;
        }
        else if (monitor.CompareTag("Gold"))
        {
            _currentCoin += 10 * 2;
        }
    }

    //ゴールド敵の確率を計算
    private int GoldEnemyProbabilityCalculation(int level)
    {
        //レベル別に確率を計算
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
