using System.Collections;
using DG.Tweening;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private void Awake() => StartCoroutine(nameof(Death), 5);

    private IEnumerator Death()
    {
        yield return new WaitForSeconds(5);
        transform.DOScale(0, 1).OnComplete((() => Destroy(gameObject)));
    }
}