/*=============================================================================
 |  Class: Score Manager
 |  Author:  Delia Lazarescu
 |  Description: Used to manage the score and keep track of points
 *===========================================================================*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    //define variables 
	public Text scoreText;
	public Text hiScoreText;

    public Text BitcoinText;
    public Text EthereumText;
    public Text DogecoinText;

	public float scoreCount;
	public float hiScoreCount;

    public float maxPrice;
    public float minPrice;

    public float BitcoinPrice;
    public float DogecoinPrice;
    public float EthereumPrice;

	public float pointsPerSecond;

	public bool scoreIncreasing;

	public bool shouldDouble;

	// Use this for initialization
	void Start () {

        //set coin prices to something between a reasonable range for each play
        BitcoinPrice = Random.Range(minPrice, maxPrice);
        DogecoinPrice = Random.Range(minPrice, maxPrice);
        EthereumPrice = Random.Range(minPrice, maxPrice);

        //Display highscore 
		if(PlayerPrefs.HasKey("HighScore"))
		{
			hiScoreCount = PlayerPrefs.GetFloat("HighScore");
		}
	}
	
	// Update is called once per frame
	void Update () {


        //Increase score as player progresses through game to reward player for not dying
		if(scoreIncreasing)
		{
			scoreCount += pointsPerSecond * Time.deltaTime;
		}

        //increase High score if player gets high score
		if(scoreCount > hiScoreCount)
		{
			hiScoreCount = scoreCount;
			PlayerPrefs.SetFloat("HighScore", hiScoreCount);
		}

        //actually display scores in text, rounding so it looks pretty 
		scoreText.text = "Score: " + Mathf.Round (scoreCount);
		hiScoreText.text = "High Score: " + Mathf.Round (hiScoreCount);

        BitcoinText.text = "Bitcoin: " + Mathf.Round(BitcoinPrice);
        EthereumText.text = "Ethereum: " + Mathf.Round(EthereumPrice);
        DogecoinText.text = "Dogecoin: " + Mathf.Round(DogecoinPrice);

	}

    //add different points depending on what type of coin is colleted 
	public void AddScore(int pointsToAdd)
	{
		if(shouldDouble)
		{
			pointsToAdd = pointsToAdd * 2;
		}
		scoreCount += pointsToAdd;
	}
}
