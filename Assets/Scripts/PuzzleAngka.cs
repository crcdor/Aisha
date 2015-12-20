using UnityEngine;
using System.Collections;

public class PuzzleAngka : MonoBehaviour {
	//private float moveDistance= 2.05f;
	private GameObject RoletAngka1, RoletAngka2, RoletAngka3, RoletAngka4;
	private int indexNumber1 = 0, indexNumber2 = 0,indexNumber3 = 0, indexNumber4 = 0;
	private Vector3 pos1, pos2, pos3, pos4;
	private float pos1Y, pos2Y, pos3Y, pos4Y;
	private bool solvedAngka = false;
	private float[] SimPos = new float[11] {-11.34f,-9.12f,-6.53f,-4.05f,-1.75f,0.73f,3.09f,5.68f,8.01f,10.26f,12.69f};
	
	// Use this for initialization
	void Start () {
		RoletAngka1 = GameObject.Find ("RoletAngka1");
		pos1 = RoletAngka1.transform.localPosition;
		pos1Y = pos1.y;
		RoletAngka2 = GameObject.Find ("RoletAngka2");
		pos2 = RoletAngka2.transform.localPosition;
		pos2Y = pos2.y;
		RoletAngka3 = GameObject.Find ("RoletAngka3");
		pos3 = RoletAngka3.transform.localPosition;
		pos3Y = pos3.y;
		RoletAngka4 = GameObject.Find ("RoletAngka4");
		pos4 = RoletAngka4.transform.localPosition;
		pos4Y = pos4.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && !solvedAngka) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				if (hit.transform == GameObject.Find("UpAngka1").transform) {
					if (indexNumber1 > 0) 
						indexNumber1 -= 1;
					else {
						pos1 = new Vector3 (-1.66f,12.69f,2f);
						indexNumber1 = 9;
					}
					pos1Y = SimPos[indexNumber1];
				} else if (hit.transform == GameObject.Find("DownAngka1").transform) {
					if (indexNumber1 <= 9)
						indexNumber1 += 1;
					else {
						pos1 = new Vector3 (-1.66f, -11.34f, 2f);
						indexNumber1 = 1;
					}
					pos1Y = SimPos[indexNumber1];
				} else if (hit.transform == GameObject.Find("UpAngka2").transform) {
					if (indexNumber2 > 0) 
						indexNumber2 -= 1;
					else {
						pos2 = new Vector3 (1.15f,12.69f,2f);
						indexNumber2 = 9;
					}
					pos2Y = SimPos[indexNumber2];
				} else if (hit.transform == GameObject.Find("DownAngka2").transform) {
					if (indexNumber2 <= 9)
						indexNumber2 += 1;
					else {
						pos2 = new Vector3 (1.15f, -11.34f, 2f);
						indexNumber2 = 1;
					}
					pos2Y = SimPos[indexNumber2];
				} else if (hit.transform == GameObject.Find("UpAngka3").transform) {
					if (indexNumber3 > 0) 
						indexNumber3 -= 1;
					else {
						pos3 = new Vector3 (3.97f,12.69f,2f);
						indexNumber3 = 9;
					}
					pos3Y = SimPos[indexNumber3];
				} else if (hit.transform == GameObject.Find("DownAngka3").transform) {
					if (indexNumber3 <= 9)
						indexNumber3 += 1;
					else {
						pos3 = new Vector3 (3.97f, -11.34f, 2f);
						indexNumber3 = 1;
					}
					pos3Y = SimPos[indexNumber3];
				} else if (hit.transform == GameObject.Find("UpAngka4").transform) {
					if (indexNumber4 > 0) 
						indexNumber4 -= 1;
					else {
						pos4 = new Vector3 (6.85f,12.69f,2f);
						indexNumber4 = 9;
					}
					pos4Y = SimPos[indexNumber4];
				} else if (hit.transform == GameObject.Find("DownAngka4").transform) {
					if (indexNumber4 <= 9)
						indexNumber4 += 1;
					else {
						pos4 = new Vector3 (6.85f, -11.34f, 2f);
						indexNumber4 = 1;
					}
					pos4Y = SimPos[indexNumber4];
				}
			}
			//misal passwordnya 0
		}
		if ( (indexNumber1 == 1) && (indexNumber2 == 10) && (indexNumber3 == 4) && (indexNumber4 == 5) ) {
			solvedAngka = true;
			//pindahScene();
		}
		// Moving numbers
		pos1.y = Mathf.Lerp (pos1.y, pos1Y, Time.deltaTime * 10f);
		RoletAngka1.transform.localPosition = pos1;
		pos2.y = Mathf.Lerp (pos2.y, pos2Y, Time.deltaTime * 10f);
		RoletAngka2.transform.localPosition = pos2;
		pos3.y = Mathf.Lerp (pos3.y, pos3Y, Time.deltaTime * 10f);
		RoletAngka3.transform.localPosition = pos3;
		pos4.y = Mathf.Lerp (pos4.y, pos4Y, Time.deltaTime * 10f);
		RoletAngka4.transform.localPosition = pos4;
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





