using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    [SerializeField] private float timeLive;
    void Start()
    {
        StartCoroutine(DestroyInEndLive());
    }

    private void OnApplicationQuit()
    {
        StopAllCoroutines();
    }
    private IEnumerator DestroyInEndLive()
    {
        yield return new WaitForSeconds(timeLive);
        Destroy(gameObject);
    }
}
