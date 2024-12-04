using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Light flashlightLight;
    public bool isOn = false;

    private void Update()
    {
        if (flashlightLight != null)
        {
            flashlightLight.enabled = isOn;
        }
    }

    public void ToggleLight()
    {
        isOn = !isOn;
    }
}
