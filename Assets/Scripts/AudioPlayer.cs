using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public static AudioPlayer Instance;
    [SerializeField] private GameObject _audioObject;

    private void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void PlayAudio(int number)
    {
        GameObject audioObject = Instantiate(_audioObject, Vector3.zero, Quaternion.identity);
        audioObject.GetComponent<AudioObject>().PlayAudio(number);
    }
}
