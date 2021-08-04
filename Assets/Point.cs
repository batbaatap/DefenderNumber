using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour {

	public GameObject Gun1;
	public GameObject Gun2;
	public GameObject Gun3;

	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position == Gun1.transform.position)
		{
			gameObject.tag = "okay";
		}else
		if(transform.position == Gun2.transform.position)
		{
			gameObject.tag = "okay";
		}else 
		if(transform.position == Gun3.transform.position)
		{
			gameObject.tag = "okay";
		}else
		{
			gameObject.tag = "findme";
		}		
	}

}
