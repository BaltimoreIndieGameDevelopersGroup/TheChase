using UnityEngine;
using System.Collections;

public class Chaser : MonoBehaviour {


	public Collider trigger;
	public Transform target;
	
	private NavMeshAgent navMeshAgent;
	private bool started = false;
	
	void Awake() {
		navMeshAgent = GetComponent<NavMeshAgent>();
		if (trigger != null) trigger.enabled = enabled;
	}
	
	void Start() {
		started = true;
		ChasePlayer();
	}
	
	void OnEnable() {
		if (trigger != null) trigger.enabled = true;
		ChasePlayer();
	}
	
	void OnDisable() {
		if (trigger != null) trigger.enabled = false;
	}
	
	public void ChasePlayer() {
		if (!started) return;
		Chase(GameObject.FindGameObjectWithTag("player").transform);
	}
	
	public void Chase(Transform target) {
		this.target = target;
	}
	
	void Update() {
		if (navMeshAgent == null) return;
		if (target == null) {
			navMeshAgent.Stop();
		} else {
			navMeshAgent.SetDestination(target.position);
		}
	}

	void OnTriggerEnter(Collider other) {
		if (!enabled) return;
		if (other.CompareTag("Player")) {
			GameManager.GameOver();
		}
	}	
	
}
