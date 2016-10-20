using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

/*
 * Managing the Achievements in the achievement panel 
*/
public class AchievementManager : MonoBehaviour {

	//Reference to the prefab of our achievmenet 
	public GameObject achievementPrefab;

	public Sprite[] sprites; //for the sprite image for the achievement

	private btnAch activeButton;
	public ScrollRect scrollRect;

	public GameObject visualAchievement;

	public Dictionary<string, Achievement> achievements = new Dictionary<string, Achievement>();

	// Use this for initialization
	void Start () {



		CreateAchievement("General","Jump", "Press up arrow to jump", 5, 0);

		activeButton = GameObject.Find("GenBtn").GetComponent<btnAch> ();

		foreach (GameObject achievementList in GameObject.FindGameObjectsWithTag("AchievementList"))
		{
			achievementList.SetActive (false);
		}

		activeButton.Click ();

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			EarnAchievement ("Jump");
		}
	}

	public void EarnAchievement(string title){
		if (achievements [title].EarnAchievement()) {
			//DO SOMETHING
			GameObject achievement = (GameObject)Instantiate(visualAchievement);
			//StartCoroutine (HideAchievement (achievement));
		}
	}

	//public IEnumerator HideAchievement() {

		//yield return WaitForSeconds (3);
	//	Destroy (achievement);
	//}

	public void CreateAchievement(string category, string title, string description, int points, int spriteIndex){
		GameObject achievement = GameObject.Instantiate(achievementPrefab);

		Achievement newAchievement = new Achievement (name, description, points, spriteIndex, achievement); //create ach
		//add entry to dictionary
		achievements.Add(title, newAchievement);

		SetAchievementInfo (category, achievement, title, description, points, spriteIndex);
	}

	public void SetAchievementInfo(string category, GameObject achievement, string title, string description, int points, int spriteIndex){
		//set parent, find game object and set category of this achievement
		achievement.transform.SetParent(GameObject.Find(category).transform);

		//set the scale, cause in unity it changes when adding
		achievement.transform.localScale = new Vector3(1,1,1);

		//Title = child 0, component text. So we can change the text
		achievement.transform.GetChild(0).GetComponent<Text>().text = title;
		achievement.transform.GetChild(1).GetComponent<Text>().text = description;
		achievement.transform.GetChild(2).GetComponent<Text>().text = points.ToString();
		achievement.transform.GetChild(3).GetComponent<Image>().sprite = sprites[spriteIndex];

	}
	public void ChangeCategory(GameObject button){
		btnAch achievementButton = button.GetComponent<btnAch>();

		scrollRect.content = achievementButton.achievementList.GetComponent<RectTransform>();

		achievementButton.Click();
		activeButton.Click();
		activeButton = achievementButton;
	}	
}
