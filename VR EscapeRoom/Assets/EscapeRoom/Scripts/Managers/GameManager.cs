using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Light[] riddlersDoorLights;
    public Light[] tilesRoomLights;
    public Light[] numbersRoomLights;
    public Light[] finalDoorsLights;
    public Color successColor = Color.green;
    public float lowIntensity = 0.2f;
    public float animationDuration = 1.0f;

    public bool riddlersRoomCompleted = false;
    public bool tilesRoomCompleted = false;
    public bool numbersRoomCompleted = false;


    private void Awake()
    {
        LeanTween.init(800);
    }

    public bool AllRoomsCompleted()
    {
        return riddlersRoomCompleted && tilesRoomCompleted && numbersRoomCompleted;
    }

    public void RiddlersRoomCompleted()
    {
        riddlersRoomCompleted = true;
        foreach (var light in riddlersDoorLights)
        {
            AnimateDoorLight(light);
        }

        if (finalDoorsLights.Length > 0)
        {
            Light rightLight = finalDoorsLights[2];
            AnimateFinalLight(rightLight);
        }
    }

    public void TilesRoomCompleted()
    {
        tilesRoomCompleted = true;
        foreach (var light in tilesRoomLights)
        {
            AnimateDoorLight(light);
        }

        if (finalDoorsLights.Length > 0)
        {
            Light middleLight = finalDoorsLights[1];
            AnimateFinalLight(middleLight);
        }
    }

    public void NumbersRoomCompleted()
    {
        numbersRoomCompleted = true;
        foreach (var light in numbersRoomLights)
        {
            AnimateDoorLight(light);
        }

        if (finalDoorsLights.Length > 0)
        {
            Light leftLight = finalDoorsLights[0];
            AnimateFinalLight(leftLight);
        }
    }


    private void AnimateDoorLight(Light doorLight)
    {
        LeanTween.value(doorLight.gameObject, doorLight.intensity, lowIntensity, animationDuration)
            .setOnUpdate((float intensity) => doorLight.intensity = intensity)
            .setEase(LeanTweenType.easeInOutQuad)
            .setOnComplete(() =>
            {
                LeanTween.value(doorLight.gameObject, doorLight.color, successColor, animationDuration)
                    .setOnUpdate((Color color) => doorLight.color = color)
                    .setEase(LeanTweenType.easeInOutQuad);

                LeanTween.value(doorLight.gameObject, lowIntensity, 20.0f, animationDuration)
                    .setOnUpdate((float intensity) => doorLight.intensity = intensity)
                    .setEase(LeanTweenType.easeInOutQuad)
                    .setOnComplete(() =>
                    {
                        doorLight.intensity = 20.0f;
                    });
            });
    }

    private void AnimateFinalLight(Light finalLight)
    {
        LeanTween.value(finalLight.gameObject, finalLight.intensity, lowIntensity, animationDuration)
            .setOnUpdate((float intensity) => finalLight.intensity = intensity)
            .setEase(LeanTweenType.easeInOutQuad)
            .setOnComplete(() =>
            {
                LeanTween.value(finalLight.gameObject, finalLight.color, successColor, animationDuration)
                    .setOnUpdate((Color color) => finalLight.color = color)
                    .setEase(LeanTweenType.easeInOutQuad);

                LeanTween.value(finalLight.gameObject, lowIntensity, 20.0f, animationDuration)
                    .setOnUpdate((float intensity) => finalLight.intensity = intensity)
                    .setEase(LeanTweenType.easeInOutQuad)
                    .setOnComplete(() =>
                    {
                        finalLight.intensity = 20.0f;
                    });
            });
    }
}
