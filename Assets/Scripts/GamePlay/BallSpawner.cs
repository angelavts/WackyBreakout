using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ball spawner
/// </summary>
public class BallSpawner : MonoBehaviour
{
    #region Fields

    [SerializeField] GameObject prefabBall;
    //Spawn support
    Timer spawnTimer;
    float rand;
    Vector2 minLocation = new Vector2();
    Vector2 maxLocation = new Vector2();
    bool secondTry = false;
    //Collider width and height
    float ballColliderHalfWidth;
    float ballColliderHalfHeight;

    #endregion
    
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        //Events support
        EventManager.AddBallDieListener(SpawnBall);
        //Spawn Timer
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.AddTimerFinishedListener(HandleSpawnTimerFinished);
		spawnTimer.Duration = Random.Range(ConfigurationUtils.MinSpawnTime,
                                 ConfigurationUtils.MaxSpawnTime); 
        // spawn and destroy a ball to cache collider values
		GameObject tempBall = Instantiate(prefabBall) as GameObject;
		BoxCollider2D collider = tempBall.GetComponent<BoxCollider2D>();
		ballColliderHalfWidth = collider.size.x / 2;
		ballColliderHalfHeight = collider.size.y / 2;
        SetMinAndMax(tempBall.transform.position);
		Destroy(tempBall);
        // Spawn the first ball
        SpawnBall();
        spawnTimer.Run();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if (secondTry)
        {
            SpawnBall();
        }  
    }
    /// <summary>
	/// SpawnTimerFinished Handler
	/// </summary>
    void HandleSpawnTimerFinished()
    {
        SpawnBall();
        rand = Random.Range(ConfigurationUtils.MinSpawnTime,
                                 ConfigurationUtils.MaxSpawnTime);
        spawnTimer.Duration = rand;         
        spawnTimer.Run();  
    } 
    /// <summary>
	/// Spawn a new ball
	/// </summary>
    public void SpawnBall()
    {
        if (Physics2D.OverlapArea(minLocation, maxLocation) == null)
        {
            Instantiate(prefabBall);
            secondTry = false;
        }
        else
        {
            secondTry = true;
        }
        AudioManager.Play(AudioClipName.NewBall);   
    } 
    /// <summary>
	/// Sets min and max for a ball collision rectangle
	/// </summary>
	/// <param name="location">location of the ball</param>
	void SetMinAndMax(Vector2 location)
    {
		minLocation.x = location.x - ballColliderHalfWidth;
		minLocation.y = location.y - ballColliderHalfHeight;
		maxLocation.x = location.x + ballColliderHalfWidth;
		maxLocation.y = location.y + ballColliderHalfHeight;
	}
}
