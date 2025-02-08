using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }

    public AudioSource audioSource;
    public List<AudioClip> musicTracks;
    private int currentTrackIndex = -1;
    public float fadeDuration = 1.0f;

    private const string VolumeKey = "MusicVolume";
    private const string MuteKey = "MusicMuted";

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        PlayerPrefs.SetInt(MuteKey, 0);
        PlayerPrefs.Save();

        float savedVolume = PlayerPrefs.GetFloat(VolumeKey, 1.0f);
        SetVolume(savedVolume);

        audioSource.mute = false;

        PlayNextTrack();
    }

    public void PlayNextTrack()
    {
        if (musicTracks.Count == 0) return;

        int nextTrackIndex;
        do
        {
            nextTrackIndex = Random.Range(0, musicTracks.Count);
        } while (nextTrackIndex == currentTrackIndex);

        currentTrackIndex = nextTrackIndex;
        StartCoroutine(FadeOutAndIn(musicTracks[currentTrackIndex]));
    }

    private System.Collections.IEnumerator FadeOutAndIn(AudioClip nextClip)
    {
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(GetVolume(), 0, t / fadeDuration);
            yield return null;
        }

        audioSource.clip = nextClip;
        audioSource.Play();

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(0, GetVolume(), t / fadeDuration);
            yield return null;
        }
    }

    public void FadeOutMusic(float duration)
    {
        StartCoroutine(FadeOutCoroutine(duration));
    }

    private IEnumerator FadeOutCoroutine(float duration)
    {
        float startVolume = audioSource.volume;
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            audioSource.volume = Mathf.Lerp(startVolume, 0, t / duration);
            yield return null;
        }
        audioSource.volume = 0;
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
        PlayerPrefs.SetFloat(VolumeKey, volume);
        PlayerPrefs.Save();
    }

    public float GetVolume()
    {
        return PlayerPrefs.GetFloat(VolumeKey, 1.0f);
    }
}
