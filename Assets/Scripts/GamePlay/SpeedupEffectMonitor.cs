using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Speed up effect monitor
/// </summary>
public class SpeedupEffectMonitor : MonoBehaviour
{
    #region Fields

    bool speedupEffectIsActivated;
    Timer ballSpeedupTimer;
    float speedFactor;
    float timeRemaining;

    #endregion

    #region Properties

    public float TimeRemaining
    {
		get{ return ballSpeedupTimer.TimeRemaining;}
	}
    public float SpeedFactor
    {
		get{ return speedFactor;}
	}

    #endregion

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        timeRemaining = 0;
        speedupEffectIsActivated = false;
        speedFactor = 1;
        ballSpeedupTimer = gameObject.AddComponent<Timer>();
        EventManager.AddSpeedupListener(HandleSpeedupEffect);  
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
         if (ballSpeedupTimer.Finished)
         {
            ballSpeedupTimer.Stop();
            speedFactor = 1;
        }  
    }

    /// <summary>
    /// Handles speed up effect event
    /// </summary>
    /// <param name="duration">Duration of the event</param>
    /// <param name="factor">Speed up factor</param>
    void HandleSpeedupEffect(float duration, float factor){
        speedupEffectIsActivated = true;
        if(ballSpeedupTimer.Running)
        {
            ballSpeedupTimer.SumTime = duration;
        }
        else
        {
            speedFactor = factor;
            ballSpeedupTimer.Duration = duration;
            ballSpeedupTimer.Run();  
        } 
    }
}
