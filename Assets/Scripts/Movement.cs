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

    private void Start()
    {
        if (jsonData != null)
        {
            //playerWrapper = JsonUtility.FromJson<PlayerWrapper>(jsonData.text);
            UpdateWrapper();
            Debug.LogWarningFormat("{0}", playerWrapper.players[0].x0);
        }
    }

    private void UpdateWrapper()
    {
        playerWrapper = JsonUtility.FromJson<PlayerWrapper>(jsonData.text);
    }

    private IEnumerator MovementUpdater()
    {
        yield return new WaitForSeconds(1f);
        UpdateWrapper();
        
    }
}

