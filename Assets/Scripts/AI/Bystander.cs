using UnityEngine;
using System.Collections;

public class Bystander : MonoBehaviour {

	public Collider trigger;
	
	private Chaser chaser;
	
	void Awake() {
		chaser = GetComponent<Chaser>();
		if (chaser == null) enabled = false;
		if (trigger != null) trigger.enabled = false;
	}
	
	void OnEnable() {
		if (trigger != null) trigger.enabled = true;
	}
	
	void OnDisable() {
		if (trigger != null) trigger.enabled = false;
	}
	
	void Start() {
		this.enabled = !chaser.enabled;
	}

	void OnTriggerEnter(Collider other) {
		if (!enabled) return;
		if (other.gameObject == this.gameObject) return;
		if (other.CompareTag("Chaser")) {
			var otherChaser = other.GetComponent<Chaser>();
			var isOtherChasing = (otherChaser != null) && otherChaser.enabled;
			if (isOtherChasing) {
				chaser.enabled = true;
				enabled = false;
			}
		}
	}	
}
