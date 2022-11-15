using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public delegate void FNotifyPlayerTurn(bool isPlayerTurn);
    public static event FNotifyPlayerTurn OnPlayerTurnChanges;

    public static Player instance;
    public Text Playertextturn;
    public Text InicioText;
    public int rounds = 100;
    public Text RoundText;

    public bool IsmyTurn;
    public bool TryToPlay()
    {
        if (IsmyTurn == false)
        {
            InicioText.enabled = true;
            RoundText.enabled = false;
            RoundText.text = rounds.ToString();


            Playertextturn.enabled = true;
            return false;
        }
        IsmyTurn = false;
        OnPlayerTurnChanges?.Invoke(false);
        return true;
    }
    private void Awake()
    {
        instance = this;
    }
    public void ResetPlayerTurn()
    {
        OnPlayerTurnChanges?.Invoke(false);
        IsmyTurn = true;
        Playertextturn.enabled = true;
    }
}
