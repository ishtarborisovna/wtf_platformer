using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour
{

	void OnTriggerEnter2D(Collider2D tr)
	{
		if (tr.transform.CompareTag("Player"))
		{
			HarryControl.playerPosition = tr.transform.position;
		}
	}
}