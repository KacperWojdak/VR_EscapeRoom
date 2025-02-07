using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    private AudioSource audioSource;

    [SerializeField]
    private List<AudioClip> musicTracks;

    [SerializeField]
    private float fadeDuration = 1f;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        PlayRandomTrackWithFade();
    }

    private void Update()
    {
        if (!audioSource.isPlaying && audioSource.clip != null)
        {
            PlayRandomTrackWithFade();
        }
    }

    public void PlayRandomTrackWithFade()
    {
        if (musicTracks.Count == 0)
        {
            Debug.LogWarning("Brak utworów w liœcie!");
            return;
        }

        AudioClip randomTrack = musicTracks[Random.Range(0, musicTracks.Count)];

        while (randomTrack == audioSource.clip && musicTracks.Count > 1)
        {
            randomTrack = musicTracks[Random.Range(0, musicTracks.Count)];
        }

        StartCoroutine(FadeToTrack(randomTrack));
    }

    private IEnumerator FadeToTrack(AudioClip newTrack)
    {
        float startVolume = audioSource.volume;
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(startVolume, 0, t / fadeDuration);
            yield return null;
        }

        audioSource.volume = 0;
        audioSource.Stop();
        audioSource.clip = newTrack;
        audioSource.Play();

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(0, startVolume, t / fadeDuration);
            yield return null;
        }

        audioSource.volume = startVolume;
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
