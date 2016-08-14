using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BasePokemon : MonoBehaviour
{


	public string Name;
	public Sprite Image;
	public BiomeList BiomeFound;
	public CryptidType Type;
	public Rarity Rarity;
	public float BaseHp;
	private float _maxHp;
	public float BaseAttack;
	public float MaxAttack;
	public float BaseDef;
	public float MaxDef;
	public float speed;

	private int level;


	void Start () {
	
	}
	void Update () {
	
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
	Dragon
}
