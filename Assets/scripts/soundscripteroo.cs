using UnityEngine;
using UnityEngine.Video;

public class soundscripteroo : MonoBehaviour
{
    public static soundscripteroo SoundInstance
    {
        get { return soundInstance; }
    }
    private static soundscripteroo soundInstance;

    private AudioSource source;

    public AudioClip screamClip;
    public AudioClip bossHurtClip;
    public AudioClip healthClip;

    private void Awake()
    {
        if (soundInstance == null)
        {
            soundInstance = this;
        }
        else
        {
            if (this != soundInstance) Destroy(this);
        }

        DontDestroyOnLoad(soundInstance);
        source = gameObject.GetComponent<AudioSource>();
    }

    public void Play(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }
}
