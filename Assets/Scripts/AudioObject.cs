using UnityEngine;

public class AudioObject : MonoBehaviour
{
    public AudioClip[] _clips;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio(int number)
    {
        _audioSource.clip = _clips[1];
        _audioSource.Play();
    }

    private void Update()
    {
        if(_audioSource.isPlaying == false)
        {
            Destroy(gameObject);
        }
    }
}
