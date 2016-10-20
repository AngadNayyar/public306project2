using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GetCollectableCount : MonoBehaviour
{

    public Text chickenText;

    private int oldTotalNumber;
    private int newTotalNumber;
    private int displayedNumber;

    void Start()
    {
        //get the old number of collectables for the player
        GameObject gameO = GameObject.Find("GameController");
        GameController gameC = (GameController)gameO.GetComponent(typeof(GameController));
        User currentPlayer = gameC.getCurrentPlayer();
        string playerNumber = currentPlayer.GetPlayerSlot();

        //get the player's old number of chickens collected
        oldTotalNumber = currentPlayer.GetCollectables();

        //the number of chickens to be updated and displayed (start at old number of chickens)
        displayedNumber = oldTotalNumber;

        //reset the level collectables and set the total collectables player prefs
        SetResetCollectables(currentPlayer);

        //get the new total number of chickens to update the text to
        newTotalNumber = currentPlayer.GetCollectables();

    }

    void Update()
    {
        StartCoroutine(IncrementCountDisplay());
    }

    //every 0.05 seconds increase the number of chickens collected
    IEnumerator IncrementCountDisplay()
    {
        if (displayedNumber < newTotalNumber)
        {
            displayedNumber += 1;
            chickenText.text = displayedNumber.ToString();
        }
        yield return new WaitForSecondsRealtime(0.06f);
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