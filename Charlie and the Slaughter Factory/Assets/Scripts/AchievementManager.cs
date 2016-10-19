using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
 * Managing the Achievements in the achievement panel 
*/
public class AchievementManager : MonoBehaviour {

	//Reference to the prefab of our achievmenet 
	public GameObject achievementPrefab;

	public Sprite[] sprites; //for the sprite image for the achievement

	// Use this for initialization
	void Start () {
		CreateAchievement("General","yo", "you did the things", 100, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CreateAchievement(string category, string title, string description, int points, int spriteIndex){
		GameObject achievement = GameObject.Instantiate(achievementPrefab);
		SetAchievementInfo (category, achievement, title, description, points, spriteIndex);
	}

	public void SetAchievementInfo(string category, GameObject achievement, string title, string description, int points){
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
}
