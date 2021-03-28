using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Effect utils
/// </summary>
public static class EffectUtils
{
    static SpeedupEffectMonitor speedupEffectMonitor;
    
    /// <summary>
    /// gets Speed Factor
    /// </summary>
    public static float SpeedFactor
    {
      get{return speedupEffectMonitor.SpeedFactor;}
    }
    /// <summary>
    /// gets Time Remaining of speed up effect
    /// </summary>
    public static float TimeRemaining
    {
      get{return speedupEffectMonitor.TimeRemaining;}
    }
    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        speedupEffectMonitor = Camera.main.GetComponent<SpeedupEffectMonitor>();
    }

}
