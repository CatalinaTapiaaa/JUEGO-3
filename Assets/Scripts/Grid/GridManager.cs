using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public bool selected = false;
    private Dictionary<Vector2Int, GameObject> Jugadores = new Dictionary<Vector2Int, GameObject>(); 
    public GameObject Playerprefab;
    public int fase = 0;// 0 jugador, 1 enemigo
    public Material materialCubo;
    public Material ColorMov;
    public Material otroColor;
    public GameObject selectedObject;
    public Vector3 posicion;
    public Player currentP;
    public Color enemyColor;
    public GameObject lastElement;
    public Color lastElementColor;
    public Text textoPlayer;




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

        playerPos[0] = Place(players[0], 0, 0, false, Vector2Int.zero);
        enemiesPos[0] = Place(enemies[0], 0, 1, false, Vector2Int.zero);
        textoPlayer.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        OnMouseDown();
        TurnPlayer();
        
    }
    
    void GeneratorGrid()
        {
            gridArray = new GameObject[columns, rowa];
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rowa; j++)
                {
                    GameObject obj = Instantiate(GridPrefab);
                    obj.transform.position = new Vector3(0 + scale * i, 0 + scale * j, 0);
                    GridStat gs = obj.GetComponent<GridStat>();
                    gs.x = i;
                    gs.y = j;
                obj.transform.tag = "Grilla";
                obj.name = "G[" + i + "," + j + "]";
                    obj.transform.SetParent(gameObject.transform);
                    gridArray[i, j] = obj;
                    //materialCubo.color = Color.blue;
                }
            }
        }

    Vector2Int Place(GameObject pawn, int x, int y, bool lastP, Vector2Int lPos)
        {
            if (lastP)
            {
                gridArray[lPos.x, lPos.y].GetComponent<GridStat>().visited = -1;
                Jugadores.Remove(lPos);
                Debug.Log(playerPos);
            }
            pawn.transform.position = new Vector3(gridArray[x, y].transform.position.x, gridArray[x, y].transform.position.y, 1);
            gridArray[x, y].GetComponent<GridStat>().visited = 1;
            Jugadores[new Vector2Int(x, y)] = pawn;
            pawn.GetComponent<Player>().PosX = x;
            pawn.GetComponent<Player>().PosY = y;

            return new Vector2Int(x, y);
    }


    void OnMouseDown()
    {
        Ray ray;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 worldPosition = Vector3.zero;
        RaycastHit hitData;
        if (Physics.Raycast(ray, out hitData, 1000))
        {
            worldPosition = hitData.point;
            if(hitData.transform.tag == "Grilla")
            {
                if(lastElement != null)
                {
                    if (hitData.transform.gameObject.GetInstanceID() != lastElement.GetInstanceID())
                    {
                        Color currentColor = hitData.transform.GetComponent<SpriteRenderer>().color;


                        hitData.transform.GetComponent<SpriteRenderer>().color = Color.blue;
                        lastElement.transform.GetComponent<SpriteRenderer>().color = lastElementColor;
                        lastElement = hitData.transform.gameObject;
                        lastElementColor = currentColor;
                        textoPlayer.enabled = false;
                    }
                }
                else
                {
                    Color currentColor = hitData.transform.GetComponent<SpriteRenderer>().color;

                    hitData.transform.GetComponent<SpriteRenderer>().color = Color.blue;
                    lastElement = hitData.transform.gameObject;
                    lastElementColor = currentColor;
                }
                
                
            }
            
        }
    }
    void TurnPlayer()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 worldPosition = Vector3.zero;
            RaycastHit hitData;
            if (Physics.Raycast(ray, out hitData, 1000))
            {
                worldPosition = hitData.point;
                if (hitData.transform.tag == "Grilla")
                {
                    GridStat gs = hitData.transform.GetComponent<GridStat>();
                    if (gs.visited != -1)
                    {
                        CheckPlayerMovement(gs);
                    }
                    else
                    {
                        if (gs.aviableMove)
                        {
                            Place(currentP.gameObject, gs.x, gs.y, true, new Vector2Int(currentP.PosX, currentP.PosY));
                            RefreshGrid();
                        }
                    }
                }
            }
        }
    }

    public void CheckPlayerMovement(GridStat gs)
    {
        
        if (fase == Jugadores[new Vector2Int(gs.x, gs.y)].GetComponent<Player>().fase && Jugadores[new Vector2Int(gs.x, gs.y)].GetComponent<Player>().finished == false)
        {
            RefreshGrid();
            List<Vector2Int> moves = Jugadores[new Vector2Int(gs.x, gs.y)].GetComponent<Player>().Move;
            for (int i = 0; i < moves.Count; i++)
            {

                if ((moves[i].x + gs.x) >= 0 && (moves[i].x + gs.x) < rowa &&
                    (moves[i].y + gs.y) >= 0 && (moves[i].y + gs.y) < columns &&
                        gridArray[(moves[i].x + gs.x), (moves[i].y + gs.y)].GetComponent<GridStat>().visited == -1)
                {
                    Debug.Log((moves[i].x + gs.x) + " " + (moves[i].y + gs.y));
                    gridArray[(moves[i].x + gs.x), (moves[i].y + gs.y)].GetComponent<SpriteRenderer>().color = Color.yellow;
                    gridArray[(moves[i].x + gs.x), (moves[i].y + gs.y)].GetComponent<GridStat>().aviableMove = true;
                    
                    

                }
                currentP = Jugadores[new Vector2Int(gs.x, gs.y)].GetComponent<Player>();
            }
        }
        Debug.Log(Jugadores[new Vector2Int(gs.x, gs.y)].transform.name);
    }

    public void RefreshGrid()
    {
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rowa; j++)
            {
                gridArray[i, j].GetComponent<SpriteRenderer>().color = Color.white;
                gridArray[i, j].GetComponent<GridStat>().aviableMove = false;
               

                
            }
        }
    }

 
   

    private void OnDrawGizmosSelected()
    {
    }
}
