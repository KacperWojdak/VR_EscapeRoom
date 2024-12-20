using UnityEngine;

public class AutomaticDoor : MonoBehaviour
{
    public GameObject doorLeft;
    public GameObject doorRight;
    public Vector3 doorLeftOpenPosition = new(0.7f, 0, 0);
    public Vector3 doorRightOpenPosition = new(-0.7f, 0, 0);
    private Vector3 doorLeftClosedPosition;
    private Vector3 doorRightClosedPosition;

    public float animationDuration = 1.0f;
    private bool isOpen = false;

    public AudioClip openSound;
    public AudioClip closeSound;
    public float soundVolume = 1.0f;
    private AudioSource audioSource;


    void Start()
    {
        doorLeftClosedPosition = doorLeft.transform.localPosition;
        doorRightClosedPosition = doorRight.transform.localPosition;

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isOpen)
        {
            OpenDoor();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isOpen)
        {
            CloseDoor();
        }
    }

    void OpenDoor()
    {
        LeanTween.moveLocal(doorLeft, doorLeftOpenPosition, animationDuration).setEase(LeanTweenType.easeInOutQuad);
        LeanTween.moveLocal(doorRight, doorRightOpenPosition, animationDuration).setEase(LeanTweenType.easeInOutQuad);

        if (openSound != null)
        {
            audioSource.volume = soundVolume;
            audioSource.PlayOneShot(openSound);
        }

            isOpen = true;
    }

    void CloseDoor()
    {
        LeanTween.moveLocal(doorLeft, doorLeftClosedPosition, animationDuration).setEase(LeanTweenType.easeInOutQuad);
        LeanTween.moveLocal(doorRight, doorRightClosedPosition, animationDuration).setEase(LeanTweenType.easeInOutQuad);

        if (closeSound != null)
        {
            audioSource.volume = soundVolume;
            audioSource.PlayOneShot(closeSound);
        }

            isOpen = false;
    }
}
