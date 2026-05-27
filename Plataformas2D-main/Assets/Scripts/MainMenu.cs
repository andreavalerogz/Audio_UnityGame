using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class MainMenu : MonoBehaviour
{
    bool menuOpen = false;
    public UnityEvent onEscapePressed;

    public InputSystem_Actions actions;

    private void Awake()
    {
        actions = new InputSystem_Actions();
        actions.Enable();
    }

    void Update()
    {
        if(menuOpen && actions.UI.Settings.WasPressedThisFrame())
        {
            onEscapePressed.Invoke();
        }
    }

    // BUTTON ONCLICK
    public void PlayGame()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void toggleMenuOpen()
    {
        menuOpen = !menuOpen;
    }

}
