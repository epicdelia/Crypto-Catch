/*=============================================================================
 |  Class: Camera Controller 
 |  Author:  Delia Lazarescu
 |  Description: Used to control the camera so it follows the player, but also
 |  stays within the constraints of the game screen (i.e. does not follow player
 |  when player falls off a platform)
 *===========================================================================*/

using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    
	public PlayerController Satoshi;
	private Vector3 lastPlayerPosition;
	private float distanceToMove;

	// Use this for initialization
	void Start () {
		Satoshi = FindObjectOfType<PlayerController>();
		lastPlayerPosition = Satoshi.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        //find how much the player moved in comparison to the camera
		distanceToMove = Satoshi.transform.position.x - lastPlayerPosition.x;
        //move the camera this amount 
		transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);
		lastPlayerPosition = Satoshi.transform.position;
	}
}
