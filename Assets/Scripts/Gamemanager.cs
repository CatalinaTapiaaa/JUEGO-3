using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;
    public List<Enemy> enemies;
    public int Enemyturn;
    public Text EnemyTurnText;


    public void AddToListEnemy(Enemy enemytoPast)
    {
        enemies.Add(enemytoPast);
    }

    public void EnemyTurnFinish(Enemy enemy)
    {
        Enemyturn++;
        if (Enemyturn < enemies.Count)
        {
            CallEnemyturn();
            EnemyTurnText.enabled = true;
            Player.instance.Playertextturn.enabled = false;
            Player.instance.RoundText.enabled = false;
            Player.instance.InicioText.enabled = false;
        }
        else
        {

            Player.instance.ResetPlayerTurn();
            EnemyTurnText.enabled = false;
            Player.instance.Playertextturn.enabled = true;

            Player.instance.RoundText.text = Player.instance.rounds.ToString();
            Player.instance.InicioText.enabled = false;
        }
    }
    public void Start()
    {
        Player.instance.ResetPlayerTurn();

    }

    public void ChangeTurn(int Playerturn, int enemyturn)
    {

    }
    public void PlayerTurnFinish()
    {
        Enemyturn = 0;
        
        EnemyTurnText.enabled = true;
        Player.instance.Playertextturn.enabled = false;

        Player.instance.RoundText.text = Player.instance.rounds.ToString();
        Player.instance.InicioText.enabled = false;
    }
    public void CallEnemyturn()
    {
        enemies[Enemyturn].DoEnemyAction();
        EnemyTurnText.enabled = true;
        Player.instance.RoundText.enabled = true;
        Player.instance.InicioText.enabled = false;
    }
}
