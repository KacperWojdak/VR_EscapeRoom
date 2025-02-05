using UnityEngine;

public class GameManager : MonoBehaviour
{
    public RiddlePedestal[] pedestals;
    public Light[] riddlersDoorLights;
    public Light[] finalDoorsLights;
    public Color successColor = Color.green;
    public float lowIntensity = 0.2f;
    public float animationDuration = 1.0f;

    private void Update()
    {
        CheckRiddlesCompletion();
    }

    private void Awake()
    {
        LeanTween.init(800);
    }

    private void CheckRiddlesCompletion()
    {
        bool allCorrect = true;
        foreach (var pedestal in pedestals)
        {
            if (!pedestal.hasCorrectItem)
            {
                allCorrect = false;
                break;
            }
        }

        if (allCorrect)
            ActivateSuccessLights();
    }

    private void ActivateSuccessLights()
    {
        foreach (var light in riddlersDoorLights)
        {
            AnimateDoorLight(light);
        }

        if (finalDoorsLights.Length > 0)
        {
            Light lastLight = finalDoorsLights[^1];
            AnimateSideLight(lastLight);
        }
    }

    private void AnimateDoorLight(Light riddlersDoorLights)
    {
        LeanTween.value(riddlersDoorLights.gameObject, riddlersDoorLights.intensity, lowIntensity, animationDuration)
            .setOnUpdate((float intensity) => riddlersDoorLights.intensity = intensity)
            .setEase(LeanTweenType.easeInOutQuad)
            .setOnComplete(() =>
            {
                LeanTween.value(riddlersDoorLights.gameObject, riddlersDoorLights.color, successColor, animationDuration)
                    .setOnUpdate((Color color) => riddlersDoorLights.color = color)
                    .setEase(LeanTweenType.easeInOutQuad);

                LeanTween.value(riddlersDoorLights.gameObject, lowIntensity, 20.0f, animationDuration)
                    .setOnUpdate((float intensity) => riddlersDoorLights.intensity = intensity)
                    .setEase(LeanTweenType.easeInOutQuad)
                    .setOnComplete(() =>
                     {
                         riddlersDoorLights.intensity = 20.0f;
                     });
            });
    }

    private void AnimateSideLight(Light finalDoorsLights)
    {
        LeanTween.value(finalDoorsLights.gameObject, finalDoorsLights.intensity, lowIntensity, animationDuration)
            .setOnUpdate((float intensity) => finalDoorsLights.intensity = intensity)
            .setEase(LeanTweenType.easeInOutQuad)
            .setOnComplete(() =>
            {
                LeanTween.value(finalDoorsLights.gameObject, finalDoorsLights.color, successColor, animationDuration)
                    .setOnUpdate((Color color) => finalDoorsLights.color = color)
                    .setEase(LeanTweenType.easeInOutQuad);

                LeanTween.value(finalDoorsLights.gameObject, lowIntensity, 20.0f, animationDuration)
                    .setOnUpdate((float intensity) => finalDoorsLights.intensity = intensity)
                    .setEase(LeanTweenType.easeInOutQuad)
                    .setOnComplete(() =>
                    {
                        finalDoorsLights.intensity = 20.0f;
                    });
            });
    }
}
