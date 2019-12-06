using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;

// user data 
[SerializeField]
public class GameData
{
	public static List<string> playerData = new List<string>();
}

public class EventDataLoader : MonoBehaviour
{
    // 큰스테이지, 세부스테이지
	private int gamestagenum = 4, ingameStagenum = 3;

	void Start()
	{
		// data not null
		if (File.Exists(Application.persistentDataPath + "/GameData.json"))
		{
			LoadData();
		}
		// data null
		else
		{
			
			SaveData();
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
