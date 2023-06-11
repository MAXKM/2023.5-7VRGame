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

        // DOTween�̃V�[�P���X���쐬
        var sequence = DOTween.Sequence();
        _text.color = resetCol;
        sequence.Append(rectTransform.DOScale(new Vector3(-0.8f, 0.8f, 0.8f), 0.01f));

        _text.text = damage.ToString();

        // �ŏ��Ɋg��\������
        sequence.Append(rectTransform.DOScale(new Vector3(-1f, 1f, 1f), 0.5f));

        // ���ɏ�ֈړ�������
        sequence.Append(rectTransform.DOMoveY(0.05f, 1f).SetRelative());

        // ���݂̐F���擾
        var color = _text.color;

        // �A���t�@�l��0�Ɏw�肵�ĕ����𓧖��ɂ���
        color.a = 0.0f;

        // ��Ɉړ��Ɠ����ɔ������ɂ��ď�����悤�ɂ���
        sequence.Join(DOTween.To(() => _text.color, c => _text.color = c, color, 1f).SetEase(Ease.InOutQuart));

        // ���ׂẴA�j���[�V�������I�������A�������g���\���ɂ���
        sequence.OnComplete(() => gameObject.SetActive(false));
    }
}
