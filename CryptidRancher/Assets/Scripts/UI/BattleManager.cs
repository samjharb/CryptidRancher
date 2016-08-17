using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{

	public BattleMenu currentMenu;

	[Header("Selection")] 
	public GameObject SelectionMenu;
	public GameObject SelectionInfo;
	public Text selectionInfoText;
	public Text fight;
	public Text bag;
	public Text cryptid;
	public Text run;

	private string runT;
	private string cryptidT;
	private string bagT;
	private string fightT;

	[Header("Moves")]
	public GameObject movesMenu;
	public GameObject movesDetails;
	public Text pp;
	public Text cType;
	public Text moveO;
	public Text moveT;
	public Text moveTH;
	public Text movef;


	private string moveOT;
	private string moveTT;
	private string moveTHT;
	private string movefT;

	[Header("Info")]
	public GameObject infoMenu;
	public Text infoText;

	[Header("Misc")] public int currentSelection;
	

	// Use this for initialization
	void Start ()
	{
		fightT = fight.text;
		bagT = bag.text;
		cryptidT = cryptid.text;
		runT = run.text;
		moveOT = moveO.text;
		moveTT = moveT.text;
		moveTHT = moveTH.text;
		movefT = movef.text;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			if (currentSelection < 4)
			{
				currentSelection++;
			}
		}
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			if (currentSelection > 0)
			{
				currentSelection--;
			}	
		}

		if (currentSelection == 0)
		{
			currentSelection = 1;
		}

		switch (currentMenu)
		{
			case BattleMenu.Fight:
				switch (currentSelection)
				{
					case 1:
								moveO.text = "> " + moveO.text;
								moveT.text = moveT.text;
								moveTH.text = moveTH.text;
								movef.text = movef.text;

						break;
						case 2:
								moveO.text = moveO.text;
								moveT.text = "> " + moveT.text;
								moveTH.text = moveTH.text;
								movef.text = movef.text;
						break;
					case 3:
								moveO.text = moveO.text;
								moveT.text = moveT.text;
								moveTH.text = "> " + moveTH.text;
								movef.text = movef.text;
						break;
					case 4:
								moveO.text = moveO.text;
								moveT.text = moveT.text;
								moveTH.text = moveTH.text;
								movef.text = "> " + movef.text;
						break;
				}
				break;
			case BattleMenu.Selection:

				switch (currentSelection)
				{
					case 1:
						fight.text = "> " + fightT;
						bag.text = bagT;
						cryptid.text = cryptidT;
						run.text = runT;

						break;
					case 2:
						fight.text = fightT;
						bag.text = "> " + bagT;
						cryptid.text = cryptidT;
						run.text = runT;
						break;
					case 3:
						fight.text = fightT;
						bag.text = bagT;
						cryptid.text = "> " + cryptidT;
						run.text = runT;
						break;
					case 4:
						fight.text = fightT;
						bag.text = bagT;
						cryptid.text = cryptidT;
						run.text = "> " + runT;
						break;
				}
				break;
		}
		


	}

	public void ChangeMenu(BattleMenu bm)
	{
		currentMenu = bm;
		currentSelection = 1;
		switch (bm)
		{
				case BattleMenu.Selection:
					SelectionMenu.gameObject.SetActive(true);
					SelectionInfo.gameObject.SetActive(true);
					movesMenu.gameObject.SetActive(false);
					movesMenu.gameObject.SetActive(false);
					infoMenu.gameObject.SetActive(false);
				break;
				case BattleMenu.Fight:
					SelectionMenu.gameObject.SetActive(false);
					SelectionInfo.gameObject.SetActive(false);
					movesMenu.gameObject.SetActive(true);
					movesMenu.gameObject.SetActive(true);
					infoMenu.gameObject.SetActive(false);
				break;
				case BattleMenu.Info:
					SelectionMenu.gameObject.SetActive(false);
					SelectionInfo.gameObject.SetActive(false);
					movesMenu.gameObject.SetActive(false);
					movesMenu.gameObject.SetActive(false);
					infoMenu.gameObject.SetActive(true);
				break;
				//case BattleMenu.Cryptids:
				//break;
		}

	}
}

public enum BattleMenu
{
	Selection,
	Cryptids,
	Bag,
	Fight,
	Info
}
