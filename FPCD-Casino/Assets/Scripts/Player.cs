using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	private Profile m_Profile;
	private Bet m_bet;

	public Bet Bet
	{
		get { return m_bet; }
	}
	public Profile PlayerProfile
	{
		get { return m_Profile; }
		set { m_Profile = value; }
	}

	public void InitPlayer(int id, string name, int coin, int age)
	{
		m_Profile = new Profile(id, name, coin, age);
		gameObject.name = name;
		m_bet = new Bet();
	}
	private void VerifyBet()
	{
		if(m_bet.m_totalBet > m_Profile.Coin)
			m_bet.m_totalBet = m_Profile.Coin;
		if(m_bet.m_totalBet < 0)
			m_bet.m_totalBet = 0;
	}

	public void IncreaseBetValue(int bet)
	{
		m_bet.m_totalBet += bet;
		VerifyBet();
	}
	public void DecreaseBetValue(int bet)
	{
		m_bet.m_totalBet -= bet;
		VerifyBet();
	}
}
