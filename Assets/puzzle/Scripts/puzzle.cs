using UnityEngine;
using System.Collections;

public class puzzle : MonoBehaviour {
	public float moveDistance = 1.35f;
	private Vector3 pos;
	private float posY;
	private GameObject puzzleNumbers1;
	private float indexNumber = 0;

	// Use this for initialization
	void Start () {
		puzzleNumbers1 = GameObject.Find ("puzzle-numbers1");
		pos = puzzleNumbers1.transform.position;
		posY = pos.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				if (hit.transform == GameObject.Find("arrow-up1").transform) {
					if (indexNumber > 0) {
						posY -= moveDistance;
						indexNumber -= 1;
					}
				} else if (hit.transform == GameObject.Find("arrow-down1").transform) {
					if (indexNumber < 9) {
						posY += moveDistance;
						indexNumber += 1;
					}
				}

				//misal passwordnya 0
				if (indexNumber == 9) {
					pindahScene();
				}
			}
		}

		// Moving numbers
		pos.y = Mathf.Lerp (pos.y, posY, Time.deltaTime * 10f);
		puzzleNumbers1.transform.position = pos;
	}

	void pindahScene() {
		//animasi dll bisa ditambahin disini
		Application.LoadLevel (0); // 1 itu scene menu.unity, liat di build setting
	}
}
