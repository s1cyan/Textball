using UnityEngine;
using System.Collections;

public class JSONLoad : MonoBehaviour
{
	[System.Serializable]
	public class PlayerWrapper
	{
		public Players[] players;
	}

	[System.Serializable]
	public struct Players
	{
		public string x0;
		public string x1;
	}

	public TextAsset jsonData;
	private PlayerWrapper playerWrapper;

	// Use this for initialization
	void Start ()
	{
		if (jsonData != null) {
			playerWrapper = JsonUtility.FromJson<PlayerWrapper> (jsonData.text);
			Debug.LogFormat ("{0}", playerWrapper.players [0].x0);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
