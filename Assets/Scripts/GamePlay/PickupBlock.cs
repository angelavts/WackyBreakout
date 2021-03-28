using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Pick up block
/// </summary>
public class PickupBlock : Block
{
    #region Fields
    [SerializeField] Sprite[] blockSprites = new Sprite[2];
    PickupEffect pickupEffect;
    float effectDuration;
    float speedupFactor;
    // Events
    FreezerEffectActivated freezerEffectActivated;
    SpeedupEffectActivated speedupEffectActivated;

    #endregion


    /// <summary>
	/// Property for the type of pickup
	/// </summary>
	/// <param name="pickupEffect">Pickup effect.</param>
    public PickupEffect PickupEffect
    {
        get { return pickupEffect; }
        set 
        { 
            pickupEffect = value;
            if ( pickupEffect == PickupEffect.Freezer )
            {
                effectDuration = ConfigurationUtils.FreezerEffectDuration; 
                freezerEffectActivated = new FreezerEffectActivated(); 
                EventManager.AddFreezerInvoker(this);
            }
            else
            {
                effectDuration = ConfigurationUtils.SpeedupEffectDuration; 
                speedupEffectActivated = new SpeedupEffectActivated();
                EventManager.AddSpeedupInvoker(this);
                speedupFactor = ConfigurationUtils.SpeedupFactor;
            }
            
        }
    }	

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    protected override void Start()
    {
        pointValue = ConfigurationUtils.PickupBlockPoints; 
        GetComponent<SpriteRenderer>().sprite = blockSprites[(int)pickupEffect];
        base.Start();   
    }

    /// <summary>
    /// Add listener for freeze effect event
    /// </summary>
    /// <param name="handler">Handlet of the event</param>
    public void AddFreezerEffectListener(UnityAction<float> handler)
    {
        freezerEffectActivated.AddListener(handler);
    }

    /// <summary>
    /// Add listener for speed up effect event
    /// </summary>
    /// <param name="handler">Handlet of the event</param>
    public void AddSpeedupEffectListener(UnityAction<float,float> handler)
    {
        speedupEffectActivated.AddListener(handler);
    }

    /// <summary>
    /// Detects collision with a ball 
    /// </summary>
    /// <param name="coll">collision info</param>
    protected override void OnCollisionEnter2D(Collision2D coll)
    {
        if(pickupEffect == PickupEffect.Freezer)
        {
            freezerEffectActivated.Invoke(effectDuration);
        }
        else
        {
            speedupEffectActivated.Invoke(effectDuration, speedupFactor);
        }
        base.OnCollisionEnter2D(coll);
    }
}
