using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPointScript : MonoBehaviour
{
    //インスタンス
    static public WeakPointScript instance;
    //正誤判定
    public bool weak;
    // 生成するプレハブ格納用
    public GameObject prefabWeak;

    /*GIを取得
    public GameInformation gameInformation;*/

    //weakpointの数を定義
    private int weakQuantity;

    private void Awake()
    {
        //インスタンス化
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        weak = false;

        /*GIにあるweakPointNumLevelをweakQuantityに置き換え
        weakQuantity = gameInformation.weakPointNumLevel;*/

        weakQuantity = 2;

        //弱点生成
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

    //当たった時
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("hand") && weak == false)
        {
            weak = true;
            Changed();
            weak = false;
        }
    }

    //弱点を移動させる
    public void Changed()
    {
        Transform myTransform = this.transform;
        float x = Random.Range(-5.0f, 5.0f);
        float y = Random.Range(-5.0f, 5.0f);
        Vector3 pos = new Vector3(x, y, 1.3f);
        myTransform.position = pos;
    }
}
