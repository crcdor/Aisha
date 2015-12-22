using UnityEngine;
using System.Collections;

public class PuzzlePlanet : MonoBehaviour {
	private GameObject RoletPlanet1, RoletPlanet2, RoletPlanet3, Solved2, RedClue2;
	private int indexNumber1 = 0, indexNumber2 = 4,indexNumber3 = 6;
	private Vector3 pos1, pos2, pos3;
	private float pos1Y, pos2Y, pos3Y;
	private float[] SimPos = new float[9] {-7.8f,-5.03f,-2.07f,0.89f,3.6f,7.11f,10.43f,13.58f,16.7f};

	// Use this for initialization
	void Start () {
		RoletPlanet1 = GameObject.Find ("RoletPlanet1");
		pos1 = RoletPlanet1.transform.localPosition;
		pos1Y = pos1.y;
		RoletPlanet2 = GameObject.Find ("RoletPlanet2");
		pos2 = RoletPlanet2.transform.localPosition;
		pos2Y = pos2.y;
		RoletPlanet3 = GameObject.Find ("RoletPlanet3");
		pos3 = RoletPlanet3.transform.localPosition;
		pos3Y = pos3.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && !StatusPlanet.SolvedPlanet) {
			TouchCameraControl.kunci = true;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				if (hit.transform == GameObject.Find("UpPlanet1").transform) {
					if (indexNumber1 > 0) 
						indexNumber1 -= 1;
					else {
						pos1 = new Vector3 (-2.39f,16.7f,2f);
						indexNumber1 = 7;
					}
					pos1Y = SimPos[indexNumber1];
				} else if (hit.transform == GameObject.Find("DownPlanet1").transform) {
					if (indexNumber1 <= 7)
						indexNumber1 += 1;
					else {
						pos1 = new Vector3 (-2.39f, -7.8f, 2f);
						indexNumber1 = 1;
					}
					pos1Y = SimPos[indexNumber1];
				} else if (hit.transform == GameObject.Find("UpPlanet2").transform) {
					if (indexNumber2 > 0) 
						indexNumber2 -= 1;
					else {
						pos2 = new Vector3 (0.38f,16.7f,2f);
						indexNumber2 = 7;
					}
					pos2Y = SimPos[indexNumber2];
				} else if (hit.transform == GameObject.Find("DownPlanet2").transform) {
					if (indexNumber2 <= 7)
						indexNumber2 += 1;
					else {
						pos2 = new Vector3 (0.38f, -7.8f, 2f);
						indexNumber2 = 1;
					}
					pos2Y = SimPos[indexNumber2];
				} else if (hit.transform == GameObject.Find("UpPlanet3").transform) {
					if (indexNumber3 > 0) 
						indexNumber3 -= 1;
					else {
						pos3 = new Vector3 (3.1f,16.7f,2f);
						indexNumber3 = 7;
					}
					pos3Y = SimPos[indexNumber3];
				} else if (hit.transform == GameObject.Find("DownPlanet3").transform) {
					if (indexNumber3 <= 7)
						indexNumber3 += 1;
					else {
						pos3 = new Vector3 (3.1f, -7.8f, 2f);
						indexNumber3 = 1;
					}
					pos3Y = SimPos[indexNumber3];
				} 
			}
		}
		if ( (indexNumber1 == 6) && (indexNumber2 == 1) && (indexNumber3 == 3) && !StatusPlanet.SolvedPlanet) {
			Wait();
			//pindahScene();
		}
		// Moving numbers
		pos1.y = Mathf.Lerp (pos1.y, pos1Y, Time.deltaTime * 10f);
		RoletPlanet1.transform.localPosition = pos1;
		pos2.y = Mathf.Lerp (pos2.y, pos2Y, Time.deltaTime * 10f);
		RoletPlanet2.transform.localPosition = pos2;
		pos3.y = Mathf.Lerp (pos3.y, pos3Y, Time.deltaTime * 10f);
		RoletPlanet3.transform.localPosition = pos3;
		TouchCameraControl.kunci = false;
	}
	
	void Wait() {
		//animasi dll bisa ditambahin disini
		
		// 1 itu scene menu.unity, liat di build setting
		StartCoroutine (StartWait());
		
	}
	
	IEnumerator StartWait(){
		
		yield return new WaitForSeconds(1F);
		StatusPlanet.SolvedPlanet = true;
		
	}
}





