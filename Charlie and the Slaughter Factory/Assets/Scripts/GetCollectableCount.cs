using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GetCollectableCount : MonoBehaviour
{

    public Text chickenText;

    private float pointAnimDurationSec = 1f;
    private float pointAnimTimer = 0f;
    private float newTotalScore;
    private float oldTotalScore;
    private float displayedScore;

    void Start()
    {
        // get the old total score for the start point of the Lerp
        oldTotalScore = PlayerPrefs.GetInt("TotalCollectables");

        // the score to be updated and displayed (start at old total score)
        displayedScore = oldTotalScore;

        // reset the level collectables and set the total collectables player prefs
        SetResetCollectables();

        // get the new total score for the end point of the Lerp
        newTotalScore = PlayerPrefs.GetInt("TotalCollectables");
    }

    void Update()
    {
        // change the chickens saved text to the latest increment until the new total is displayed
        pointAnimTimer += Time.deltaTime;
        float prcComplete = pointAnimTimer / pointAnimDurationSec;
        displayedScore = Mathf.Lerp(oldTotalScore, newTotalScore, prcComplete);
        chickenText.text = displayedScore.ToString("0");
    }

    void SetResetCollectables()
    {
        // add the current level collectables to the total collectables
        int oldTotal = PlayerPrefs.GetInt("TotalCollectables");
        int newTotal = oldTotal + PlayerPrefs.GetInt("LevelCollectables");
        PlayerPrefs.SetInt("TotalCollectables", newTotal);

        // reset the level collectables to 0
        PlayerPrefs.SetInt("LevelCollectables", 0);
    }
}