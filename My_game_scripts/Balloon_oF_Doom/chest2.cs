using UnityEngine;
using DG.Tweening;

public class chest2 : MonoBehaviour
{
    public Vector3 targetScale = new Vector3(40f, 40f, 40f);
    private void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, 0.06f * Time.deltaTime);
    }
}
