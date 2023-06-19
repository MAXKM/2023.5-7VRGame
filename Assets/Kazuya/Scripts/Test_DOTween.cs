using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Test_DOTween : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DownMoving();
        UpMovig();
    }

    // Update is called once per frame
   void DownMoving()
    {
        transform.DOLocalMoveY(0f, 0.5f);
        transform.DOScale(new Vector3(2f, 2f, 2f), 0.4f);
    }
    void UpMovig()
    {
        transform.DOScale(new Vector3(1f, 1f, 1f), 1f);
    }
}
