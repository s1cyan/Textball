using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Square
{
    public bool occupied = false;
}

[System.Serializable]
public class Row
{
    public List<Square> row = new List<Square>();
}


public class PlayMatrix : MonoBehaviour {
    public int length = 8;
    public int width = 4;

    
    private List<Row> playMatrix = new List<Row>();

    void OnEnable()
    {
        for(int i = 0; i < width; i++)
        {
            Row row = new Row();
            for (int j = 0; j < length; j++)
            {
                var occupied = new Square();
                row.row.Add(occupied);
            }
            playMatrix.Add(row);
        }
    }
    
	// Use this for initialization
	void Start () {
        

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
