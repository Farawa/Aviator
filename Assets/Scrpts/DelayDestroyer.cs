using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class DelayDestroyer : MonoBehaviour
{
    [SerializeField] private float secondsForDestroy = 1f;
    private async void Start()
    {
        await Task.Delay(Mathf.RoundToInt(secondsForDestroy * 1000));
        Destroy(gameObject);
    }
}
