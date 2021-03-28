using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Listens for the OnClick events for the help menu buttons
/// </summary>
public class HelpMenu : MonoBehaviour
{
    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {   
        // pause the game when added to the scene
        Time.timeScale = 0;
    }

    /// <summary>
    /// Handles the on click event from the Resume button
    /// </summary>
    public void HandleBackButtonOnClickEvent()
    {
        // unpause game and destroy menu
        AudioManager.Play(AudioClipName.ButtonClick);
        Time.timeScale = 1;
        MenuManager.GoToMenu(MenuName.Main);
    }
}
