using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class BattleManager : MonoBehaviour
{

	public BattleMenu currentMenu;

    public delegate void BattleResultEventHandler(int result);
    public event BattleResultEventHandler BattleResult;

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

    [Header("Defense")]
    public GameObject defenseStats;
    public Text defenseName;
    public Text defenseLevel;
    public GameObject defenseHealthLevel;
    public GameObject defenseHealthBar;

	[Header("Misc")] public int currentSelection;

    private float defenseHealth;
    private float defenseMaxHealth;

    private bool battleComplete;
    private int exitCode;

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
				int possibleSelection = currentSelection + 2;
                if (possibleSelection > 4)
                {
                    currentSelection = possibleSelection - 4;
                }
                else
                {
                    currentSelection = possibleSelection;
                }
			}
		}
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			if (currentSelection > 0)
			{
				int possibleSelection = currentSelection - 2;
                if (possibleSelection < 0)
                {
                    currentSelection = 4 + possibleSelection;
                }
                else
                {
                    currentSelection = possibleSelection;
                }
			}	
		}
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentSelection % 2 == 0)
            {
                currentSelection--;
            }
            else
            {
                currentSelection++;
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
                        moveO.text = "> " + moveOT;
						moveT.text = moveTT;
						moveTH.text = moveTHT;
						movef.text = movefT;
						break;
					case 2:
						moveO.text = moveOT;
						moveT.text = "> " + moveTT;
						moveTH.text = moveTHT;
						movef.text = movefT;
						break;
					case 3:
						moveO.text = moveOT;
						moveT.text = moveTT;
						moveTH.text = "> " + moveTHT;
						movef.text = movefT;
						break;
					case 4:
						moveO.text = moveOT;
						moveT.text = moveTT;
						moveTH.text = moveTHT;
						movef.text = "> " + movefT;
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
                        selectionInfoText.text = fightT;
						break;
					case 2:
						fight.text = fightT;
						bag.text = "> " + bagT;
						cryptid.text = cryptidT;
						run.text = runT;
                        selectionInfoText.text = bagT;
						break;
					case 3:
						fight.text = fightT;
						bag.text = bagT;
						cryptid.text = "> " + cryptidT;
						run.text = runT;
                        selectionInfoText.text = cryptidT;
						break;
					case 4:
						fight.text = fightT;
						bag.text = bagT;
						cryptid.text = cryptidT;
						run.text = "> " + runT;
                        selectionInfoText.text = runT;
						break;
				}
				break;
		}

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (battleComplete)
            {
                ExitBattle();
            }
            else
            {
                SelectMenuItem(currentMenu, currentSelection);
            }
        }
    }

    void ExitBattle()
    {
        BattleResult.Invoke(exitCode);
    }

    public void EnterBattle(List<BaseCryptid> playerCryptids, BaseCryptid battleCryptid)
    {
        ChangeMenu(BattleMenu.Selection);
        if (playerCryptids.Count == 0)
        {
            moveOT = "Punch";
            moveTT = "Kick";
            moveTHT = "Tackle";
            movefT = "Dodge";
        }

        defenseName.text = battleCryptid.name;
        Image health = defenseHealthBar.GetComponent<Image>();
        health.fillAmount = 1f;

        defenseMaxHealth = (float)battleCryptid.Hp;
        defenseHealth = defenseMaxHealth;

        battleComplete = false;
        exitCode = 0;
    }

    void SelectMenuItem(BattleMenu bm, int currentSelection)
    {
        switch (bm)
        {
            case BattleMenu.Fight:
                switch (currentSelection)
                {
                    case 1:
                        AttackDefender(5f);
                        break;
                    case 2:
                        AttackDefender(10f);
                        break;
                    case 3:
                        AttackDefender(15f);
                        break;
                    case 4:
                        break;
                }

                if (!battleComplete)
                {
                    ChangeMenu(BattleMenu.Selection);
                }
                break;
            case BattleMenu.Selection:

                switch (currentSelection)
                {
                    case 1:
                        ChangeMenu(BattleMenu.Fight);
                        break;
                    case 2:
                        ChangeMenu(BattleMenu.Bag);
                        break;
                    case 3:
                        ChangeMenu(BattleMenu.Cryptids);
                        break;
                    case 4:
                        exitCode = 0;
                        ExitBattle();
                        break;
                }
                break;
        }
    }

	void ChangeMenu(BattleMenu bm)
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

    void AttackDefender(float attackStrength)
    {
        defenseHealth -= attackStrength;
        float healthPercent = defenseHealth / defenseMaxHealth;

        Image health = defenseHealthBar.GetComponent<Image>();
        health.fillAmount = healthPercent;

        if (defenseHealth <= 0f)
        {
            DefenderCryptidDie();
        }
    }

    void DefenderCryptidDie()
    {
        ShowMessage(defenseName.text + " has been killed");
        exitCode = 2;
        battleComplete = true;
    }

    void ShowMessage(string message)
    {
        ChangeMenu(BattleMenu.Info);
        infoText.text = message;
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
