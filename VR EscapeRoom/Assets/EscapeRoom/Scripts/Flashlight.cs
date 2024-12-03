using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public new Light light;
    public bool isOn = false;

    private void Update()
    {
        GetComponent<Light>().enabled = isOn;
    }

    public void ToggleLight()
    {
        isOn = !isOn;
    }
}
