using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

    public void toPrototypeLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("proto_lvl1");
    }

}
