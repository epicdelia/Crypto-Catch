﻿using UnityEngine;
using System.Collections;

public class CoinGenerator : MonoBehaviour {

	public ObjectPooler coinPool;

	public float distanceBetweenCoins;

	public void SpawnCoins (Vector3 startPosition )
	{
		GameObject coin1 = coinPool.GetPooledObject();
		coin1.transform.position = startPosition;
		coin1.SetActive(true);

		GameObject coin2 = coinPool.GetPooledObject();
		coin2.transform.position = new Vector3(startPosition.x - distanceBetweenCoins, startPosition.y, startPosition.z);
		coin2.SetActive(true);

		GameObject coin3 = coinPool.GetPooledObject();
		coin3.transform.position = new Vector3(startPosition.x + distanceBetweenCoins, startPosition.y, startPosition.z);
		coin3.SetActive(true);
	}
}

//public ObjectPooler[] coinPool;
//private int coinSelector;
//public float distanceBetweenCoins;

//public void SpawnCoins(Vector3 startPosition)
//{

    //coinSelector = Random.Range(0, coinPool.Length);
    //GameObject coin1 = coinPool[coinSelector].GetPooledObject();
    //coin1.transform.position = startPosition;
    //coin1.SetActive(true);