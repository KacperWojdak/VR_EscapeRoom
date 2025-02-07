using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject menuUI;
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetButtonDown("JoystickButton9"))
        {
            TogglePauseMenu();
        }
    }

    private void TogglePauseMenu()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
            menuUI.SetActive(true); 
        }
        else
        {
            Time.timeScale = 1f;
            menuUI.SetActive(false);
        }
    }

    public void ResumeGameFromMenu()
    {
        isPaused = false;
        Time.timeScale = 1f;
        menuUI.SetActive(false);
    }
}
