using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	private int m_id;
	private string m_name;
	private int m_coin;
	private Profile m_Profile;
	public int Id
	{
		get { return m_id; }
		set { m_id = value; }
	}
	public int Name
	{
		get { return m_name; }
		set { m_name = value; }
	}
	public int Coin
	{
		get { return m_coin; }
		set { m_coin = value; }
	}

	// Use this for initialization
	void Start () {
		m_Profile = new Profile();
	}
	void Start (string id,string name,int coin) {
		Id = id;
		Name = name;
		Coin = coin;
		m_Profile = new Profile();
	}

	public string ProfileFirstName
	{
		get { return m_Profile.FirstName; }
		set { m_Profile.FirstName = value; }
	}
	public string ProfileLastName
	{
		get { return m_Profile.LastName; }
		set { m_Profile.LastName = value; }
	}
	public string ProfileNickName
	{
		get { return m_Profile.NickName; }
		set { m_Profile.NickName = value; }
	}
	public int ProfileAge
	{
		get { return m_Profile.Age; }
		set { m_Profile.Age = value; }
	}

	
	// Update is called once per frame
	//void Update () {
	//
	//}
}
