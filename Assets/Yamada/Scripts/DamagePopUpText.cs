using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class DamagePopUpText : MonoBehaviour
{
    public bool IsActive => gameObject.activeSelf;
    private Transform Camera;
    private TextMeshProUGUI _text;
    private RectTransform rectTransform;

    private void Awake()
    {
        if (Camera == null)
            Camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        _text = GetComponent<TextMeshProUGUI>();
        rectTransform = GetComponent<RectTransform>();
    }

    Color resetCol = new Color(0, 0, 0, 1);
    public void Init(Vector3 pos, float damage)
    {
        rectTransform.localPosition = pos;
        Vector3 p = Camera.position;
        p.y = rectTransform.position.y;
        rectTransform.LookAt(p);

        // DOTweenのシーケンスを作成
        var sequence = DOTween.Sequence();
        _text.color = resetCol;
        sequence.Append(rectTransform.DOScale(new Vector3(-0.8f, 0.8f, 0.8f), 0.01f));

        _text.text = damage.ToString();

        // 最初に拡大表示する
        sequence.Append(rectTransform.DOScale(new Vector3(-1f, 1f, 1f), 0.5f));

        // 次に上へ移動させる
        sequence.Append(rectTransform.DOMoveY(0.05f, 1f).SetRelative());

        // 現在の色を取得
        var color = _text.color;

        // アルファ値を0に指定して文字を透明にする
        color.a = 0.0f;

        // 上に移動と同時に半透明にして消えるようにする
        sequence.Join(DOTween.To(() => _text.color, c => _text.color = c, color, 1f).SetEase(Ease.InOutQuart));

        // すべてのアニメーションが終わったら、自分自身を非表示にする
        sequence.OnComplete(() => gameObject.SetActive(false));
    }
}
