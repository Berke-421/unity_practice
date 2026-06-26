using DG.Tweening;
using UnityEngine;

public class chest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.DOMoveY(0.5f, 1.5f).
            SetLoops(-1, LoopType.Yoyo).
            SetEase(Ease.InOutBack);

        transform.DORotate(Vector3.up * 90f, 0.5f).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
    }
}
