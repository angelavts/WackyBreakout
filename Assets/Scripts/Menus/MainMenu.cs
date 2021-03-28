using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Listens for the OnClick events for the main menu buttons
/// </summary>
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Handles the on click event from the play button
    /// </summary>
    public void HandlePlayButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.ButtonClick);
        SceneManager.LoadScene("GamePlay");
    }

    /// <summary>
    /// Handles the on click event from the quit button
    /// </summary>
    public void HandleQuitButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.ButtonClick);
        Application.Quit();
    }
    /// <summary>
    /// Handles the on click event from the help button
    /// </summary>
    public void HandleHelpButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.ButtonClick);
        MenuManager.GoToMenu(MenuName.Help);
    }
}
