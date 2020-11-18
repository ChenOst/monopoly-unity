using UnityEngine;

public class AudioController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioSource[] _allAudioSources;

    private float audioVolume = 0.10f;

    // Update is called once per frame
    private void Update()
    {
        foreach (var audioSource in _allAudioSources) audioSource.volume = audioVolume;
    }

    public void SetVolume(float vol)
    {
        audioVolume = vol;
    }
}