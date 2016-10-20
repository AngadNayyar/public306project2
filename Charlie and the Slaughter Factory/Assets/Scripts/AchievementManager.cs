using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

/*
 * Managing the Achievements in the achievement panel.
*/
public class AchievementManager : MonoBehaviour {

	//Reference to the prefab of our achievement
	public GameObject achievementPrefab;

	//for the sprite image for the achievement set in unity
	public Sprite[] sprites; 

	//for the achievement panel
	private btnAch activeButton;
	public ScrollRect scrollRect;

	//unlocked sprite the gold shield
	public Sprite unlockedSprite;

	//the current player and the number of collected chickens. 
	public int collectedChicks; //no. chickens er person
	public User currentPlayer; //currentPlayer
	public string currentPlayerName;

	private static AchievementManager instance;  //singleton way of accessing object without having instance of the object
	public static AchievementManager Instance {
		get {
			if (instance == null) {
				instance = GameObject.FindObjectOfType<AchievementManager> ();
			}
			return instance;
		}
	}
	//achievements for the list, and the list
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
		//adding achievements to the achievement lists
		achList.Add (achievement1);
		achList.Add (achievement2);
		achList.Add (achievement3);
		//create the 3 achievements
		CreateAchievement ("General","Saved 10 Chickens", "Chicken Saviour", 5, 0, 0);
		CreateAchievement ("General", "Saved 50 Chickens", "Chicken Saint", 5, 0, 1);
		CreateAchievement ("General", "Saved 100 Chickens", "Chicken God", 10, 0, 2);
		//for the tabs
		activeButton.Click ();
	}

	// Update is called once per frame
	void Update () {
		//updating to get the information of the user and the number of chickens
		GameObject gameO = GameObject.Find("GameController");
		GameController gameC = (GameController)gameO.GetComponent(typeof(GameController));
		User currentPlayer = gameC.getCurrentPlayer();
		string playerSlot = currentPlayer.GetPlayerSlot();
		int numChicks = currentPlayer.GetCollectables ();

		if (numChicks > 9) { 
			currentPlayer.SetAchievements(1); //set ach of getting 10 chickens;
			achList[0].EarnAchievement ();
			PlayerPrefs.SetInt (playerSlot + "achievement1", 1); 
		} 
		if (numChicks > 49) {
			currentPlayer.SetAchievements2(1); //set ach of getting 50 chickens;
			achList[1].EarnAchievement ();
			PlayerPrefs.SetInt (playerSlot + "achievement2", 1); 
		}
		if (numChicks > 99) {
			currentPlayer.SetAchievements3(1); //set ach of getting 100 chickens;
			achList[2].EarnAchievement ();
			PlayerPrefs.SetInt (playerSlot + "achievement3", 1); 	
		}
	}

	//Create the achievement in setting up info and instantiating the prefab to be placed. 
	public void CreateAchievement(string parent, string title, string description, int points, int spriteIndex, int index){
		//instantiate the image/prefab
		GameObject achievement = GameObject.Instantiate(achievementPrefab);
		//creating the new achievement 
		achList[index] = new Achievement (currentPlayer, currentPlayerName, title, description, points, spriteIndex, achievement); //create ach
		SetAchievementInfo (parent, achievement, title, index);
	}

	//set info on the achievement
	public void SetAchievementInfo(string parent, GameObject achievement, string title, int index){
		//the parent is the location where the achievement needs to appear
		achievement.transform.SetParent(GameObject.Find(parent).transform);
		//set the scale, cause in unity it changes when adding
		achievement.transform.localScale = new Vector3(1,1,1);
		//setting up the prefab of the achievements
		achievement.transform.GetChild(0).GetComponent<Text>().text = achList[index].NameAchieve;
		achievement.transform.GetChild (1).GetComponent<Text> ().text = achList[index].Description;
		achievement.transform.GetChild(2).GetComponent<Text>().text = achList[index].Points.ToString();
		achievement.transform.GetChild(3).GetComponent<Image>().sprite = sprites[achList[index].SpriteIndex];
	}
		
	//changing tabs in the achievement category
	public void ChangeCategory(GameObject button){
		btnAch achievementButton = button.GetComponent<btnAch>();
		//switching to the content of each tab
		scrollRect.content = achievementButton.achievementList.GetComponent<RectTransform>();
		//changing through the tabs in the achievement panel
		achievementButton.Click();
		activeButton.Click();
		activeButton = achievementButton;
	}
}
