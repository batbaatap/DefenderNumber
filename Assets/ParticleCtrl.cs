using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCtrl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// GetComponent<ParticleSystem>().startColor = new Color(1, 0, 1, .5f);
		// ParticleSystem.startColor = Color.red; 
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine(Destroyer());
	}

	IEnumerator Destroyer(){
		yield return new WaitForSeconds(.2f);
		Destroy(this.gameObject);
	}
}
