using UnityEngine;
using System.Collections;

public class StatusPlanet : MonoBehaviour {
	
	public static bool SolvedPlanet = false;
	private bool Solved2Created = false;
	public GameObject Solved2;
	private GameObject Parent;
	//private bool Status = false;
	
	// Use this for initialization
	void Start () {
		Parent = Instantiate (Solved2);
		Renderer[] rs = Parent.GetComponentsInChildren<Renderer> ();
		foreach (Renderer r in rs) {
			r.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (StatusPlanet.SolvedPlanet) {
			Renderer[] rs = Parent.GetComponentsInChildren<Renderer> ();
			if (Solved2Created == false) {
				Solved2Created = true;
				foreach (Renderer r in rs) {
					r.enabled = true;
					UnityEngine.Color oldColor = r.GetComponent<Renderer>().material.color;
					r.GetComponent<Renderer>().material.color = new UnityEngine.Color(oldColor.r, oldColor.g, oldColor.b, 0);
				}
			}
			foreach (Renderer r in rs) {
				if (r.GetComponent<Renderer>().material.color.a != 1) {
					//new WaitForSeconds(2);
					UnityEngine.Color oldColor = r.GetComponent<Renderer>().material.color;
					r.GetComponent<Renderer>().material.color = new UnityEngine.Color(oldColor.r, oldColor.g, oldColor.b, Mathf.Lerp (r.GetComponent<Renderer>().material.color.a, 1, Time.deltaTime * 0.7f));
				}
			}
		}
		if (PuzzleAngka.solvedAngka) {
			Destroy(Parent);
		}
	}
}
