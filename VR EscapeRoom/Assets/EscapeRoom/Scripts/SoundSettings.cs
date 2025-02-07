using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    [SerializeField] private Slider musicVolumeSlider;

    private void Start()
    {
        if (musicVolumeSlider != null)
        {
            float savedVolume = MusicManager.Instance.GetVolume();
            musicVolumeSlider.value = savedVolume;

            musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
        }
    }

    private void SetMusicVolume(float volume)
    {
        MusicManager.Instance.SetVolume(volume);
    }
}
