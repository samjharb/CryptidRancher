using UnityEngine;
using System.Collections;

public class LongGrass : MonoBehaviour
{

	public BiomeList grassType;
	private const float encounterMod = 187.5f;
	private GameManager gm;
	// Use this for initialization
	void Start ()
	{
		gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.GetComponent<PlayerMovement>())
		{
			//p = x / 187.5
			// VC = 10
			// C = 8.5
			// Semi-r = 6.75
			// Rare = 3.33
			// V-Rare = 1.25
			// L = .25
			float vc = 10/encounterMod;
			float c = 8.5f/encounterMod;
			float sr = 6.75f/encounterMod;
			float r = 3.33f/encounterMod;
			float vr = 1.25f/encounterMod;
			float l = .25f/encounterMod;

			float p = Random.Range(0.0f, 100.0f);

			if (p < l*100)
			{
				if (gm != null)
				{
					gm.EnterBattle(Rarity.Legendary);
				}
			}
			else if (p < vr*100)
			{
				if (gm != null)
				{
					gm.EnterBattle(Rarity.VeryRare);
				}
			}
			else if (p < r*100)
			{
				if (gm != null)
				{
					gm.EnterBattle(Rarity.Rare);
				}
			}
			else if (p < sr*100)
			{
				if (gm != null)
				{
					gm.EnterBattle(Rarity.SemiRare);
				}
			}
			else if (p < c*100)
			{
				if (gm != null)
				{
					gm.EnterBattle(Rarity.Common);
				}
			}
			else if (p < vc*100)
			{
				if (gm != null)
				{
					gm.EnterBattle(Rarity.VeryCommon);
				}
			}

		}
	}
}
