/*=============================================================================
 |  Class: Platform Generator 
 |  Author:  Delia Lazarescu
 |  Description: Generates infinite platforms for the player to jump onto
 |  Platform Generator also calls the Coin Generator to generate coins when a new platform is made
 *===========================================================================*/

using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {
    
    //set variables 
	public GameObject thePlatform;
	public Transform generationPoint;
	public float distanceBetween;

    //using a float for platformWidth because measurement is not an exact int 
	private float platformWidth;

    //distance between the generated platforms 
	public float distanceBetweenMin;
	public float distanceBetweenMax;

	private int platformSelector;
	private float[] platformWidths;
	
    //using the object pooler class to organize and recycle the game objects 
	public ObjectPooler[] theObjectPools;

	private float minHeight;
	public Transform maxHeightPoint;
	private float maxHeight;
	public float maxHeightChange;
	private float heightChange;

	private CoinGenerator theCoinGenerator;
	public float randomCoinThreshold;

	public float randomSpikeThreshold;
	public ObjectPooler spikePool;


	// Use this for initialization
	void Start () {
        
		// or could also use platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
		platformWidths = new float[theObjectPools.Length];

        //get the width of all the platforms using the get component function 
		for (int i = 0; i < theObjectPools.Length; i++)
		{
			platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
		}

		minHeight = transform.position.y;
		maxHeight = maxHeightPoint.position.y;

        //also need the coin generator so find the object it's attached to
		theCoinGenerator = FindObjectOfType<CoinGenerator>();
	}
	
	// Update is called once per frame
	void Update () {

        //Only generate more when past the generation point 
		if(transform.position.x < generationPoint.position.x)
		{
            //calculate distance between platforms randomly, but within the desired range 
			distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);

            //select random platform to draw on screen
			platformSelector = Random.Range(0, theObjectPools.Length);

            //determine the difference in height where the platform should be (y coordinate)
			heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

            //don't go past a certain height or the player won't be able to jump there
			if(heightChange > maxHeight)
			{
				heightChange = maxHeight;
			} else if (heightChange < minHeight)
			{
				heightChange = minHeight;
			}

            //calculate the new position by choosing the random platofrm and adding half of its width to the current position and accounting for the distance between platforms 
            //y position is the height determined above 
            //keep z position the same
			transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, heightChange, transform.position.z);


			//Instantiate (/* thePlatform */ thePlatforms[platformSelector], transform.position, transform.rotation);
           	GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();

            //activate platform 
			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive (true);

            //only create coins if tbe random number generated is less than the threshold, to keep things interesting and not always have coins 
            if(Random.Range(0f, 100f) < randomCoinThreshold)
			{
				theCoinGenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z ) );
			}

            //for 
			if(Random.Range(0f, 100f) < randomSpikeThreshold)
			{
				GameObject newSpike = spikePool.GetPooledObject();

				float spikeXPosition = Random.Range(-platformWidths[platformSelector] / 2f + 1f, platformWidths[platformSelector] / 2f - 1f);

				Vector3 spikePosition = new Vector3(spikeXPosition, 0.5f, 0f);

				newSpike.transform.position = transform.position + spikePosition;
				newSpike.transform.rotation = transform.rotation;
				newSpike.SetActive(true);
			}

			transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);

		}
	
	}
}
