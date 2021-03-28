using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

/// <summary>
/// HUB
/// </summary>
public class HUB : MonoBehaviour
{

    #region Fields
    // UI elements
    [SerializeField] Text scoreText;
    [SerializeField] Text ballLeftText;

    // Counters
	int ballLeft;
    int score; 

    // Events
    LastBallLeft lastBallLeft;

    #endregion

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        lastBallLeft = new LastBallLeft();
        //Events support
        EventManager.AddBreakListener(AddPoint);
        EventManager.AddBallLeftListener(BallLeftScreen);
        EventManager.AddLastBallLeftInvoker(this);
        //Score text
        score = 0;
        scoreText = GameObject.FindWithTag("Score").GetComponent<Text>();
        //Ball Left text
        ballLeftText = GameObject.FindWithTag("BallLeft").GetComponent<Text>();
        ballLeft = ConfigurationUtils.BallsPerGame;
        ballLeftText.text = "Balls: " + ballLeft;
    }
    /// <summary>
	/// Handles the points added event by updating the displayed score
	/// </summary>
	/// <param name="points">points to add</param>
	public void AddPoint(int points)
    {
		score += points;
		scoreText.text = "Score: " + score;
	}
    /// <summary>
	/// Handles the amount of balls
	/// </summary>
	public void BallLeftScreen()
    {
        AudioManager.Play(AudioClipName.PickupBlockBreaking);
		ballLeft--;
		ballLeftText.text = "Balls: " + ballLeft;
        if (ballLeft == 0)
        {
            lastBallLeft.Invoke();
        }
	}
    /// <summary>
	/// Add lastBallLeft Listener
	/// </summary>
    /// <param name="handler">the event handler</param>
    public void AddLastBallLeftListener(UnityAction handler)
    {
        lastBallLeft.AddListener(handler);
    }
}

