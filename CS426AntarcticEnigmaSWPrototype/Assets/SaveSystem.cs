using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class SaveSystem : MonoBehaviour
{
    public GUIMusic sound;

    void start()
    {
        sound.audioSource.Play();
    }
    public void NewGame()
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/SaveGame.txt";

        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, 1);
        formatter.Serialize(stream, 0);
        stream.Close();

        sound.audioSource.Stop();
        SceneManager.LoadScene(1);

    }

    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/SaveGame.txt";

        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            int Day = (int)formatter.Deserialize(stream);
            int Fail = (int)formatter.Deserialize(stream);

            sound.audioSource.Stop();
            SceneManager.LoadScene(Day);

            Debug.Log(Day);
            Debug.Log(Fail);
        }
        else
        {

            Debug.LogError("No file"); 
        }

    }

    public void SaveGame(int Day, int Fails)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/SaveGame.txt";

        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, Day);
        formatter.Serialize(stream, Fails);
        stream.Close();

        //SceneManager.LoadScene(Day);

    }

    public void Tutorial()
    {
        SceneManager.LoadScene(3);
    }

    public void Creditss()
    {
        SceneManager.LoadScene(6);
    }




}
