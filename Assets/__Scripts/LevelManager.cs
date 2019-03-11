using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    //Variables , including header for unity editor just to make it easier to assign.

	public Transform player;

	[Header("Platforms")]
	public GameObject blockPrefab;
	public float currentBlockY ;
	public float distanceBetweenBlocks = 1f;
	public float distanceBeforeSpawnBlock = 5f;
	public int initBlocksLine = 10;
	public List<GameObject> blocksPool;

	private void Awake()
	{
        //calls the method
		InitBlocks();	
	}

	private void Update()
	{ 
        //if the distance is as set above (distancebeforespawnblock) then spawn a platform
		if(currentBlockY - player.position.y < distanceBeforeSpawnBlock)
		{
			SpawnBlocks();
		}
	}

	private void InitBlocks()
	{
        //initilises the platforms  , sets the distance randomises, instantiates and the number of them.
		for (int i = 0; i < initBlocksLine; i++)
		{   //5,5
			Vector2 pos = new Vector2(Random.Range(-2, 2), currentBlockY);
			GameObject go = Instantiate(blockPrefab, pos, Quaternion.identity, transform);
			blocksPool.Add(go);
			currentBlockY += distanceBetweenBlocks;
		}
	}
    //spawns the platforms sets the position  using the array assigned in initblocks
    //and sets the distance between them to the current block y
	private void SpawnBlocks()
	{
		blocksPool[0].transform.position = new Vector2(Random.Range(-5, 5), currentBlockY);
		currentBlockY += distanceBetweenBlocks;

		GameObject temp = blocksPool[0];
		blocksPool.RemoveAt(0);
		blocksPool.Add(temp);
	}

}
