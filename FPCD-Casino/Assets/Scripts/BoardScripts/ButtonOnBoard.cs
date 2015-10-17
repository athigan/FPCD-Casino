using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonOnBoard : MonoBehaviour {
	[SerializeField]
	private BoardFaceID m_faceID;

	void Awake()
	{
		gameObject.name = m_faceID.ToString();
		GetComponent<Button>().onClick.AddListener(delegate () { this.Bet(); });
	}
	public void RemoveBet()
	{
		Board.GetSingleton().ClickToRemoveBet(m_faceID);
	}

	public void Bet()
	{
		Board.GetSingleton().ClickToBet(m_faceID);
	}
}
