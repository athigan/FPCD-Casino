using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using KGDEngin;
using UnityEngine.UI;

public class Board : MonoBehaviour{
//	string.Format("{0}: {1:0.0} - {2:yyyy}",value1,value2,value3);
	private static Board m_singleton;
	private Dictionary<Dictionary<Player,BoardFaceID>,Bet> m_betList;
	[SerializeField]
	private Text m_nameText;
	[SerializeField]
	private Text m_coinText;
	[SerializeField]
	private Text m_betText;
	private int m_lastUpdate = -1;

	public static Board GetSingleton()
	{
		return m_singleton;
	}
	private void Awake()
	{
		m_singleton = this;
	}
	private void Start()
	{
		m_betList = new Dictionary<Dictionary<Player, BoardFaceID>, Bet>();
		DisplayPlayer(GameManager.GetSingleton().GetPlayer(0),0);
	}
	private Board()
	{

	}

	public void ClickToBet (BoardFaceID betID) {
		Dictionary<Player, BoardFaceID> playerBet = new Dictionary<Player, BoardFaceID>();
		Player p = GameManager.GetSingleton().GetPlayer(0);
		playerBet.Add(p, betID);
		Bet NewBet = new Bet();
		NewBet.m_totalBet = p.Bet.m_totalBet;
		if(m_betList.ContainsKey(playerBet))
		{
			Bet oldBet = m_betList[playerBet];
			NewBet.m_totalBet += oldBet.m_totalBet;
			m_betList.Remove(playerBet);
		}

		m_betList.Add(playerBet,NewBet);

		DebugMessage.Log(string.Format("Player {0} Click bet : {1} with money {2}",
		                               p.PlayerProfile.Name,
		                               NewBet.m_betType,
		                               NewBet.m_totalBet));

	}

	public void ClickToRemoveBet (BoardFaceID betID) {
		Player p = GameManager.GetSingleton().GetPlayer(0);
//		DebugMessage.Log(string.Format("Player {0} Click Remove bet : {1}",
//		                               p.PlayerProfile.Name,
//		                               betID.ToString()));
	}

	public void DisplayAllConditionToBet()
	{
	}
	public void DisplayPlayer(Player pl,int position)
	{
		m_nameText.text = "Name : "+pl.PlayerProfile.Name;
		StartCoroutine(UpdateUserData(pl));
	}

	private IEnumerator UpdateUserData(Player pl)
	{
		while(true)
		{
			yield return 0;
			if(m_lastUpdate != pl.Bet.m_totalBet)
			{
				m_coinText.text = "Coin : "+pl.PlayerProfile.Coin;
				m_betText.text = "Bet : "+pl.Bet.m_totalBet;
				m_lastUpdate = pl.Bet.m_totalBet;
			}
		}
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
