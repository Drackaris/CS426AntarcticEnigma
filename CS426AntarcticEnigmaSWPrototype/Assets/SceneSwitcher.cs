using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public SaveSystem s;

    public void SceneSwitch()
    {
        s.SaveGame(2, 5);
        SceneManager.LoadScene(2);
    }

}
