using UnityEngine;
using UnityEngine.XR;
using System.IO;

public class Screenshot : MonoBehaviour
{
    public string baseFileName = "Screenshot"; 
    public string folderPath = "Screenshots";
    private bool isButtonPressed = false;

    void Update()
    {
        if (IsButtonPressed(XRNode.LeftHand, CommonUsages.primaryButton))
        {
            if (!isButtonPressed)
            {
                CaptureScreenshot();
                isButtonPressed = true;
            }
        }
        else
        {
            isButtonPressed = false;
        }
    }

    void CaptureScreenshot()
    {
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        int screenshotNumber = GetNextScreenshotNumber();
        string fileName = $"{baseFileName}_{screenshotNumber}.png";
        string path = Path.Combine(folderPath, fileName);

        ScreenCapture.CaptureScreenshot(path);
    }

    int GetNextScreenshotNumber()
    {
        int screenshotNumber = 1;

        string[] files = Directory.GetFiles(folderPath, $"{baseFileName}_*.png");

        foreach (string file in files)
        {
            string fileName = Path.GetFileNameWithoutExtension(file);
            string numberPart = fileName.Substring(baseFileName.Length + 1);
            if (int.TryParse(numberPart, out int number))
            {
                screenshotNumber = Mathf.Max(screenshotNumber, number + 1);
            }
        }

        return screenshotNumber;
    }

    bool IsButtonPressed(XRNode hand, InputFeatureUsage<bool> button)
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(hand);

        if (device.TryGetFeatureValue(button, out bool isPressed) && isPressed)
        {
            return true;
        }
        return false;
    }
}
