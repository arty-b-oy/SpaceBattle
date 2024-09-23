using System.Collections;
using UnityEngine;

public class GameEffectsController : MonoBehaviour
{
    private Coroutine _rotationSkyBox;
    private float _speedRotationSkyBox = 1f;
    public void Initialized()
    {
        _rotationSkyBox = StartCoroutine(RotationSkyBox());
    }

    private IEnumerator RotationSkyBox()
    {
        while (true)
        {
            RenderSettings.skybox.SetFloat("_Rotation", Time.time * _speedRotationSkyBox);
            yield return null;
        }
    }

    private void OnApplicationQuit() => StopAllCoroutines();

}
