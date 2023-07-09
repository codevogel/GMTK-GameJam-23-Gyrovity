using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance;

    private static AudioSource _source;

    [SerializeField] private AudioClip rotate;
    [SerializeField] private AudioClip hit;
    [SerializeField] private AudioClip key;
    [SerializeField] private AudioClip fail;
    [SerializeField] private AudioClip success;

    private void Awake()
    {
        Instance = this;
        if (_source == null)
        {
            _source = GetComponent<AudioSource>();
        }
    }

    public void PlayRotate()
    {
        _source.PlayOneShot(rotate);
    }

    public void PlayHit()
    {
        _source.PlayOneShot(hit);
    }

    public void PlayKey()
    {
        _source.PlayOneShot(key);
    }

    public void PlayFail()
    {
        _source.PlayOneShot(fail);
    }

    public void PlaySuccess()
    {
        _source.PlayOneShot(success);
    }
}
