using UnityEngine;

public class SphereWithText : MonoBehaviour
{
    public Transform textObject;
    public float offsetFromSphere = 0.1f;

    void Update()
    {
        Vector3 direction = (textObject.position - transform.position).normalized;
        textObject.position = transform.position + direction * (transform.localScale.x / 2 + offsetFromSphere);
        textObject.LookAt(transform.position);
    }
}
