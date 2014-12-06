using UnityEngine;
using System.Collections;

public class NavAnimation : MonoBehaviour {

	public AnimationClip idle;
	public AnimationClip run;
	
	private Animation anim;
	private NavMeshAgent navMeshAgent;
	
	void Awake() {
		anim = GetComponentInChildren<Animation>();
		navMeshAgent = GetComponentInChildren<NavMeshAgent>();
		if (anim == null || idle == null || run == null || navMeshAgent == null) {
			enabled = false;
		}
	}
	
	void Update() {
		if (navMeshAgent.velocity.magnitude < 0.1f) {
			anim.CrossFade(idle.name);
		} else {
			anim.CrossFade(run.name);
		}
	}
}
