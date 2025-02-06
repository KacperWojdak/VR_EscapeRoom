using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CheckNumbers : MonoBehaviour
{
    public RandomSphereNumbers randomSphereNumbers;
    public Text[] playerInputTexts;
    public GameObject[] plusButtons;
    public GameObject[] minusButtons;
    public NumbersRoomManager numbersRoomManager;
    public float blinkDuration = 1.0f;
    public float blinkInterval = 0.2f;

    public void CheckPlayerNumbers()
    {
        string generatedNumber = randomSphereNumbers.randomNumber.ToString();
        string playerNumber = "";

        foreach (var input in playerInputTexts)
        {
            playerNumber += input.text;
        }

        if (playerNumber != generatedNumber)
        {
            StartCoroutine(BlinkRedEffect());
            return;
        }

        for (int i = 0; i < playerInputTexts.Length; i++)
        {
            playerInputTexts[i].color = Color.green;
            plusButtons[i]?.SetActive(false);
            minusButtons[i]?.SetActive(false);
        }

        if (numbersRoomManager != null)
        {
            numbersRoomManager.MarkRoomAsCompleted();
        }
    }

    private IEnumerator BlinkRedEffect()
    {
        float elapsedTime = 0f;
        bool isRed = false;

        while (elapsedTime < blinkDuration)
        {
            Color newColor = isRed ? Color.white : Color.red;
            foreach (var input in playerInputTexts)
            {
                input.color = newColor;
            }

            isRed = !isRed;
            elapsedTime += blinkInterval;
            yield return new WaitForSeconds(blinkInterval);
        }

        foreach (var input in playerInputTexts)
        {
            input.color = Color.white;
        }
    }
}
