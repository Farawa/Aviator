using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class DelayDestroyer : MonoBehaviour
{
    [SerializeField] private float secondsForDestroy = 1f;

    private void Start()
    {
        StartCoroutine(DestroyCoro());
    }

    private IEnumerator DestroyCoro()
    {
        yield return new WaitForSeconds(secondsForDestroy);
        Destroy(gameObject);
    }
}
