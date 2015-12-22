using UnityEngine;
using System.Collections;

public class PuzzleHuruf : MonoBehaviour {
	//private float moveDistance;
	private GameObject RoletHuruf1, RoletHuruf2, RoletHuruf3, RoletHuruf4;
	private int indexNumber1 = 0, indexNumber2 = 9,indexNumber3 = 2, indexNumber4 = 0;
	private Vector3 pos1, pos2, pos3, pos4;
	private float pos1X, pos2X, pos3X, pos4X;
	private float[] SimPos = new float[11] {-8.2f,-6.31f,-4.61f,-2.78f,-1.02f,0.74f,2.44f,4.2f,5.83f,7.59f,9.22f};

	// Use this for initialization
	void Start () {
		RoletHuruf1 = GameObject.Find ("RoletHuruf1");
		pos1 = RoletHuruf1.transform.localPosition;
		pos1X = pos1.x;
		RoletHuruf2 = GameObject.Find ("RoletHuruf2");
		pos2 = RoletHuruf2.transform.localPosition;
		pos2X = pos2.x;
		RoletHuruf3 = GameObject.Find ("RoletHuruf3");
		pos3 = RoletHuruf3.transform.localPosition;
		pos3X = pos3.x;
		RoletHuruf4 = GameObject.Find ("RoletHuruf4");
		pos4 = RoletHuruf4.transform.localPosition;
		pos4X = pos4.x;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && !StatusHuruf.SolvedHuruf) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				if (hit.transform == GameObject.Find("LeftHuruf1").transform) {
					if (indexNumber1 <= 9)
						indexNumber1 += 1;
					else {
						pos1 = new Vector3 (-8.2f, 8.69f, 2f);
						indexNumber1 = 1;
					}
					pos1X = SimPos[indexNumber1];
				} else if (hit.transform == GameObject.Find("LeftHuruf2").transform) {
					if (indexNumber2 <= 9) 
						indexNumber2 += 1;
					else {
						pos2 = new Vector3 (-8.2f, 6.08f, 2f);
						indexNumber2 = 1;
					}
					pos2X = SimPos[indexNumber2];					
				} else if (hit.transform == GameObject.Find("LeftHuruf3").transform) {
					if (indexNumber3 <= 9) 
						indexNumber3 += 1;
					else {
						pos3 = new Vector3 (-8.2f, 3.61f, 2f);
						indexNumber3 = 1;
					}
					pos3X = SimPos[indexNumber3];
				} else if (hit.transform == GameObject.Find("LeftHuruf4").transform) {
					if (indexNumber4 <= 9) 
						indexNumber4 += 1;
					else {
						pos4 = new Vector3 (-8.2f, 1.06f, 2f);
						indexNumber4 = 1;
					}
					pos4X = SimPos[indexNumber4];
				}
			}
			//misal passwordnya 0
		}
		if ( (indexNumber1 == 4)  && (indexNumber2 == 7) && (indexNumber3 == 5) && (indexNumber4 == 3) ) {
			Wait();
		}
		// Moving numbers
		pos1.x = Mathf.Lerp (pos1.x, pos1X, Time.deltaTime * 10f);
		RoletHuruf1.transform.localPosition = pos1;
		pos2.x = Mathf.Lerp (pos2.x, pos2X, Time.deltaTime * 10f);
		RoletHuruf2.transform.localPosition = pos2;
		pos3.x = Mathf.Lerp (pos3.x, pos3X, Time.deltaTime * 10f);
		RoletHuruf3.transform.localPosition = pos3;
		pos4.x = Mathf.Lerp (pos4.x, pos4X, Time.deltaTime * 10f);
		RoletHuruf4.transform.localPosition = pos4;
	}
	
	void Wait() {
		//animasi dll bisa ditambahin disini
		
		// 1 itu scene menu.unity, liat di build setting
		StartCoroutine (StartWait());

	}
	
	IEnumerator StartWait(){
		
		yield return new WaitForSeconds(1F);
		StatusHuruf.SolvedHuruf = true;
				
	}
}





