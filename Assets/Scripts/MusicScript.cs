using UnityEngine;

public class MusicClass : MonoBehaviour
{
    private AudioSource _audioSource;

    private static MusicClass instance = null;
    public static MusicClass Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
            PlayerPrefs.SetFloat("MusicVol", 1);
            PlayerPrefs.SetInt("Res", 2);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayMusic()
    {
        _audioSource.volume = PlayerPrefs.GetFloat("MusicVol");
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }
}
