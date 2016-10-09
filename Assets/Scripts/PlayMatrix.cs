using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Cell
{
    public Vector3 pos;
    public bool isOccupied = false;
}

public class PlayMatrix : MonoBehaviour {
    public int length = 20;
    public int width = 6;

    public Transform player;

    private int x = 2;
    private int x2 = 18;
    private int z= 1;
    private Cell[,] playMatrix;

    public Cell[,] PlayField { get { return playMatrix; } }

    void OnEnable()
    {
        playMatrix = new Cell[length, width];
        SetUpMatrix();
        PlacePlayers();

    }

    private void SetUpMatrix()
    {
        for(int i= 0; i < length; i ++)
        {
            for (int j = 0; j< width; j++)
            {
                playMatrix[i, j] = new Cell();
            }
        }
    }

    private void PlacePlayers()
    {
        for (int i = 0; i < 4; i++)
        {
            var p = Instantiate(player);
            p.transform.position = new Vector3(x, .5f, z);
            playMatrix[x,z].isOccupied = true;
            var p2 = Instantiate(player);
            p2.transform.position = new Vector3(x2, .5f, z);
            playMatrix[x2, z].isOccupied = true;
            z += 1;
        }
       //for(int i = 0; i < length; i++)
       // {
       //    for(int j = 0; j < width; j++)
       //     {
       //         Debug.LogFormat (" {0}, {1}, {2}", i,j,playMatrix[i, j].isOccupied);
       //     }
       // }
    }
       

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
