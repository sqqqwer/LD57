using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] public AudioClip restMusic;
    [SerializeField] public AudioClip tribeEnd;
    [SerializeField] public AudioClip lightEnd;

    public void Start()
    {
        Play(restMusic);
    }
    public void Play(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

}
