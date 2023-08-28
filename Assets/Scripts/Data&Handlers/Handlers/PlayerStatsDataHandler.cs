using System.IO;
using UnityEngine;

public class PlayerStatsDataHandler
{
	public PlayerStatsData Stats { get; private set; }

	private readonly string _directoryPath;
	private readonly string _dataPath;

	public PlayerStatsDataHandler()
	{
		_directoryPath = Application.dataPath + "/Data";
		_dataPath = _directoryPath + "/playerstats.json";
		LoadStats();
	}

	private void LoadStats()
	{
		if (File.Exists(_dataPath))
		{
			string data = File.ReadAllText(_dataPath);
			Stats = JsonUtility.FromJson<PlayerStatsData>(data);
		}
		else
		{
			Directory.CreateDirectory(_directoryPath);
			Stats = new();
		}
	}

	public void SaveStats(PlayerStatsData statsData)
	{
		Stats = statsData;
		string data = JsonUtility.ToJson(Stats);
		File.WriteAllText(_dataPath, data);
	}
}
