using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BaseCryptid : MonoBehaviour
{


	public string PName;
	public Sprite Image;
	public BiomeList BiomeFound;
	public CryptidType Type;
	public Rarity Rarity;
	public int Hp;
	private int maxHp;
	public Stat AttackStat;
	public Stat DefStat;
	public CryptidStats CryptidStats;
	public bool canEvolve;
	public CryptidEvolution evolveTo;
	private int level;


	void Start ()
	{
		maxHp = Hp;
	}
	void Update () {
	
	}

	public void AddMember(BaseCryptid bc)
	{
		this.PName = bc.PName;
		this.Image = bc.Image;
		this.Type = bc.Type;
		this.Rarity = bc.Rarity;
		this.Hp = bc.Hp;
		this.DefStat = bc.DefStat;
		this.CryptidStats = bc.CryptidStats;
		this.level = bc.level;
		//this.Rarity = bc.Rarity;
		//this.Hp = bc.Hp;
		//this.AttackStat = bc.AttackStat;
	}
}

public enum Rarity
{
	VeryCommon, 
	Common,
	SemiRare,
	Rare,
	VeryRare,
	Legendary
}

public enum CryptidType
{
	Flying, 
	Ground,
	Rock,
	Steel,
	Fire,
	Water,
	Psychic,
	Electric,
	Fighting,
	Ice,
	Dark,
	Dragon,
	Normal,
	Grass,
}

[System.Serializable]
public class CryptidEvolution
{
	public BaseCryptid nextEvolution;
	public int levelUpLevel;
}

[System.Serializable]
public class CryptidStats
{
	
	public int AttackStat;
	public int DefenseStat;
	public int SpeedStat;
	public int SpecialAttackStat;
	public int SpecialDefenseStat;
	public int EvasionStat;
}