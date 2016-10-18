using UnityEngine;
using System.Collections;

public class AchievementManager : MonoBehaviour {

	//Reference to the prefab of our achievmenet 
	public GameObject achievementPrefab;

	// Use this for initialization
	void Start () {
		CreateAchievement("General");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CreateAchievement(string category){
		GameObject achievement = GameObject.Instantiate(achievementPrefab);
	}
}
