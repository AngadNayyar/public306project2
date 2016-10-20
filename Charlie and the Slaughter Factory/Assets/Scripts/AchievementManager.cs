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

	private btnAch activeButton;
	public ScrollRect scrollRect;

	public GameObject visualAchievement;

	public Dictionary<string, Achievement> achievements = new Dictionary<string, Achievement>();

	public Sprite unlockedSprite;

	public Text textPoints;

	private static AchievementManager instance;
	public static AchievementManager Instance {
		get {
			if (instance == null) {
				instance = GameObject.FindObjectOfType<AchievementManager> ();
			}
			return instance;
		}
	}

 //singleton way of accessing object without having instance of the object



	// Use this for initialization
	void Start () {
		
		//setting achievement tab to be active
		activeButton = GameObject.Find("GenBtn").GetComponent<btnAch> ();


		CreateAchievement("General","10", "Chicken Saviour", 5, 0);
		CreateAchievement("General","50", "Level 900", 5, 0);
		CreateAchievement("General","100", "Press up arrow to jump", 10, 0);
		CreateAchievement("General","200", "Press up arrow to jump", 20, 0);
		CreateAchievement("General","500", "Press up arrow to jump", 50, 0);
		CreateAchievement("Other","yo", "Press up arrow to jump", 5, 0);

		//going through Achievementslist and putting 
		foreach (GameObject achievementList in GameObject.FindGameObjectsWithTag("AchievementList"))
		{
			achievementList.SetActive (false);
		}

		activeButton.Click ();
	}

	// Update is called once per frame
	void Update () {
		//check how many chickens you have 

		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			EarnAchievement ("100");
		}
		if (Input.GetKeyDown (KeyCode.W)) {
			EarnAchievement ("yo");
			print ("this happened");
		}
	}

	public void EarnAchievement(string title){
		if (achievements [title].EarnAchievement()) { //looking into the dictionary
			//DO SOMETHING
			GameObject achievement = (GameObject)Instantiate(visualAchievement);
			SetAchievementInfo ("EarnCanvas", achievement, title);

			StartCoroutine (HideAchievement (achievement));
		}
	}

	public IEnumerator HideAchievement(GameObject achievement) {

		yield return new WaitForSeconds (3);
		Destroy (achievement);
	}

	public void CreateAchievement(string parent, string title, string description, int points, int spriteIndex){
		GameObject achievement = GameObject.Instantiate(achievementPrefab);

		Achievement newAchievement = new Achievement (name, description, points, spriteIndex, achievement); //create ach
		//add entry to dictionary
		achievements.Add(title, newAchievement);

		SetAchievementInfo (parent, achievement, title);
	}

	//SHOULD GET THE USER AND SET THAT TO THE USER. 
	public void SetAchievementInfo(string parent, GameObject achievement, string title){
		//set parent, find game object and set category of this achievement
		achievement.transform.SetParent(GameObject.Find(parent).transform);

		//set the scale, cause in unity it changes when adding
		achievement.transform.localScale = new Vector3(1,1,1);

		//Title = child 0, component text. So we can change the text
		achievement.transform.GetChild(0).GetComponent<Text>().text = title;
		achievement.transform.GetChild(1).GetComponent<Text>().text = achievements[title].Description;
		achievement.transform.GetChild(2).GetComponent<Text>().text = achievements[title].Points.ToString();
		achievement.transform.GetChild(3).GetComponent<Image>().sprite = sprites[achievements[title].SpriteIndex];

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
}
