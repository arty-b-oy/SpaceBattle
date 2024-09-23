using UnityEngine;
using Zenject;

public class AudioController : MonoBehaviour
{
    [Inject] private AudioConfig _audioConfig;
    private AudioSource _fonAudioSource;
    private AudioSource _gamePlayAudioSource;
    private AudioSource _bossFightAudioSource;

    public void Initialized()
    {
        CreateAudioObject(_audioConfig.FonMusic, ref _fonAudioSource, nameof(_audioConfig.FonMusic), true, true);
        CreateAudioObject(_audioConfig.GamePlayMusic, ref _gamePlayAudioSource, nameof(_audioConfig.GamePlayMusic), true);
        CreateAudioObject(_audioConfig.BossFightMusic, ref _bossFightAudioSource, nameof(_audioConfig.BossFightMusic), true);
    }

    private void CreateAudioObject(AudioClip audioClip, ref AudioSource container, string name, bool isLoop = false, bool playOnAwake = false, float volume = 1)
    {
        GameObject value = new GameObject();
        value.transform.parent = transform;
        value.name = name;
        container = value.AddComponent<AudioSource>();
        container.clip = audioClip;
        container.loop = isLoop;
        container.volume = volume;
        if (playOnAwake)
            container.Play();
    }
}
