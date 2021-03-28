using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A block
/// </summary>
public class Block : MonoBehaviour
{

    #region Fields

    protected int pointValue = 5;
    BreakEvent breakEvent;
    BlockDestroyed blockDestroyed;

    #endregion

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    protected virtual void Start()
    {
        breakEvent = new BreakEvent();
        blockDestroyed = new BlockDestroyed();
        EventManager.AddBreakInvoker(this);
        EventManager.AddBlockDestroyedInvoker(this);
    }

    /// <summary>
    /// Add lister to break event
    /// </summary>
    /// <param name="handler">Handler</param>
    public void AddBreakEventListener(UnityAction<int> handler)
    {
        breakEvent.AddListener(handler);
    }

    /// <summary>
    /// Add listener to block destroyed event
    /// </summary>
    /// <param name="handler">Handler</param>
    public void AddBlockDestroyedListener(UnityAction handler)
    {
        blockDestroyed.AddListener(handler);
    }

    /// <summary>
    /// Process collisions with other objects
    /// </summary>
    /// <param name="coll">Information about other ollider</param>
    protected virtual void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball"))
        {
            breakEvent.Invoke(pointValue);
            AudioManager.Play(AudioClipName.BlockBreaking);
            blockDestroyed.Invoke();
            Destroy(gameObject);
        }
    }

}
