using System;
public class Profile
{
	private int m_id;
	private string m_name;
	private int m_coin;
	private int m_age;

	public Profile (int id, string name, int coin, int age)
	{
		Id = id;
		Name = name;
		Coin = coin;
		Age = age;
	}

	public int Id
	{
		get { return m_id; }
		set { m_id = value; }
	}
	public string Name
	{
		get { return m_name; }
		set { m_name = value; }
	}
	public int Coin
	{
		get { return m_coin; }
		set { m_coin = value; }
	}
	public int Age {
		get { return m_age; }
		set { m_age = value; }
	}
}


