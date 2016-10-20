using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GetCollectableCount : MonoBehaviour
{

    public Text chickenText;

    private float pointAnimDurationSec = 1f;
    private float pointAnimTimer = 0f;
    private float newTotalNumber;
    private float oldTotalNumber;
    private float displayedNumber;

    void Start()
    {
        //get the old number of collectables for the player
        GameObject gameO = GameObject.Find("GameController");
        GameController gameC = (GameController)gameO.GetComponent(typeof(GameController));
        User currentPlayer = gameC.getCurrentPlayer();
        string playerNumber = currentPlayer.GetPlayerSlot();

        oldTotalNumber = currentPlayer.GetCollectables();

        //the number of chickens to be updated and displayed (start at old number of chickens)
        displayedNumber = oldTotalNumber;

        // reset the level collectables and set the total collectables player prefs
        SetResetCollectables(currentPlayer);

        // get the new total number of chickens for the end point of the Lerp
        newTotalNumber = currentPlayer.GetCollectables();
 
    }

    void Update()
    {
        // change the chickens saved text to the latest increment until the new total is displayed
        pointAnimTimer += Time.deltaTime;
        float prcComplete = pointAnimTimer / pointAnimDurationSec;
        displayedNumber = Mathf.Lerp(oldTotalNumber, newTotalNumber, prcComplete);
        chickenText.text = displayedNumber.ToString("0");
    }

    void SetResetCollectables(User currentPlayer)
    {
        string playerSlot = currentPlayer.GetPlayerSlot();

        // add the current level collectables to the total collectables
        int oldTotal = currentPlayer.GetCollectables();
        int newTotal = oldTotal + PlayerPrefs.GetInt("LevelCollectables");
        currentPlayer.SetCollectables(newTotal);
        PlayerPrefs.SetInt(playerSlot + "TotalCollectables", newTotal);

        // reset the level collectables to 0
        PlayerPrefs.SetInt("LevelCollectables", 0);
    }
}