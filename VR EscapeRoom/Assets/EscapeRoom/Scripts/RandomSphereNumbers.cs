using UnityEngine;

public class RandomSphereNumbers : MonoBehaviour
{
    public Transform numberSpheresParent;
    public int randomNumber;

    void Start()
    {
        randomNumber = Random.Range(1111, 9999);
        Debug.Log($"Wylosowana liczba: {randomNumber}");

        string numberString = randomNumber.ToString();

        for (int i = 0; i < numberString.Length; i++)
        {
            char digit = numberString[i];

            if (i < numberSpheresParent.childCount)
            {
                Transform sphere = numberSpheresParent.GetChild(i);

                var textComponent = sphere.GetComponentInChildren<TMPro.TextMeshPro>();
                if (textComponent != null)
                {
                    textComponent.text = $"{digit}.";
                }
                else
                {
                    Debug.LogWarning($"Brak komponentu TextMeshPro w kulce: {sphere.name}");
                }
            }
        }
    }
}
