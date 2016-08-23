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

    private GameObject dPoke;
    private GameObject aPoke;

	public List<BaseCryptid> AllCryptids = new List<BaseCryptid>(); 
	public List<CryptidMoves> AllCryptidMoves = new List<CryptidMoves>();
    public List<BaseCryptid> PlayerCryptids = new List<BaseCryptid>();

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

    public void EndBattle()
    {

    }

	public void EnterBattle(Rarity rarity)
	{
		playerCamera.SetActive(false);
		battleCamera.SetActive(true);

		BaseCryptid battleCryptid = GetRandomCryptidFromList(GetCryptidByRarity(rarity));

		Debug.Log(battleCryptid.name);

		player.GetComponent<PlayerMovement>().isAllowedToMove = false;

		dPoke = Instantiate(EmptyCryptid, defensePodium.transform.position, Quaternion.identity) as GameObject;

		Vector3 cryptidLocalPos = new Vector3(0,1,0);
		dPoke.transform.parent = defensePodium;
		dPoke.transform.localPosition = cryptidLocalPos;
		BaseCryptid tempCryptid = dPoke.AddComponent<BaseCryptid>() as BaseCryptid;
		tempCryptid.AddMember(battleCryptid);

		dPoke.GetComponent<SpriteRenderer>().sprite = battleCryptid.Image;

        aPoke = Instantiate(EmptyCryptid, attackPodium.transform.position, Quaternion.identity) as GameObject;

        BaseCryptid attackCryptid;

        if (PlayerCryptids.Count == 0)
        {
            attackCryptid = new BaseCryptid();
            attackCryptid.Image = player.GetComponent<PlayerMovement>().northSprite;
        }
        else
        {
            attackCryptid = PlayerCryptids.First();
        }

        Vector3 acryptidLocalPos = new Vector3(0, 1, 0);
        aPoke.transform.parent = attackPodium;
        aPoke.transform.localPosition = acryptidLocalPos;
        BaseCryptid atempCryptid = aPoke.AddComponent<BaseCryptid>() as BaseCryptid;
        atempCryptid.AddMember(attackCryptid);

        aPoke.GetComponent<SpriteRenderer>().sprite = attackCryptid.Image;

        bm.BattleResult += new BattleManager.BattleResultEventHandler(ExitBattle);
		bm.EnterBattle(PlayerCryptids, battleCryptid);
        
	}

    public void ExitBattle(int ExitCode)
    {
        playerCamera.SetActive(true);
        battleCamera.SetActive(false);

        Destroy(dPoke);
        Destroy(aPoke);

        player.GetComponent<PlayerMovement>().isAllowedToMove = true;
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


