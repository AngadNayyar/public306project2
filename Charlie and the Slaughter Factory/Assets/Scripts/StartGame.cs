using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {	
	public void start () {
		UnityEngine.SceneManagement.SceneManager.LoadScene("introlvl1");
	}
}
