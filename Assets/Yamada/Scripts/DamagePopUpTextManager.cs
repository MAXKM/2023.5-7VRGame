using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePopUpTextManager : MonoBehaviour
{
    [SerializeField] DamagePopUpText damageText;

    // アクティブなテキストのリスト
    private List<DamagePopUpText> activeList = new List<DamagePopUpText>();
    // 非アクティブなテキストのオブジェクトプール
    private Stack<DamagePopUpText> inactivePool = new Stack<DamagePopUpText>();

    private void Update()
    {
        // 逆順にループを回して、activeListの要素が途中で削除されても正しくループが回るようにする
        for (int i = activeList.Count - 1; i >= 0; i--)
        {
            var damageText = activeList[i];
            if (!damageText.IsActive)
            {
                Remove(damageText);
            }
        }
    }

    // テキストを非アクティブ化するメソッド
    public void Remove(DamagePopUpText damageText)
    {
        activeList.Remove(damageText);
        inactivePool.Push(damageText);
    }

    // テキストをアクティブ化するメソッド
    public void Active(Vector3 pos, float damage)
    {
        // 非アクティブのテキストがあれば使い回す、なければ生成する
        var DamageText = (inactivePool.Count > 0) ? inactivePool.Pop() : Instantiate(damageText, transform);

        DamageText.gameObject.SetActive(true);

        //生成位置がそのままでは上手く行かないカモ
        DamageText.Init(pos, damage);
        activeList.Add(DamageText);
    }
}
