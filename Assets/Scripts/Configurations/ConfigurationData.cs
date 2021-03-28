using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";

    // configuration data
    Dictionary<ConfigurationDataValueName,float> values = 
        new Dictionary<ConfigurationDataValueName,float>();

    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return values[ConfigurationDataValueName.PaddleMoveUnitsPerSecond]; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return values[ConfigurationDataValueName.BallImpulseForce]; }    
    }

    /// <summary>
    /// Gets the death time of the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallDeathTime
    {
        get { return values[ConfigurationDataValueName.BallDeathTime]; }    
    }

    /// <summary>
    /// Gets minimum spawn time 
    /// </summary>
    /// <value>impulse force</value>
    public float MinSpawnTime
    {
        get { return values[ConfigurationDataValueName.MinSpawnTime]; }    
    }

    /// <summary>
    /// Gets maximum spawn time
    /// </summary>
    /// <value>impulse force</value>
    public float MaxSpawnTime
    {
        get { return values[ConfigurationDataValueName.MaxSpawnTime]; }    
    }

 
    /// <summary>
    /// Gets standard block points
    /// </summary>
    /// <value>impulse force</value>
    public int StandardBlockPoints
    {
        get { return (int)values[ConfigurationDataValueName.StandardBlockPoints]; }   
    } 

    /// <summary>
    /// Gets standard block points
    /// </summary>
    /// <value>impulse force</value>
    public int BonusBlockPoints
    {
        get { return (int)values[ConfigurationDataValueName.BonusBlockPoints]; }   
    } 
    /// <summary>
    /// Gets standard block points
    /// </summary>
    /// <value>impulse force</value>
    public int PickupBlockPoints
    {
        get { return (int)values[ConfigurationDataValueName.PickupBlockPoints]; }   
    }

        /// <summary>
    /// Gets standard block points
    /// </summary>
    /// <value>impulse force</value>
    public float ProbStandart
    {
        get { return values[ConfigurationDataValueName.ProbStandart]; }   
    }
        /// <summary>
    /// Gets standard block points
    /// </summary>
    /// <value>impulse force</value>
    public float ProbBonus
    {
        get { return values[ConfigurationDataValueName.ProbBonus]; }   
    }
        /// <summary>
    /// Gets standard block points
    /// </summary>
    /// <value>impulse force</value>
    public float ProbFreezer
    {
        get { return values[ConfigurationDataValueName.ProbFreezer]; }   
    }
        /// <summary>
    /// Gets standard block points
    /// </summary>
    /// <value>impulse force</value>
    public float ProbSpeedup
    {
        get { return values[ConfigurationDataValueName.ProbSpeedup]; }   
    }
    
    /// <summary>
    /// Gets standard block points
    /// </summary>
    /// <value>impulse force</value>
    public int BallsPerGame
    {
        get { return (int)values[ConfigurationDataValueName.ballsPerGame]; }   
    }

    /// <summary>
    /// Gets standard block points
    /// </summary>
    /// <value>impulse force</value>
    public float FreezerEffectDuration
    {
        get { return values[ConfigurationDataValueName.FreezerEffectDuration]; }   
    }
    /// <summary>
    /// Gets standard block points
    /// </summary>
    /// <value>impulse force</value>
    public float SpeedupEffectDuration
    {
        get { return values[ConfigurationDataValueName.SpeedupEffectDuration]; }   
    }
    /// <summary>
    /// Gets standard block points
    /// </summary>
    /// <value>impulse force</value>
    public float SpeedupFactor
    {
        get { return values[ConfigurationDataValueName.SpeedupFactor]; }   
    }
    

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        // read and save configuration data from file
        StreamReader input = null;
        try
        {
            // create stream reader object
            input = File.OpenText(Path.Combine(
                Application.streamingAssetsPath, ConfigurationDataFileName));

            // populate values
            string currentLine = input.ReadLine();
            while (currentLine != null)
            {
                string[] tokens = currentLine.Split(';');
                ConfigurationDataValueName valueName = 
                    (ConfigurationDataValueName)Enum.Parse(
                        typeof(ConfigurationDataValueName), tokens[0]);
                values.Add(valueName, float.Parse(tokens[1]));
                currentLine = input.ReadLine();
            }
        }
        catch (Exception e)
        {
            // set default values if something went wrong
            SetDefaultValues();
        }
        finally
        {
            // always close input file
            if (input != null)
            {
                input.Close();
            }
        }
    }

    #endregion
    /// <summary>
    /// Sets the configuration data fields to default values
    /// csv string
    /// </summary>
    void SetDefaultValues()
    {
        values.Clear();
        values.Add(ConfigurationDataValueName.PaddleMoveUnitsPerSecond, 20);
        values.Add(ConfigurationDataValueName.BallImpulseForce, 200);
        values.Add(ConfigurationDataValueName.BallDeathTime, 10);
        values.Add(ConfigurationDataValueName.MinSpawnTime, 5);
        values.Add(ConfigurationDataValueName.MaxSpawnTime, 10);
        values.Add(ConfigurationDataValueName.StandardBlockPoints, 5);
        values.Add(ConfigurationDataValueName.BonusBlockPoints, 20);
        values.Add(ConfigurationDataValueName.PickupBlockPoints, 5);
        values.Add(ConfigurationDataValueName.ProbStandart, 50);
        values.Add(ConfigurationDataValueName.ProbBonus, 20);
        values.Add(ConfigurationDataValueName.ProbFreezer, 10);
        values.Add(ConfigurationDataValueName.ProbSpeedup, 20);
        values.Add(ConfigurationDataValueName.ballsPerGame, 12);
        values.Add(ConfigurationDataValueName.FreezerEffectDuration, 2);
        values.Add(ConfigurationDataValueName.SpeedupEffectDuration, 3);
        values.Add(ConfigurationDataValueName.SpeedupFactor, 2);
    }

    
}
