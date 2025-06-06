using UnityEngine;

public class RandomSphereNumbers : MonoBehaviour
{
    public Transform numberSpheresParent;
    public int randomNumber;

    void Start()
    {
        randomNumber = Random.Range(1111, 9999);

        string numberString = randomNumber.ToString();

        for (int i = 0; i < numberString.Length; i++)
        {
            char digit = numberString[i];

            if (i < numberSpheresParent.childCount)
            {
                Transform sphere = numberSpheresParent.GetChild(i);

                var textComponent = sphere.GetComponentInChildren<TMPro.TextMeshPro>();
                if (textComponent != null)
                    textComponent.text = $"{digit}.";
            }
        }
    }
}
