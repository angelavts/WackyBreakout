using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    #region Properties
    // configuration data
    static ConfigurationData configurationData;

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return configurationData.PaddleMoveUnitsPerSecond; }
    }
    public static float BallImpulseForce
    {
        get { return configurationData.BallImpulseForce; }
    }
    public static float BallDeathTime
    {
        get { return configurationData.BallDeathTime; }
    }
    public static float MinSpawnTime
    {
        get { return configurationData.MaxSpawnTime; }
    }
    public static float MaxSpawnTime
    {
        get { return configurationData.MinSpawnTime; }
    }
    public static int StandardBlockPoints
    {
        get { return configurationData.StandardBlockPoints; }
    }
    public static int BonusBlockPoints
    {
        get { return configurationData.BonusBlockPoints; }
    }
    public static int PickupBlockPoints
    {
        get { return configurationData.PickupBlockPoints; }
    }
    public static float ProbStandart
    {
        get { return configurationData.ProbStandart; }
    }
    public static float ProbBonus
    {
        get { return configurationData.ProbBonus; }
    }
    public static float ProbFreezer
    {
        get { return configurationData.ProbFreezer; }
    }
    public static float ProbSpeedup
    {
        get { return configurationData.ProbSpeedup; }
    }
    public static int BallsPerGame
    {
        get { return configurationData.BallsPerGame; }
    }
    public static float FreezerEffectDuration
    {
        get { return configurationData.FreezerEffectDuration; }
    }
    public static float SpeedupEffectDuration
    {
        get { return configurationData.SpeedupEffectDuration; }
    }
    public static float SpeedupFactor
    {
        get { return configurationData.SpeedupFactor; }
    }



    #endregion
    
    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        configurationData = new ConfigurationData();
    }
}
