using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

    public void toLevel2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("introlvl2");
    }

}
