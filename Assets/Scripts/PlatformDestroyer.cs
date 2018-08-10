/*=============================================================================
 |  Class: Platform Destroyer
 |  Author:  Delia Lazarescu
 |  Description: Used to destroy the platforms once player has passed them to save memory and space 
 *===========================================================================*/
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour {

	public GameObject platformDestructionPoint;

	// Use this for initialization
	void Start () {
        //could have simply used camera position, but for good practice we are using a platform destruction point game object
		platformDestructionPoint = GameObject.Find ("PlatformDestructionPoint");
	}
	
	// Update is called once per frame
	void Update () {

        //if the current platform position is behing the destruction point, we don't need it anymore 
		if(transform.position.x < platformDestructionPoint.transform.position.x)
		{

            //Destroy gameObject would have also been valid, but we are setting it to inactive so we can use it again #efficiency 
			gameObject.SetActive(false);

		}
	}
}
