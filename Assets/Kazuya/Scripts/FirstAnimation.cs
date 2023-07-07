using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Video;

public class FirstAnimation : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        //sequence.Append(this.transform.DOMove(new Vector3(0f, 0f, 0f), 3f));
        //sequence.Append(this.transform.DOMove(new Vector3(0f, 2f, 0f), 2f));
        //sequence.Play();
        StartMonitorMove();
    }

    public void StartMonitorMove()
    {
        this.transform.DOMove(new Vector3(0f, 0f, 0f), 3f).OnComplete(() =>
        {
            this.transform.DOMove(new Vector3(0f, 2f, 0f), 2f).SetLoops(6, LoopType.Yoyo).SetEase(Ease.InOutQuad).OnComplete(() =>  //0f, 1f, 0f‚Öˆê•b‚ÅˆÚ“®‚·‚é‚Ì‚ð‚R‰ñŒJ‚è•Ô‚·
            {
            videoPlayer.Play();
            this.transform.DOMove(new Vector3(0f, 2f, 0f), 2f).SetDelay(10f);
            });
        
        });
    }

    // Update is called once per frame
    //videoPlayer.Play();
}
