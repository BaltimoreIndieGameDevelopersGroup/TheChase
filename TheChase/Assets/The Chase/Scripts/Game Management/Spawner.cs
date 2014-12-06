using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject source;
	public int count = 10;
	public float range = 30;
		
	void Start () {
		if (source == null) return;
		for (int i = 0; i < count; i++) {
			var spawn = Instantiate(source) as GameObject;
			var position = new Vector3(transform.position.x + Random.Range(-range, range),
									   transform.position.y,
									   transform.position.z + Random.Range(-range, range));
			spawn.transform.position = position;
			spawn.transform.SetParent(transform);
		}
	}
	
}
