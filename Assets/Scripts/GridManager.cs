using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int rowa = 10;
    public int columns = 10;
    public GameObject GridPrefab;
    public Vector3 LeftButtom = new Vector3(0, 0, 0);
    public float scale;
    public GameObject[,] gridArray;
    public List<GameObject> players, enemies;
    public List<Vector2Int> playerPos, enemiesPos;
    public Vector3 posicion;
    private GameObject PlayerPrefab;
    private GameObject indicator;
    public bool eligio = false;


    private void OnDisable()
    {
        Player.OnPlayerTurnChanges -= Player_onPLayerTurnChanges;
    }

    private void OnEnable()
    {
        Player.OnPlayerTurnChanges += Player_onPLayerTurnChanges;
    }
    private void Player_onPLayerTurnChanges(bool isPlayerturn)
    {
        indicator?.SetActive(isPlayerturn);
    }
    public void OnMouseDown()
    {
        if (eligio == false)
        {
            if (Player.instance.TryToPlay())
            {
                Instantiate(PlayerPrefab, posicion, transform.rotation);
                Gamemanager.instance.PlayerTurnFinish();
            }
        }
    }
    public void ConsumeResources(bool consumebyPlayer)
    {
        GetComponent<SpriteRenderer>().material.color = consumebyPlayer == true ? Color.blue : Color.red;
        eligio = true;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        GeneratorGrid();
        playerPos = new List<Vector2Int>();
        enemiesPos = new List<Vector2Int>();
        for (int i = 0; i < players.Count; i++)
        {
            playerPos.Add(Vector2Int.zero);
        }
        for (int i = 0; i < enemies.Count; i++)
        {
            enemiesPos.Add(Vector2Int.zero);
        }

        playerPos[0] = Place(players[0], 0,0, false, Vector2Int.zero);
        enemiesPos[0] = Place(enemies[0],0,1, false, Vector2Int.zero);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GeneratorGrid()
    {
        gridArray = new GameObject[columns, rowa];
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rowa; j++)
            {
                GameObject obj = Instantiate(GridPrefab);
                obj.transform.position = new Vector3(0 + scale*i, 0+scale*j, 0);
                GridStat gs = obj.GetComponent<GridStat>();
                gs.x = i;
                gs.y = j;
                obj.transform.SetParent(gameObject.transform);
                gridArray[i, j] = obj;
            }
        }
    }

    Vector2Int Place(GameObject pawn, int x, int y, bool lastP, Vector2Int lPos)
    {
        if (lastP)
        {
            gridArray[lPos.x, lPos.y].GetComponent<GridStat>().visited = -1;
        }
        pawn.transform.position = new Vector3(gridArray[x, y].transform.position.x, gridArray[x, y].transform.position.y, 1);
        gridArray[x, y].GetComponent<GridStat>().visited = 1;

        return new Vector2Int(x,y);
    }
}
