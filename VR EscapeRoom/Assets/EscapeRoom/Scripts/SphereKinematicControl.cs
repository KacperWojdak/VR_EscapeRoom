using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class SphereKinematicControl : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;

        var interactable = GetComponent<XRGrabInteractable>();
        if (interactable)
        {
            interactable.selectEntered.AddListener(OnGrab);
        }
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        rb.isKinematic = false;
    }
}
