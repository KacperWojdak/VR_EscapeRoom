using UnityEngine;

public class EnableButton : MonoBehaviour
{
    public GameObject button;
    private bool hasActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasActivated && other.CompareTag("Player"))
        {
            hasActivated = true;

            var components = button.GetComponents<MonoBehaviour>();
            foreach (var component in components)
            {
                component.enabled = true;
            }
        }
    }
}
