using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A paddle
/// </summary>
public class Paddle : MonoBehaviour
{
    const float tol = 0.05f;
    const float BounceAngleHalfRange = 60*Mathf.Deg2Rad;

    #region Fields
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider;
    float horizontalInput;
    float velocity;
    float halfColliderWidth;
    float halfColliderHeight;
    Timer freezeTimer;
    Vector2 position;
    [SerializeField] Sprite[] paddleSprites = new Sprite[2];
    #endregion
    
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        velocity = ConfigurationUtils.PaddleMoveUnitsPerSecond;
        // Gets components
        rb2d = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        // Gets collider size
        halfColliderWidth = GetComponent<BoxCollider2D>().size.x/2; 
        halfColliderHeight = GetComponent<BoxCollider2D>().size.y/2; 
        // Events
        EventManager.AddFreezerListener(HandleFreezerEffect);
        // Creates a freeze timer
        freezeTimer = gameObject.AddComponent<Timer>();
        freezeTimer.AddTimerFinishedListener(HandleFreezeTimerFinished);
    }

    /// <summary>
    /// Handles freeze timer finished event
    /// </summary>
    void HandleFreezeTimerFinished()
    {
        freezeTimer.Stop();
        spriteRenderer.sprite = paddleSprites[0];
    } 

    /// <summary>
    /// fixed update
    /// </summary>
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0 && !freezeTimer.Running)
        {
            position = rb2d.position;
            position.x = CalculateClampedX(position.x + velocity 
                                    * horizontalInput * Time.fixedDeltaTime);
            rb2d.MovePosition(position);
        }
    }
    /// <summary>
    /// Clamp paddle in the screen
    /// </summary>
    /// <param name="oldX">Old x position</param>
    /// <returns></returns>
    float CalculateClampedX(float oldX){
        float validX = oldX;
        if (oldX - halfColliderWidth < ScreenUtils.ScreenLeft)
        {
            validX = ScreenUtils.ScreenLeft + halfColliderWidth;
        }
        else if (oldX + halfColliderWidth > ScreenUtils.ScreenRight)
        {
            validX = ScreenUtils.ScreenRight - halfColliderWidth;
        }
        return validX;
    }

    /// <summary>
    /// Detects collision with a ball to aim the ball
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball") && TopCollision(coll))
        {
            AudioManager.Play(AudioClipName.PaddleTouch);
            // calculate new ball direction
            float ballOffsetFromPaddleCenter = transform.position.x -
                coll.transform.position.x;
            float normalizedBallOffset = ballOffsetFromPaddleCenter /
                halfColliderWidth;
            float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
            float angle = Mathf.PI / 2 + angleOffset;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));     
            // tell ball to set direction to new direction
            Ball ballScript = coll.gameObject.GetComponent<Ball>();
            ballScript.SetDirection(direction);
        }
    }

    /// <summary>
    /// Detects top collision
    /// </summary>
    /// <param name="coll"></param>
    /// <returns>True if collision is on the top. False is not.</returns>
    bool TopCollision(Collision2D coll){
        return Mathf.Abs(coll.contacts[0].point.y - coll.contacts[1].point.y) < tol;
    }

    /// <summary>
    /// Handles freeze effect event
    /// </summary>
    /// <param name="duration">Duration of the effect</param>
    void HandleFreezerEffect(float duration){
        
        if(freezeTimer.Running)
        {
            freezeTimer.SumTime = duration;
        }
        else
        {
            spriteRenderer.sprite = paddleSprites[1];
            freezeTimer.Duration = duration;
            freezeTimer.Run();
        }   
    }
}

