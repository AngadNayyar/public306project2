using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountAchievement : MonoBehaviour
{

	public Text chickenText;

	// display the players total score and chickens collected for the game
	public void Start()
	{
		//get the current user
		GameObject gameO = GameObject.Find("GameController");
		GameController gameC = (GameController)gameO.GetComponent(typeof(GameController));
		User currentPlayer = gameC.getCurrentPlayer();

		//get the player's chicken collectables and set the text to it
		int chickens = currentPlayer.GetCollectables();
		chickenText.text = chickens.ToString();

	}

}

