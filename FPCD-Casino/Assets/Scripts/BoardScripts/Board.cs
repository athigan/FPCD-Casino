using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using KGDEngin;

public class Board {
//	string.Format("{0}: {1:0.0} - {2:yyyy}",value1,value2,value3);
	private static Board m_singleton;
	private List<Bet> m_betList;
	public static Board GetSingleton()
	{
		if(m_singleton == null)
			m_singleton = new Board();
		return m_singleton;
	}

	private Board()
	{
		m_betList = new List<Bet>();
	}

	public void ClickToBet (BoardFaceID betID) {
		DebugMessage.Log(string.Format("Player {0} Click bet : {1} with money {2}",
		                               GameManager.GetSingleton().GetPlayer(),
		                               betID.ToString(),
		                               GameManager.GetSingleton().m_testBet));

	}

	public void ClickToRemoveBet (BoardFaceID betID) {
		DebugMessage.Log(string.Format("Player {0} Click Remove bet : {1}",
		                               GameManager.GetSingleton().GetPlayer(),
		                               betID.ToString()));
	}

	public void DisplayAllConditionToBet()
	{
	}
	public void DisplayPlayer(Player pl,int position)
	{
	}
	public void DisplayBet(int money,BetType bt)
	{
	}
	public void DisplayDiceWithResult(int result)
	{
	}
	public void DisplayNewTurn()
	{
	}
	public void DisplayGiveMoney(Player pl,int money)
	{
	}
}
