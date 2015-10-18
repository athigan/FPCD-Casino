using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager
{

	private static GameManager m_singleton;

	public static GameManager GetSingleton ()
	{
		if (m_singleton == null)
			m_singleton = new GameManager ();
		return m_singleton;
	}
	
	private List<Player> m_playerList;

	private GameManager ()
	{
		m_playerList = new List<Player> ();
		CreateFakePlayerWithNumber (1);
	}

	private void CreateFakePlayerWithNumber (int number)
	{
		m_playerList.Clear ();
		for (int i = 0; i < number; i++) {
			GameObject playerObject = new GameObject ();
			Object.DontDestroyOnLoad (playerObject);
			Player player = playerObject.AddComponent<Player> ();
			player.InitPlayer (i, "Test User" + i, 1000000, 25);
			m_playerList.Add (player);
		}
	}

	public Player GetPlayer (int id)
	{
		return m_playerList[id];
	}
}
