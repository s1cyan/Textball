using UnityEngine;
using System.Collections;

[CreateAssetMenu (fileName = "Score Database", menuName = "Scriptable Objects/Score Database")]
public class ScoreDatabase : ScriptableObject
{
	[SerializeField]
	private int score = 0;

	public void Earn ()
	{
		score += 1;
	}

	public void Lose ()
	{
		score -= 1;
	}
}
