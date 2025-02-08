using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class MenuUI : MonoBehaviour
{
    public GameObject menuUI;
    private bool isMenuActive = false;
    private bool isButtonPressed = false;

    void Update()
    {
        if (IsMenuButtonPressed())
        {
            if (!isButtonPressed)
            {
                TogglePauseMenu();
                isButtonPressed = true;
            }
        }
        else
        {
            isButtonPressed = false;
        }
    }

    public void TogglePauseMenu()
    {
        if (!isMenuActive)
        {
            isMenuActive = true;
            Time.timeScale = 0f;
            menuUI.SetActive(true);
        }
        else
        {
            isMenuActive = false;
            Time.timeScale = 1f;
            menuUI.SetActive(false);
        }
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");
    }

    public void ExitToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private bool IsMenuButtonPressed()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);

        if (device.TryGetFeatureValue(CommonUsages.menuButton, out bool isPressed) && isPressed)
        {
            return true;
        }
        return false;
    }
}
