using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public string attackedTeritory;
    public bool battleHasEnded;
    public bool battleWon;

    public int wood;
    public int stone;
    public int gold;


    [System.Serializable]
    public class SaveData
    {
        public List<Teritory> savedTeritories = new List<Teritory>();
        public int cur_wood;
        public int cur_stone;
        public int cur_gold;
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void Saving()
    {
        SaveData data = new SaveData();
        for (int i = 0; i < TeritoryManager.instance.teritoryList.Count; i++)
        {
            data.savedTeritories.Add(TeritoryManager.instance.teritoryList[i].GetComponent<TeritoryHandler>().teritory);
        }

        data.cur_wood = wood;
        data.cur_stone = stone;
        data.cur_gold = gold;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/SaveFile.dat", FileMode.Create);
        bf.Serialize(stream, data);
        stream.Close();
        print("Saved game.");
    }

    public void Loading()
    {
        if (File.Exists(Application.persistentDataPath + "/SavedFile.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/SavedFile.dat", FileMode.Open);

            SaveData data = (SaveData)bf.Deserialize(stream);
            stream.Close();

            for (int i = 0; i < data.savedTeritories.Count; i++)
            {
                for (int j = 0; j < TeritoryManager.instance.teritoryList.Count; j++)
                {
                    if (data.savedTeritories[i].name == TeritoryManager.instance.teritoryList[j].GetComponent<TeritoryHandler>().teritory.name) ;
                    {
                        TeritoryManager.instance.teritoryList[j].GetComponent<TeritoryHandler>().teritory = data.savedTeritories[i];
                    }
                }
            }

            wood = data.cur_wood;
            stone = data.cur_stone;
            gold = data.cur_gold;

            TeritoryManager.instance.TintTeritory();
            print("Game loaded.");
        }
        else
        {
            print("No savefile found.");
        }
    }

    public void DeleteSavedFile()
    {
        if (File.Exists(Application.persistentDataPath + "/SavedFile.dat"))
        {
            File.Delete(Application.persistentDataPath + "/SavedFile.dat");
            print("SaveFile deleted");
            //RESTART GAME
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
