using DG.Tweening;
using UnityEngine;

public class coin : MonoBehaviour
{
    void Start()
    {
        transform.DOMoveY(0.5f, 1.5f).
        SetLoops(-1, LoopType.Yoyo).
        SetEase(Ease.InOutSine);
    }
}
