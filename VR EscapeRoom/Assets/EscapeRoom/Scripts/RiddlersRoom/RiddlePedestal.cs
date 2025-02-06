using UnityEngine;

public class RiddlePedestal : MonoBehaviour
{
    public string acceptedTag;
    public Transform itemPlaceholder;
    public float animationDuration = 2.0f;
    public Light pedestalLight;
    public Color defaultLightColor = Color.white;
    public Color correctLightColor = Color.green;

    public bool hasCorrectItem = false;

    private void Start()
    {
        if (pedestalLight == null)
            pedestalLight = GetComponentInChildren<Light>();

        if (pedestalLight != null)
            pedestalLight.color = defaultLightColor;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(acceptedTag))
        {
            hasCorrectItem = true;
            AnimateItemToPlaceholder(other.gameObject);
        }
    }

    private void AnimateItemToPlaceholder(GameObject item)
    {
        if (item.TryGetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>(out var grabInteractable))
        {
            Destroy(grabInteractable);
        }

        if (item.TryGetComponent<Rigidbody>(out var rigidbody))
        {
            Destroy(rigidbody);
        }

        LeanTween.move(item, itemPlaceholder.position, animationDuration).setEase(LeanTweenType.easeInOutQuad);
        LeanTween.rotate(item, itemPlaceholder.rotation.eulerAngles, animationDuration).setEase(LeanTweenType.easeInOutQuad)
            .setOnComplete(() =>
            {
                item.transform.SetParent(itemPlaceholder);

                StartLevitation(item);

                UpdateLightColor();
            });
    }

    private void StartLevitation(GameObject item)
    {
        LeanTween.moveY(item, itemPlaceholder.position.y + 0.1f, 1.0f)
            .setEase(LeanTweenType.easeInOutSine)
            .setLoopPingPong();

        LeanTween.rotateAround(item, Vector3.up, 360f, 3.0f)
            .setEase(LeanTweenType.linear)
            .setLoopClamp();
    }

    private void UpdateLightColor()
    {
        if (pedestalLight != null)
        {
            Color targetColor = hasCorrectItem ? correctLightColor : defaultLightColor;
            LeanTween.value(gameObject, pedestalLight.color, targetColor, 0.5f)
                .setOnUpdate((Color color) =>
                {
                    pedestalLight.color = color;
                });
        }
    }

}
