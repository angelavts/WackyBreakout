using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Bonus block
/// </summary>
public class BonusBlock : Block
{
    
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    protected override void Start()
    {
        pointValue = ConfigurationUtils.BonusBlockPoints;
        base.Start();
    }

}
