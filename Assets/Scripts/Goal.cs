using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Collider))]
public class Goal : MonoBehaviour
{

	public string tagToCompare = "Ball";
	[SerializeField]
	private ScoreDatabase teamScore;
	private Collider collider;

	private void Start ()
	{
		collider = GetComponent<Collider> ();
		SetUpCollider ();
	}

	private void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag (tagToCompare)) {
			teamScore.Earn ();
		}
	}

	private void SetUpCollider ()
	{
		collider.isTrigger = true;
	}
}
