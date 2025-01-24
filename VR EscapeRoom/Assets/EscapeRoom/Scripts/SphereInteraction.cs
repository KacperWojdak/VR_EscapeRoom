using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Climbing;

public class SphereInteraction : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;

    private void Start()
    {
        var climbInteractable = GetComponent<ClimbInteractable>();
        if (climbInteractable != null)
        {
            Destroy(climbInteractable);
        }

        grabInteractable = gameObject.AddComponent<XRGrabInteractable>();

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
        rb.useGravity = true;
        rb.isKinematic = true;
        rb.interpolation = RigidbodyInterpolation.Interpolate;

        grabInteractable.selectEntered.AddListener(OnGrabbed);
        grabInteractable.selectExited.AddListener(OnReleased);
    }

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
    }

    private void OnReleased(SelectExitEventArgs args)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }
}
