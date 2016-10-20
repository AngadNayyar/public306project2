using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

/*
 * Managing the Achievements in the achievement panel
*/
public class AchievementManager : MonoBehaviour {

	//Reference to the prefab of our achievement
	public GameObject achievementPrefab;

	//for the sprite image for the achievement set in unity
	public Sprite[] sprites; 

	//for the achievement panel
	private btnAch activeButton;
	public ScrollRect scrollRect;

	//the pop up 
	//public GameObject visualAchievement;

	//unlocked sprite the gold shield
	public Sprite unlockedSprite;

	//the current player and the number of collected chickens. 
	public int collectedChicks; //no. chickens er person
	public User currentPlayer; //currentPlayer
	public string currentPlayerName;

	private static AchievementManager instance;
	public static AchievementManager Instance {
		get {
			if (instance == null) {
				instance = GameObject.FindObjectOfType<AchievementManager> ();
			}
			return instance;
		}
	} //singleton way of accessing object without having instance of the object

	public static Achievement achievement1;
	public static Achievement achievement2;
	public static Achievement achievement3;
	public static List<Achievement> achList = new List<Achievement>(); 

	// Use this for initialization
	void Start () {
		
		//setting what player is alive right now
		GameObject gameO = GameObject.Find ("GameController");
		GameController gameC = (GameController)gameO.GetComponent (typeof(GameController));
		User currentPlayer = gameC.getCurrentPlayer ();   // the actual player
		currentPlayerName = currentPlayer.GetUsername ();
		collectedChicks = currentPlayer.GetCollectables ();
		
		//setting achievement tab to be active
		activeButton = GameObject.Find ("GenBtn").GetComponent<btnAch> ();

		achList.Add (achievement1);
		achList.Add (achievement2);
		achList.Add (achievement3);

		CreateAchievement ("General","Saved 10 Chickens", "Chicken Saviour", 5, 0, 0);
		CreateAchievement ("General", "Saved 50 Chickens", "Level 900", 5, 0, 1);
		CreateAchievement ("General", "Saved 100 Chickens", "Press up arrow to jump", 10, 0, 2);

		activeButton.Click ();

	}


	// Update is called once per frame
	void Update () {
		GameObject gameO = GameObject.Find("GameController");
		GameController gameC = (GameController)gameO.GetComponent(typeof(GameController));
		User currentPlayer = gameC.getCurrentPlayer();
		string playerSlot = currentPlayer.GetPlayerSlot();
		int numChicks = currentPlayer.GetCollectables ();
		//string currentPlayerName = currentPlayer.GetUsername ();

		if (Input.GetKeyDown( KeyCode.A)  || numChicks > 9) {
			currentPlayer.SetAchievements(1); //set ach to locked;
			achList[0].EarnAchievement ();
			PlayerPrefs.SetInt (playerSlot + "achievement1", 1); 
		} 

		if (Input.GetKeyDown( KeyCode.S) || numChicks > 49) {
			currentPlayer.SetAchievements2(1); //set ach to locked;
			achList[1].EarnAchievement ();
			PlayerPrefs.SetInt (playerSlot + "achievement2", 1); 
			
		}
		if (Input.GetKeyDown( KeyCode.D)  || numChicks > 99) {
			currentPlayer.SetAchievements3(1); //set ach to locked;
			achList[2].EarnAchievement ();
			PlayerPrefs.SetInt (playerSlot + "achievement3", 1); 
			
		}
	

	}

	public void CreateAchievement(string parent, string title, string description, int points, int spriteIndex, int index){

		GameObject achievement = GameObject.Instantiate(achievementPrefab);

		achList[index] = new Achievement (currentPlayer, currentPlayerName, title, description, points, spriteIndex, achievement); //create ach

		SetAchievementInfo (parent, achievement, title, index);

	}


	//SHOULD GET THE USER AND SET THAT TO THE USER. 
	public void SetAchievementInfo(string parent, GameObject achievement, string title, int index){
		//set parent, find game object and set category of this achievement
		achievement.transform.SetParent(GameObject.Find(parent).transform);

		//set the scale, cause in unity it changes when adding
		achievement.transform.localScale = new Vector3(1,1,1);
	
		//Title = child 0, component text. So we can change the text
		//achievement.transform.GetChild(0).GetComponent<Text>().text = title;
		//achievement.transform.GetChild(1).GetComponent<Text>().text = currentPlayer.Description;
		//achievement.transform.GetChild(2).GetComponent<Text>().text = currentPlayer.achievements[currentPlayerName + title].Points.ToString();
		//achievement.transform.GetChild(3).GetComponent<Image>().sprite = sprites[currentPlayer.achievements[currentPlayerName + title].SpriteIndex];
		achievement.transform.GetChild(0).GetComponent<Text>().text = achList[index].NameAchieve;
		achievement.transform.GetChild (1).GetComponent<Text> ().text = achList[index].Description;
		achievement.transform.GetChild(2).GetComponent<Text>().text = achList[index].Points.ToString();
		achievement.transform.GetChild(3).GetComponent<Image>().sprite = sprites[achList[index].SpriteIndex];
	
	}


	//changing tabs in the achievement category
	public void ChangeCategory(GameObject button){
		btnAch achievementButton = button.GetComponent<btnAch>();

		scrollRect.content = achievementButton.achievementList.GetComponent<RectTransform>();

		//changing through the tabs in the achievement panel
		achievementButton.Click();
		activeButton.Click();
		activeButton = achievementButton;
	}

	//public void EarnAchievement(string title){
	//string achievementPlayerKey = currentPlayerName + title;
	//if (currentPlayer.achievements[title].EarnAchievement()) { //looking into the dictionary
	//DO SOMETHING - for pop up 
	//GameObject achievement = (GameObject)Instantiate(visualAchievement);

	//SetAchievementInfo ("EarnCanvas", achievement, title);
	//StartCoroutine (HideAchievement (achievement));
	//}

	//}


	/*the popup operations
	public IEnumerator HideAchievement(GameObject achievement) {
		yield return new WaitForSeconds (3);
		Destroy (achievement);
	}*/
}
