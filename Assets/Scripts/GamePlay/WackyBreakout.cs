using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Game manager
/// </summary>
public class WackyBreakout : MonoBehaviour
{
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        AudioManager.Play(AudioClipName.NewGame);
        EventManager.AddLastBallLeftListener(handleLastBallLeft);
        EventManager.AddBlockDestroyedListener(handleLastBlockBreaking);
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1)
        {
            MenuManager.GoToMenu(MenuName.Pause);
        }
    }

    /// <summary>
    /// Handles last ball left event
    /// </summary>
    void handleLastBallLeft()
    {
        MenuManager.GoToMenu(MenuName.GameOver);
    }

    /// <summary>
    /// Handles last block breaking event
    /// </summary>
    void handleLastBlockBreaking()
    {
        if(GameObject.FindGameObjectsWithTag("Block").Length - 1 == 0)
        {
            MenuManager.GoToMenu(MenuName.GameOver);
        }
    }
}

