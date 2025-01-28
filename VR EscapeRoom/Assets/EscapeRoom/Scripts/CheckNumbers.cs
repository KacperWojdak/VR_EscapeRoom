using UnityEngine;
using UnityEngine.UI;

public class CheckNumbers : MonoBehaviour
{
    public RandomSphereNumbers randomSphereNumbers;
    public Text[] playerInputTexts;
    public GameObject[] plusButtons;
    public GameObject[] minusButtons;

    public void CheckPlayerNumbers()
    {
        string generatedNumber = randomSphereNumbers.randomNumber.ToString();
        bool isCorrect = true;

        for (int i = 0; i < playerInputTexts.Length; i++)
        {
            int playerNumber = int.Parse(playerInputTexts[i].text);
            int generatedDigit = int.Parse(generatedNumber[i].ToString());

            if (playerNumber != generatedDigit)
            {
                isCorrect = false;
                playerInputTexts[i].color = Color.red;
            }
            else
            {
                playerInputTexts[i].color = Color.green;

                plusButtons[i]?.SetActive(false);
                minusButtons[i]?.SetActive(false);
            }
        }

        if (isCorrect)
        {
            Debug.Log("Brawo! Wszystkie liczby s¹ poprawne!");
        }
        else
        {
            Debug.Log("Niestety, s¹ b³êdy. Spróbuj ponownie.");
        }
    }
}
