using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Manages connections between event listeners and event invokers
/// </summary>
public static class EventManager
{

	#region Fields

	// Freezer Event FreezerEffectActivated
	static List<PickupBlock> freezerInvokers = new List<PickupBlock>();
	static List<UnityAction<float>> freezerListeners = new List<UnityAction<float>>();

	// Speakup Event SpeedupEffectActivated
	static List<PickupBlock> speedupInvokers = new List<PickupBlock>();
	static List<UnityAction<float,float>> speedupListeners = new List<UnityAction<float,float>> ();

	// BreakEvent
	static List<Block> breakInvokers = new List<Block>();
	static List<UnityAction<int>> breakListeners = new List<UnityAction<int>>();

	// BallLeftScreen
	static List<Ball> ballLeftInvokers = new List<Ball>();
	static List<UnityAction> ballLeftListeners = new List<UnityAction>();

	// BallDie
	static List<Ball> ballDieInvokers = new List<Ball>();
	static List<UnityAction> ballDieListeners = new List<UnityAction>();

	// LastBallLeft
	static List<HUB> LastBallLeftInvokers = new List<HUB>();
	static List<UnityAction> LastBallLeftListeners = new List<UnityAction>();
	// BlockDestroyed
	static List<Block> BlockDestroyedInvokers = new List<Block>();
	static List<UnityAction> BlockDestroyedListeners = new List<UnityAction>();

	#endregion


	#region Public methods FreezerEffectActivated

	/// <summary>
	/// Adds the given script as an invoker
	/// </summary>
	/// <param name="invoker">the invoker</param>
	public static void AddFreezerInvoker(PickupBlock invoker)
    {
		// add invoker to list and add all listeners to invoker
		freezerInvokers.Add(invoker);
		foreach (UnityAction<float> listener in freezerListeners)
        {
			invoker.AddFreezerEffectListener(listener);
		}
	}
		
	/// <summary>
	/// Adds the given event handler as a listener
	/// </summary>
	/// <param name="listener">the event listener</param>
	public static void AddFreezerListener(UnityAction<float> listener)
    {		
		// add listener to list and to all invokers
		freezerListeners.Add(listener);
		foreach (PickupBlock pickupBlock in freezerInvokers)
        {
			pickupBlock.AddFreezerEffectListener(listener);
		}
	}

	#endregion

	#region Public methods SpeedupEffectActivated

	/// <summary>
	/// Adds the given script as an invoker
	/// </summary>
	/// <param name="invoker">the invoker</param>
	public static void AddSpeedupInvoker(PickupBlock invoker)
    {
		// add invoker to list and add all listeners to invoker
		speedupInvokers.Add(invoker);
		foreach (UnityAction<float,float> listener in speedupListeners)
        {
			invoker.AddSpeedupEffectListener(listener);
		}
	}
	/// <summary>
	/// Adds the given event handler as a listener
	/// </summary>
	/// <param name="listener">the event handler</param>
	public static void AddSpeedupListener(UnityAction<float,float> listener)
    {		
		// add listener to list and to all invokers
		speedupListeners.Add(listener);
		foreach (PickupBlock pickupBlock in speedupInvokers)
        {
			pickupBlock.AddSpeedupEffectListener(listener);
		}
	}

	#endregion

	#region Public methods BreakEvent

	/// <summary>
	/// Adds the given script as an invoker
	/// </summary>
	/// <param name="invoker">the invoker</param>
	public static void AddBreakInvoker(Block invoker)
    {
		// add invoker to list and add all listeners to invoker
		breakInvokers.Add(invoker);
		foreach (UnityAction<int> listener in breakListeners)
        {
			invoker.AddBreakEventListener(listener);
		}
	}
	/// <summary>
	/// Adds the given event handler as a listener
	/// </summary>
	/// <param name="listener">the event handler</param>
	public static void AddBreakListener(UnityAction<int> listener)
    {		
		// add listener to list and to all invokers
		breakListeners.Add(listener);
		foreach (Block block in breakInvokers)
        {
			block.AddBreakEventListener(listener);
		}
	}

	#endregion

	#region Public methods BallLeftScreen

	/// <summary>
	/// Adds the given script as an invoker
	/// </summary>
	/// <param name="invoker">the invoker</param>
	public static void AddBallLeftInvoker(Ball invoker)
    {
		// add invoker to list and add all listeners to invoker
		ballLeftInvokers.Add(invoker);
		foreach (UnityAction listener in ballLeftListeners)
        {
			invoker.AddBallLeftListener(listener);
		}
	}
	/// <summary>
	/// Adds the given event handler as a listener
	/// </summary>
	/// <param name="listener">the event handler</param>
	public static void AddBallLeftListener(UnityAction listener)
    {		
		// add listener to list and to all invokers
		ballLeftListeners.Add(listener);
		foreach (Ball ball in ballLeftInvokers)
        {
			ball.AddBallLeftListener(listener);
		}
	}

	#endregion

	#region Public methods BallDie

	/// <summary>
	/// Adds the given script as an invoker
	/// </summary>
	/// <param name="invoker">the invoker</param>
	public static void AddBallDieInvoker(Ball invoker)
    {
		// add invoker to list and add all listeners to invoker
		ballDieInvokers.Add(invoker);
		foreach (UnityAction listener in ballDieListeners)
        {
			invoker.AddBallDieListener(listener);
		}
	}
	/// <summary>
	/// Adds the given event handler as a listener
	/// </summary>
	/// <param name="listener">the event handler</param>
	public static void AddBallDieListener(UnityAction listener)
    {		
		// add listener to list and to all invokers
		ballDieListeners.Add(listener);
		foreach (Ball ball in ballDieInvokers)
        {
			ball.AddBallDieListener(listener);
		}
	}

	#endregion

	#region Public methods LastBallLeft

	/// <summary>
	/// Adds the given script as an invoker
	/// </summary>
	/// <param name="invoker">the invoker</param>
	public static void AddLastBallLeftInvoker(HUB invoker)
    {
		// add invoker to list and add all listeners to invoker
		LastBallLeftInvokers.Add(invoker);
		foreach (UnityAction listener in LastBallLeftListeners)
        {
			invoker.AddLastBallLeftListener(listener);
		}
	}
	/// <summary>
	/// Adds the given event handler as a listener
	/// </summary>
	/// <param name="listener">the event handler</param>
	public static void AddLastBallLeftListener(UnityAction listener)
    {		
		// add listener to list and to all invokers
		LastBallLeftListeners.Add(listener);
		foreach (HUB hub in LastBallLeftInvokers)
        {
			hub.AddLastBallLeftListener(listener);
		}
	}

	#endregion

	#region Public methods LastBallLeft

	/// <summary>
	/// Adds the given script as an invoker
	/// </summary>
	/// <param name="invoker">the invoker</param>
	public static void AddBlockDestroyedInvoker(Block invoker)
    {
		// add invoker to list and add all listeners to invoker
		BlockDestroyedInvokers.Add(invoker);
		foreach (UnityAction listener in BlockDestroyedListeners)
        {
			invoker.AddBlockDestroyedListener(listener);
		}
	}
	/// <summary>
	/// Adds the given event handler as a listener
	/// </summary>
	/// <param name="listener">the event handler</param>
	public static void AddBlockDestroyedListener(UnityAction listener)
    {		
		// add listener to list and to all invokers
		BlockDestroyedListeners.Add(listener);
		foreach (Block block in BlockDestroyedInvokers)
        {
			block.AddBlockDestroyedListener(listener);
		}
	}

	#endregion

}