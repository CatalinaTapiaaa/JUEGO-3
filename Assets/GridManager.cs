using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int rowa = 3;
    public int columns = 3;
    public GameObject GridPrefab;
    public Vector3 LeftButtom = new Vector3(0, 0, 0);
    public float scale;
    public GameObject[,] gridArray;


    
    // Start is called before the first frame update
    void Start()
    {
        GeneratorGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GeneratorGrid()
    {
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rowa; j++)
            {
                GameObject obj = Instantiate(GridPrefab);
                obj.transform.position = new Vector3(0 + scale*i, 0+scale*j, 0);

                obj.transform.SetParent(gameObject.transform);
                
               


                

            }
        }
    }
}
