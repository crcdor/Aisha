using UnityEngine;
using System.Collections;

public class PuzzleAngka : MonoBehaviour {
	private float moveDistance = 2.05f;
	private GameObject RoletAngka1, RoletAngka2, RoletAngka3, RoletAngka4;
	private float indexNumber1 = 1, indexNumber2 = 2,indexNumber3 = 3, indexNumber4 = 4;
	private Vector3 pos1, pos2, pos3, pos4;
	private float pos1Y, pos2Y, pos3Y, pos4Y;
	private bool solvedAngka = false;
	
	// Use this for initialization
	void Start () {
		RoletAngka1 = GameObject.Find ("RoletAngka1");
		pos1 = RoletAngka1.transform.position;
		pos1Y = pos1.y;
		RoletAngka2 = GameObject.Find ("RoletAngka2");
		pos2 = RoletAngka2.transform.position;
		pos2Y = pos2.y;
		RoletAngka3 = GameObject.Find ("RoletAngka3");
		pos3 = RoletAngka3.transform.position;
		pos3Y = pos3.y;
		RoletAngka4 = GameObject.Find ("RoletAngka4");
		pos4 = RoletAngka4.transform.position;
		pos4Y = pos4.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && !solvedAngka) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				if (hit.transform == GameObject.Find("UpAngka1").transform) {
					if (indexNumber1 > 1) {
						pos1Y -= moveDistance;
						indexNumber1 -= 1;
					} else {
						pos1Y += 9 * moveDistance;
						indexNumber1 = 10;
					}
					
				} else if (hit.transform == GameObject.Find("DownAngka1").transform) {
					if (indexNumber1 <= 9) {
						pos1Y += moveDistance;
						indexNumber1 += 1;
					} else {
						pos1Y -= 9 * moveDistance;
						indexNumber1 = 1;
					}
				} else if (hit.transform == GameObject.Find("UpAngka2").transform) {
					if (indexNumber2 > 1) {
						pos2Y -= moveDistance;
						indexNumber2 -= 1;
					} else {
						pos2Y += 9 * moveDistance;
						indexNumber2 = 10;
					}
					
				} else if (hit.transform == GameObject.Find("DownAngka2").transform) {
					if (indexNumber2 <= 9) {
						pos2Y += moveDistance;
						indexNumber2 += 1;
					} else {
						pos2Y -= 9 * moveDistance;
						indexNumber2 = 1;
					}
				} else if (hit.transform == GameObject.Find("UpAngka3").transform) {
					if (indexNumber3 > 1) {
						pos3Y -= moveDistance;
						indexNumber3 -= 1;
					} else {
						pos3Y += 9 * moveDistance;
						indexNumber3 = 10;
					}
				} else if (hit.transform == GameObject.Find("DownAngka3").transform) {
					if (indexNumber3 <= 9) {
						pos3Y += moveDistance;
						indexNumber3 += 1;
					} else {
						pos3Y -= 9 * moveDistance;
						indexNumber3 = 1;
					}
				} else if (hit.transform == GameObject.Find("UpAngka4").transform) {
					if (indexNumber4 > 1) {
						pos4Y -= moveDistance;
						indexNumber4 -= 1;
					} else {
						pos4Y += 9 * moveDistance;
						indexNumber4 = 10;
					}
					
				} else if (hit.transform == GameObject.Find("DownAngka4").transform) {
					if (indexNumber4 <= 9) {
						pos4Y += moveDistance;
						indexNumber4 += 1;
					} else {
						pos4Y -= 9 * moveDistance;
						indexNumber4 = 1;
					}
				}
			}
			//misal passwordnya 0
		}
		if ( (indexNumber1 == 1) && (indexNumber2 == 10) && (indexNumber3 == 4) && (indexNumber4 == 5) ) {
			solvedAngka = true;
			pindahScene();
		}
		// Moving numbers
		pos1.y = Mathf.Lerp (pos1.y, pos1Y, Time.deltaTime * 750f);
		RoletAngka1.transform.position = pos1;
		pos2.y = Mathf.Lerp (pos2.y, pos2Y, Time.deltaTime * 750f);
		RoletAngka2.transform.position = pos2;
		pos3.y = Mathf.Lerp (pos3.y, pos3Y, Time.deltaTime * 750f);
		RoletAngka3.transform.position = pos3;
		pos4.y = Mathf.Lerp (pos4.y, pos4Y, Time.deltaTime * 750f);
		RoletAngka4.transform.position = pos4;
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





