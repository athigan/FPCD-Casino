using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum BUTTON_BET_TYPE
{
	INCREASE,
	DECREASE,
}
public class ButtonBet : MonoBehaviour {

	[SerializeField]
	private Text m_text;
	[SerializeField]
	private int m_totalBetForThisButton;
	[SerializeField]
	private BUTTON_BET_TYPE m_type = BUTTON_BET_TYPE.INCREASE;
	private void Awake () {
		GetComponent<Button>().onClick.AddListener(delegate () {
			if(m_type == BUTTON_BET_TYPE.INCREASE)
				this.IncreaseBet();
			else
				this.DeIncreaseBet();
		});
		m_text.text = m_totalBetForThisButton.ToString("N0");
	}

	private void IncreaseBet () {
		Player p = GameManager.GetSingleton().GetPlayer(0);
		p.IncreaseBetValue(m_totalBetForThisButton);
	}
	private void DeIncreaseBet () {
		Player p = GameManager.GetSingleton().GetPlayer(0);
		p.DecreaseBetValue(m_totalBetForThisButton);
	}
}
