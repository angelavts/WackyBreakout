using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    // prefabs to instantiate
    [SerializeField] GameObject paddlePrefab;
    [SerializeField] GameObject blockPrefab;
    [SerializeField] GameObject bonusBlockPrefab;
    [SerializeField] GameObject pickupBlockPrefab;
    float blockColliderWidth;
    float blockColliderHeight;
    float startPosRow;
    float spaceBetweenBlocks;
    float spaceBetweenRows;
     
    // Start is called before the first frame update
    void Start()
    {
        ScreenUtils.Initialize(); 
        
        // spawn and destroy a block to cache collider values
		GameObject tempBlock = Instantiate(blockPrefab) as GameObject;
		BoxCollider2D collider = tempBlock.GetComponent<BoxCollider2D>();
		blockColliderWidth = collider.size.x;
		blockColliderHeight = collider.size.y;
		Destroy(tempBlock);   
        spaceBetweenBlocks = blockColliderWidth/4;
        spaceBetweenRows = blockColliderHeight/2; 
        // build level
        buildBlockRows(3);
        // instantiate paddle
        Instantiate(paddlePrefab);
    }


    /// <summary>
    /// Build rows of blocks
    /// </summary>
    /// <param name="blockRows">Number of rows of blocks</param>
    void buildBlockRows(float blockRows)
    {
        float x;
        float end = ScreenUtils.ScreenRight - blockColliderWidth;
        float y = (ScreenUtils.ScreenTop + blockColliderHeight/2) - ScreenUtils.ScreenTop/5; 
        for(int j=0; j < blockRows; j++)
        {
            x = (spaceBetweenBlocks + blockColliderWidth)/2;
            while(x < end)
            {          
                addBlockrandomly(new Vector3(x,y,0));   
                addBlockrandomly(new Vector3(-x,y,0)); 
                x += spaceBetweenBlocks + blockColliderWidth;          
            }
            y -= spaceBetweenRows + blockColliderHeight*2;
        }        
    }

    /// <summary>
    /// Instantiate a pick up block
    /// </summary>
    /// <param name="pickupEffect">Pick up effect</param>
    /// <param name="position">Position to instantiate</param>
    void addPickupBlock(PickupEffect pickupEffect, Vector3 position)
    {
        GameObject newBlock = Instantiate(pickupBlockPrefab, position, Quaternion.identity) as GameObject;
        newBlock.GetComponent<PickupBlock>().PickupEffect = pickupEffect;
    }

    /// <summary>
    /// Instantiate a block randomly
    /// </summary>
    /// <param name="position">Position to instantiate</param>
    void addBlockrandomly(Vector3 position)
    {
        float selected = Random.Range(0, 100);
        if(selected <= ConfigurationUtils.ProbStandart)
        {
            Instantiate(blockPrefab, position, Quaternion.identity);
        }
        else
        {
            selected -= ConfigurationUtils.ProbStandart;
            if(selected <= ConfigurationUtils.ProbBonus)
            {
                Instantiate(bonusBlockPrefab, position, Quaternion.identity);
            }else
            {
                selected -= ConfigurationUtils.ProbBonus;
                if(selected <= ConfigurationUtils.ProbFreezer)
                {
                    addPickupBlock(PickupEffect.Freezer, position);
                }
                else
                {
                    addPickupBlock(PickupEffect.Speedup, position);
                }
            }
        }
    }
}
