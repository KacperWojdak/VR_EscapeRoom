using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Pedestal : MonoBehaviour
{
    public string acceptedTag;
    public Transform itemPlaceholder;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(acceptedTag))
            PlaceItemOnPedestal(other.gameObject);
    }

    private void PlaceItemOnPedestal(GameObject item)
    {
        item.transform.SetPositionAndRotation(itemPlaceholder.position, itemPlaceholder.rotation);
        item.transform.SetParent(itemPlaceholder);

        if (item.TryGetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>(out var grabInteractable))
        {
            Destroy(grabInteractable);
        }

        if (item.TryGetComponent<Rigidbody>(out var rigidbody))
        {
            Destroy(rigidbody);
        }

        Debug.Log($"Przedmiot {item.name} został umieszczony na piedestale.");
    }
}
