using UnityEngine;
using System.Collections;

public class PuzzlePlanet : MonoBehaviour {
	private float moveDistance = 3.12f;
	//3.0995
	private GameObject RoletPlanet1, RoletPlanet2, RoletPlanet3;
	private float indexNumber1 = 1, indexNumber2 = 7,indexNumber3 = 3;
	private Vector3 pos1, pos2, pos3;
	private float pos1Y, pos2Y, pos3Y;
	public bool solvedPlanet = false;
	public GameObject solved2;
	
	// Use this for initialization
	void Start () {
		RoletPlanet1 = GameObject.Find ("RoletPlanet1");
		pos1 = RoletPlanet1.transform.position;
		pos1Y = pos1.y;
		RoletPlanet2 = GameObject.Find ("RoletPlanet2");
		pos2 = RoletPlanet2.transform.position;
		pos2Y = pos2.y;
		RoletPlanet3 = GameObject.Find ("RoletPlanet3");
		pos3 = RoletPlanet3.transform.position;
		pos3Y = pos3.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && !solvedPlanet) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				if (hit.transform == GameObject.Find("UpPlanet1").transform) {
					if (indexNumber1 > 1) {
						pos1Y -= moveDistance;
						indexNumber1 -= 1;
					} else {
						pos1Y += 7 * moveDistance;
						indexNumber1 = 8;
					}
					
				} else if (hit.transform == GameObject.Find("DownPlanet1").transform) {
					if (indexNumber1 <= 7) {
						pos1Y += moveDistance;
						indexNumber1 += 1;
					} else {
						pos1Y -= 7 * moveDistance;
						indexNumber1 = 1;
					}
				} else if (hit.transform == GameObject.Find("UpPlanet2").transform) {
					if (indexNumber2 > 1) {
						pos2Y -= moveDistance;
						indexNumber2 -= 1;
					} else {
						pos2Y += 7 * moveDistance;
						indexNumber2 = 8;
					}
					
				} else if (hit.transform == GameObject.Find("DownPlanet2").transform) {
					if (indexNumber2 <= 7) {
						pos2Y += moveDistance;
						indexNumber2 += 1;
					} else {
						pos2Y -= 7 * moveDistance;
						indexNumber2 = 1;
					}
				} else if (hit.transform == GameObject.Find("UpPlanet3").transform) {
					if (indexNumber3 > 1) {
						pos3Y -= moveDistance;
						indexNumber3 -= 1;
					} else {
						pos3Y += 7 * moveDistance;
						indexNumber3 = 8;
					}
				} else if (hit.transform == GameObject.Find("DownPlanet3").transform) {
					if (indexNumber3 <= 7) {
						pos3Y += moveDistance;
						indexNumber3 += 1;
					} else {
						pos3Y -= 7 * moveDistance;
						indexNumber3 = 1;
					}
				} 
			}
			//misal passwordnya 0
		}
		if ( (indexNumber1 == 8) && (indexNumber2 == 1) && (indexNumber3 == 5) ) {
			solvedPlanet = true;
			//pindahScene();
		}
		// Moving numbers
		pos1.y = Mathf.Lerp (pos1.y, pos1Y, Time.deltaTime * 750f);
		RoletPlanet1.transform.position = pos1;
		pos2.y = Mathf.Lerp (pos2.y, pos2Y, Time.deltaTime * 750f);
		RoletPlanet2.transform.position = pos2;
		pos3.y = Mathf.Lerp (pos3.y, pos3Y, Time.deltaTime * 750f);
		RoletPlanet3.transform.position = pos3;
	}
	
	void pindahScene() {
		//animasi dll bisa ditambahin disini
		
		// 1 itu scene menu.unity, liat di build setting
		
		StartCoroutine (StartPindah());
	}
	
	IEnumerator StartPindah(){
		
		yield return new WaitForSeconds(5F);
		Application.LoadLevel (0);
		
	}
}





