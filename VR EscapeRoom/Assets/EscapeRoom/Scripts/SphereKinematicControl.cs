using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class SphereKinematicControl : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; // Pocz¹tkowy stan kinematyczny

        var interactable = GetComponent<XRGrabInteractable>();
        if (interactable)
        {
            interactable.selectEntered.AddListener(OnGrab);
            interactable.selectExited.AddListener(OnRelease);
        }
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        rb.isKinematic = false; // Wy³¹czenie kinematyki przy podniesieniu
    }

    void OnRelease(SelectExitEventArgs args)
    {
        rb.isKinematic = false; // Upewnij siê, ¿e fizyka dzia³a po zwolnieniu
    }
}
