using UnityEngine;
using System.Collections;

public class GameManager {

	private static GameManager m_singleton;

	public static GameManager GetSingleton()
	{
		if(m_singleton == null)
			m_singleton = new GameManager();
		return m_singleton;
	}


	private Player m_player;
	private GameManager()
	{
		m_player = new Player();
	}

	public Player GetPlayer()
	{
		return m_player;
	}
	public int m_testBet = 500;
	public int m_testMoney = 500000000;
}
