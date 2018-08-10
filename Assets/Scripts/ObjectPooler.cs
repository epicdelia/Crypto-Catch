/*=============================================================================
 |  Class: Object Pooler 
 |  Author:  Delia Lazarescu
 |  Description: This class is used to efficiently store and recycle game objects so that memory is used efficiently 
 *===========================================================================*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour {

	public GameObject pooledObject;

	public int pooledAmount;

    //storing game objects in a List
	List<GameObject> pooledObjects;

	// Use this for initialization
	void Start () {

        //create new list of objects 
		pooledObjects = new List<GameObject>();

        //instantiate each object and add to the List 
		for(int i = 0; i < pooledAmount; i++)
		{
			GameObject obj = (GameObject)Instantiate(pooledObject);
			obj.SetActive (false);
			pooledObjects.Add (obj);
		}

	
	}
	
    //Getter function for getting game objects 
	public GameObject GetPooledObject()
	{
		for(int i = 0; i < pooledObjects.Count; i++)
		{
			if(!pooledObjects[i].activeInHierarchy)
			{
				return pooledObjects[i];
			}
		}

		GameObject obj = (GameObject)Instantiate(pooledObject);
		obj.SetActive (false);
		pooledObjects.Add (obj);
		return obj;
	
	}
}
