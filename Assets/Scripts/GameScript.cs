using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < Input.touchCount; i++)
		{
			Touch touch = Input.GetTouch(i);
			if (touch.phase == TouchPhase.Began && touch.tapCount == 1)
			{
				Vector3 startposition = Camera.main.ScreenToWorldPoint(touch.position);

			}
			else if (touch.phase == TouchPhase.Moved && touch.tapCount == 1)
			{
				Vector3 movedposition = Camera.main.ScreenToWorldPoint(touch.position);

			}
			else if (touch.phase == TouchPhase.Ended && touch.tapCount == 1)
			{
				// Touch are screens location. Convert to world
				Vector3 position = Camera.main.ScreenToWorldPoint(touch.position);


			}
		}
	}
}
