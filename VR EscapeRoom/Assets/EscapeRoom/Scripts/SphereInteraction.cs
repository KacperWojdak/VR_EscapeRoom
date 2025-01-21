using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class SphereInteraction : MonoBehaviour
{
    public Material defaultMaterial;
    public Material highlightMaterial;
    public float highlightDistance = 2.0f;
    public Transform playerTransform;

    private XRGrabInteractable grabInteractable;
    private Renderer sphereRenderer;
    private bool isInteractableAdded = false;

    private void Start()
    {
        sphereRenderer = GetComponent<Renderer>();
        if (sphereRenderer != null)
        {
            sphereRenderer.material = defaultMaterial;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("XRController"))
        {
            AddGrabInteractable();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("XRController"))
        {
            RemoveGrabInteractable();
        }
    }

    private void Update()
    {
        if (isInteractableAdded && playerTransform != null)
        {
            float distance = Vector3.Distance(transform.position, playerTransform.position);

            if (distance <= highlightDistance)
            {
                sphereRenderer.material = highlightMaterial;
            }
            else
            {
                sphereRenderer.material = defaultMaterial;
            }
        }
    }

    private void AddGrabInteractable()
    {
        if (!isInteractableAdded)
        {
            grabInteractable = gameObject.AddComponent<XRGrabInteractable>();
            isInteractableAdded = true;
        }
    }

    private void RemoveGrabInteractable()
    {
        if (isInteractableAdded && grabInteractable != null)
        {
            Destroy(grabInteractable);
            isInteractableAdded = false;

            if (sphereRenderer != null)
            {
                sphereRenderer.material = defaultMaterial;
            }
        }
    }
}
