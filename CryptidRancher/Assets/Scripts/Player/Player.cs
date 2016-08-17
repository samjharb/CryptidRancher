using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public List<OwnedCryptid> OwnedCryptids = new List<OwnedCryptid>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

[System.Serializable]
public class OwnedCryptid
{
	public string NickName;
	public BaseCryptid baseCryptid;
	private int level;
	public List<CryptidMoves> moves = new List<CryptidMoves>();
}