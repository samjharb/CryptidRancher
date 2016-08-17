using System;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;
using Random = System.Random;

public class GameManager : MonoBehaviour
{

	public GameObject playerCamera;
	public GameObject battleCamera;
	public GameObject player;

	public List<BaseCryptid> AllCryptids = new List<BaseCryptid>(); 
	public List<CryptidMoves> AllCryptidMoves = new List<CryptidMoves>();

	public Transform attackPodium;
	public Transform defensePodium;
	public GameObject EmptyCryptid;

	public BattleManager bm;

	// Use this for initialization
	void Start () {
		playerCamera.SetActive(true);
		battleCamera.SetActive(false);


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void EnterBattle(Rarity rarity)
	{
		playerCamera.SetActive(false);
		battleCamera.SetActive(true);

		BaseCryptid battleCryptid = GetRandomCryptidFromList(GetCryptidByRarity(rarity));

		Debug.Log(battleCryptid.name);

		player.GetComponent<PlayerMovement>().isAllowedToMove = false;

		GameObject dPoke = Instantiate(EmptyCryptid, defensePodium.transform.position, Quaternion.identity) as GameObject;

		Vector3 cryptidLocalPos = new Vector3(0,1,0);
		dPoke.transform.parent = defensePodium;
		dPoke.transform.localPosition = cryptidLocalPos;
		BaseCryptid tempCryptid = dPoke.AddComponent<BaseCryptid>() as BaseCryptid;
		tempCryptid.AddMember(battleCryptid);

		dPoke.GetComponent<SpriteRenderer>().sprite = battleCryptid.Image;
		
		bm.ChangeMenu(BattleMenu.Selection);

	}

	public List<BaseCryptid> GetCryptidByRarity(Rarity rarity)
	{
		List<BaseCryptid> returnCryptid = AllCryptids.Where(o => o.Rarity == rarity).ToList();
		return returnCryptid.Any() ? AllCryptids : returnCryptid;
	}

	public BaseCryptid GetRandomCryptidFromList(List<BaseCryptid> cryptids)
	{
		Random rng = new Random();
		var index = rng.Next(cryptids.Count);
		BaseCryptid cryptid = cryptids[index];
		return cryptid;
	}

}

[System.Serializable]
public class CryptidMoves
{
	string Name;
	public MoveType categoryType;
	public Stat moveStat;
	public CryptidType moveType;
	public int PP;
	public float power;
	public float accuracy;
}

[System.Serializable]
public class Stat
{
	public float Min;
	public float Max;
	
}

public enum MoveType
{
	Physical, 
	Special, 
	Status
}


