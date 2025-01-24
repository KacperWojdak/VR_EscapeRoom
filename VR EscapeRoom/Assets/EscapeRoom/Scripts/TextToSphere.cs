using UnityEngine;

public class TextToSphere : MonoBehaviour
{
    public Transform textObject;
    public float offsetFromSphere = 0.1f;

    private Vector3 initialLocalPosition;
    private Quaternion initialLocalRotation;

    void Start()
    {
        if (textObject != null)
        {
            initialLocalPosition = textObject.localPosition;
            initialLocalRotation = textObject.localRotation;
        }
    }

    void Update()
    {
        if (textObject == null) return;

        textObject.SetLocalPositionAndRotation(initialLocalPosition, initialLocalRotation);
    }
}
