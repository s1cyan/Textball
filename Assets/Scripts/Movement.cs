using UnityEngine;
using System;
using System.Collections;

[Serializable]
public struct Players
{
    public string x0;
    public string x1;
    public string x2;
    public string x3;
    public string x4;
    public string x5;
    public string x6;
    public string x7;

}

[Serializable]
public class PlayerWrapper
{
    public Players[] players;
}

public class Movement : MonoBehaviour
{
    public TextAsset jsonData;
    private PlayerWrapper playerWrapper;
    private GameObject[] players;
    public PlayMatrix playMatrix;
    private bool isPlaying = true;
    
    private void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        playMatrix = FindObjectOfType<PlayMatrix>();
        if (jsonData != null)
        {
            UpdateWrapper();
            Debug.LogWarningFormat("{0}", playerWrapper.players[0].x0);
        }
        StartCoroutine(MovementUpdater());
    }

    private void UpdateWrapper()
    { 
        playerWrapper = JsonUtility.FromJson<PlayerWrapper>(jsonData.text);
    }

    private void MovePlayer(int i, string s)
    {
        var deltaVect = ParseInput(s, players[i].transform.position);
        var currentLocation = players[i].transform.position;
        var goalLocation = currentLocation + deltaVect;
        if (playMatrix.PlayField[(int)goalLocation.x, (int)goalLocation.z].isOccupied == false) {

            playMatrix.PlayField[(int)currentLocation.x, (int)currentLocation.z].isOccupied = false;
            playMatrix.PlayField[(int)goalLocation.x, (int)goalLocation.z].isOccupied = true;
            players[i].transform.position = Vector3.MoveTowards(currentLocation, goalLocation, 1.0f);

        }
      
    }

    private Vector3 ParseInput(string s, Vector3 position)
    {
        var x = 0f;
        var z = 0f;
        switch (s)
        {
            case ("w"):
                z += 1f;
                break;
            case ("a"):
                x -= 1f;
                break;
            case ("s"):
                z -= 1;
                break;
            case ("d"):
                x += 1;
                break;
            case ("stop"):
                //nothing
                break;
        }
        Vector3 deltaVect = new Vector3(x, .5f, z);
        return deltaVect;
        
    }

    private IEnumerator MovementUpdater()
    {
        while (isPlaying)
        {
            yield return new WaitForSeconds(1f);
            UpdateWrapper();
            var p = playerWrapper.players[0];
            MovePlayer(0, p.x0);
            MovePlayer(1, p.x1);
            MovePlayer(2, p.x2);
            MovePlayer(3, p.x3);
            MovePlayer(4, p.x4);
            MovePlayer(5, p.x5);
            MovePlayer(6, p.x6);
            MovePlayer(7, p.x7);

        }

    }
}

