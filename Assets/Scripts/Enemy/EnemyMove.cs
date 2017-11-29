using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour {
	
	Transform player;
	NavMeshAgent nav;

	void Awake () {
        // Debug.Log("EnemyMove.Awake()");
		
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent <NavMeshAgent> ();

	}
	
	void Update () {
		if(nav.enabled){
			nav.SetDestination (player.position);
		}
	}

}
