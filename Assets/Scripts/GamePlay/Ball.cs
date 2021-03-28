using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A ball
/// </summary>
public class Ball : MonoBehaviour
{
    #region Fields
    [SerializeField] GameObject prefabBall;
    [SerializeField] Sprite[] ballSprites = new Sprite[2];
    Rigidbody2D rgb2;
    BoxCollider2D boxCollider;
    SpriteRenderer spriteRenderer;
    Timer ballTimer;
    Timer ballTimerStart;
    Timer ballSpeedupTimer;
    float magnitude;
    float speedFactor;
    float angle;
    float halfColliderHeight;
    Vector2 direction;
    BallLeftScreen ballLeftScreen;
    // event support
    BallDie ballDie;

    #endregion
    
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        // initializes events
        ballLeftScreen = new BallLeftScreen();
        ballDie = new BallDie();
        EventManager.AddBallDieInvoker(this);
        EventManager.AddBallLeftInvoker(this);
        EventManager.AddSpeedupListener(HandleSpeedupEffect);
        // Gets components
        rgb2 = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        // initializes vars
        angle = -20;
        speedFactor = 1;
        direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        magnitude = ConfigurationUtils.BallImpulseForce;
        boxCollider.enabled = false;
        halfColliderHeight = boxCollider.size.y/2; 
        // creates speed up timer
        ballSpeedupTimer = gameObject.AddComponent<Timer>();
        ballSpeedupTimer.AddTimerFinishedListener(HandleBallSpeedupTimerFinished);
        // creates ball timer
		ballTimer = gameObject.AddComponent<Timer>();
        ballTimer.AddTimerFinishedListener(HandleBallTimerFinished);
		ballTimer.Duration = ConfigurationUtils.BallDeathTime;
        ballTimer.Run();
        // creates ball start timer
        ballTimerStart = gameObject.AddComponent<Timer>();
        ballTimerStart.AddTimerFinishedListener(HandleBallTimerStartFinished);
		ballTimerStart.Duration = 1f;
        ballTimerStart.Run();            
        if(EffectUtils.SpeedFactor != 1){          
           spriteRenderer.sprite = ballSprites[1];
        }        
    }

    /// <summary>
    /// Handles ball timer start finished event
    /// </summary>
    void HandleBallTimerStartFinished()
    {
        if(EffectUtils.SpeedFactor != 1)
        {
            GetComponent<SpriteRenderer>().sprite = ballSprites[1];
            speedFactor = EffectUtils.SpeedFactor;            
            ballSpeedupTimer.Duration = EffectUtils.TimeRemaining;
            ballSpeedupTimer.Run(); 
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = ballSprites[0];
        }   
        GetComponent<BoxCollider2D>().enabled = true;     
        rgb2.AddForce(direction * magnitude * speedFactor, ForceMode2D.Impulse); 
        ballTimerStart.Stop();
    }

    /// <summary>
    /// Handles ball timer finished event
    /// </summary>
    void HandleBallTimerFinished()
    {
        ballDie.Invoke();
        ballTimer.Stop();
        Destroy(gameObject);       
    }

    /// <summary>
    /// Handles ball speed up timer finished event
    /// </summary>
    void HandleBallSpeedupTimerFinished()
    {
        print("se acabó speed");
        ballSpeedupTimer.Stop();
        speedFactor = 1;
        SetDirection(rgb2.velocity.normalized);
        GetComponent<SpriteRenderer>().sprite = ballSprites[0];
    }

    /// <summary>
    /// Set direcion of the ball
    /// </summary>
    /// <param name="direction">New direction</param>
    public void SetDirection(Vector2 direction)
    {
        rgb2.velocity = direction;
        rgb2.AddForce(direction * magnitude * speedFactor, ForceMode2D.Impulse);
    }

    /// <summary>
    /// Add listener to ball left event
    /// </summary>
    /// <param name="handler">Handler</param>
    public void AddBallLeftListener(UnityAction handler)
    {
        ballLeftScreen.AddListener(handler);
    }

    /// <summary>
    /// Add listener to ball die event
    /// </summary>
    /// <param name="handler"></param>
    public void AddBallDieListener(UnityAction handler)
    {
        ballDie.AddListener(handler);
    }

    /// <summary>
    /// On became invisible
    /// </summary>
    public void OnBecameInvisible()
    {
        if(transform.position.y + halfColliderHeight < ScreenUtils.ScreenBottom 
            && !ballTimer.Finished)
        {
            ballLeftScreen.Invoke();
            ballDie.Invoke();
		    Destroy(gameObject);
        }   
    }

    /// <summary>
    /// Handles speed up effect event
    /// </summary>
    /// <param name="duration">Duration of the effect</param>
    /// <param name="factor">Factor of speed</param>
    void HandleSpeedupEffect(float duration, float factor)
    {
        if(ballSpeedupTimer.Running)
        {
            ballSpeedupTimer.SumTime = duration;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = ballSprites[1];
            speedFactor = factor;
            rgb2.AddForce(rgb2.velocity.normalized * magnitude * speedFactor, ForceMode2D.Impulse);
            ballSpeedupTimer.Duration = duration;
            ballSpeedupTimer.Run();         
        }  
    }
}
