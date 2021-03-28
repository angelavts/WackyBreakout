using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Standard Block
/// </summary>
public class StandardBlock : Block
{

    [SerializeField]
    Sprite[] blockSprites = new Sprite[3];

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    protected override void Start()
    {
        pointValue = ConfigurationUtils.StandardBlockPoints;
		GetComponent<SpriteRenderer>().sprite = blockSprites[Random.Range(0, 3)];
        base.Start();

    }

}
