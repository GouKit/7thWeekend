using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;

// user data 
[SerializeField]
public class GameData
{
	public static LinkedList<PlayerBase> playerData = new LinkedList<PlayerBase>();
    public static int userLevel = 1;
}

public class DataLoader : MonoBehaviour
{
    
	void Start()
	{
		// data not null
		if (File.Exists(Application.persistentDataPath + "/GameData.json"))
		{
			LoadData();
			GameData.userLevel = PlayerPrefs.GetInt("UserLevel");
		}
		// data null
		else
		{
			SaveData();
			PlayerPrefs.SetInt("UserLevel", GameData.userLevel);
		}
	}

	public void SaveData()
	{
		GameData tempData = new GameData();
		
		// data save to json
		JsonData gamemData = JsonMapper.ToJson(tempData);

		// create json file
		File.WriteAllText(Application.persistentDataPath + "/GameData.json",gamemData.ToString());
	}

	public void LoadData()
	{
		// load json file
		string JsonString = File.ReadAllText(Application.persistentDataPath + "/GameData.json");

		// txt to object
		JsonData gamemData = JsonMapper.ToObject(JsonString);

		// load to array
		
	}

}
