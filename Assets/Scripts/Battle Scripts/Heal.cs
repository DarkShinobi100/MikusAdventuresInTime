using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Heal : MonoBehaviour
{

    [SerializeField]
    private float HP;
    private new AudioSource audio;
    // Use this for initialization
    void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(() => addCallback());
        audio = this.gameObject.GetComponent<AudioSource>();
    }

    private void addCallback()
    {
        //find the turn system
        GameObject turnSystem = GameObject.Find("TurnSystem");
        //get the current player
        GameObject currentPlayer = turnSystem.GetComponent<TurnSystem1>().GetCurrentPlayer();
        //heal that player
        currentPlayer.GetComponent<UnitStats>().health +=(currentPlayer.GetComponent<UnitStats>().maxHealth /100) * HP;
        currentPlayer.GetComponent<UnitStatFunctions>().health += (currentPlayer.GetComponent<UnitStats>().maxHealth / 100) * HP;

        //if health is greater than 100 cap at 100
        if (currentPlayer.GetComponent<UnitStats>().health >= currentPlayer.GetComponent<UnitStats>().maxHealth)
        {
            currentPlayer.GetComponent<UnitStats>().health = currentPlayer.GetComponent<UnitStats>().maxHealth;
            currentPlayer.GetComponent<UnitStatFunctions>().health = currentPlayer.GetComponent<UnitStats>().maxHealth;
        }
        // play heal SFX
        if(audio != null)
        {
            audio.Play();
        }

        GameObject.Find("PlayerParty").GetComponent<SelectUnit>().setMenus();
        currentPlayer.GetComponent<PlayerUnitAction>().updateHUD();

        //next turn
       // turnSystem.GetComponent<TurnSystem1>().IncreaseTurn();
        GameObject.Find("TurnSystem").GetComponent<TurnSystem1>().nextTurn();
    }

}
