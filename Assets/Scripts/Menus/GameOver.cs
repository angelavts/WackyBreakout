using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    #region Fields
    string score;
    Text scoreText;
    #endregion

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {   
        AudioManager.Play(AudioClipName.NewGame);
        Time.timeScale = 0;
        scoreText = GameObject.FindWithTag("DisplayScore").GetComponent<Text>();
        scoreText.text = GameObject.FindWithTag("Score").GetComponent<Text>().text;
    }

    /// <summary>
    /// Handles the on click event from the Quit button
    /// </summary>
    public void HandleQuitButtonOnClickEvent()
    {
        // unpause game, destroy menu, and go to main menu
        AudioManager.Play(AudioClipName.ButtonClick);
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
    }
}
