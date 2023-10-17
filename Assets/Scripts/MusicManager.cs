using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        MusicManager[] musicManagers = FindObjectsOfType<MusicManager>();
        if (musicManagers.Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayMusic();
    }

    private void PlayMusic()
    {
        audioSource.Play();
    }

    public void DestroyMusicManager()
    {
        Destroy(gameObject);
    }
}
