using UnityEngine;
using System.Collections;

public class TouchCameraControlCopy : MonoBehaviour 
{
	public float moveSensitivityX = 0.1f;
	public float moveSensitivityY = 0.1f;
	public bool invertMoveX = false;
	public bool invertMoveY = false;
	
	public float inertiaDuration = 0.2f;
	
	private Camera _camera;
	
	private float scrollVelocity = 0.0f;
	private float timeTouchPhaseEnded;
	private Vector2 scrollDirection = Vector2.zero;

	private float minX, maxX, minY, maxY;

	private  Vector3[] cameraPath = new Vector3[4];


	void Start () 
	{
		cameraPath[0] = new Vector3(9f, -3f, -10f);
		cameraPath[1] = new Vector3(9f, -8f, -10f);
		cameraPath[2] = new Vector3(30f, -8f, -10f);
		cameraPath[3] = new Vector3(10f, -20f, -10f);

		_camera = Camera.main;
		Vector3 startCameraPosition = _camera.transform.position;
		startCameraPosition.x = 9;
		startCameraPosition.y = -3;
		_camera.transform.position = startCameraPosition;
	}
	
	void Update () 
	{	
		Touch[] touches = Input.touches;
		if (touches.Length < 1)
		{
			//if the camera is currently scrolling
			if (scrollVelocity != 0.0f)
			{
				//slow down over time
				float t = (Time.time - timeTouchPhaseEnded) / inertiaDuration;
				float frameVelocity = Mathf.Lerp (scrollVelocity, 0.0f, t);
				_camera.transform.position += -(Vector3)scrollDirection.normalized * (frameVelocity * 0.05f) * Time.deltaTime;
				
				if (t >= 1.0f)
					scrollVelocity = 0.0f;
			}
		}
		
		if (touches.Length > 0)
		{
			if (touches[0].phase == TouchPhase.Began)
			{
				scrollVelocity = 0.0f;
			}
			else if (touches[0].phase == TouchPhase.Moved)
			{
				Vector2 delta = touches[0].deltaPosition;
				
				float positionX = delta.x * moveSensitivityX * Time.deltaTime;
				positionX = invertMoveX ? positionX : positionX * -1;
				
				float positionY = delta.y * moveSensitivityY * Time.deltaTime;
				positionY = invertMoveY ? positionY : positionY * -1;
//				if (positionX > positionY) 
//					positionY = 0;
//				else if (positionX <= positionY)
//					positionX = 0;
				_camera.transform.position += new Vector3 (positionX, positionY, 0);
				
				scrollDirection = touches[0].deltaPosition.normalized;
				scrollVelocity = touches[0].deltaPosition.magnitude / touches[0].deltaTime;
				
				
				if (scrollVelocity <= 100)
					scrollVelocity = 0;
				else if (scrollVelocity > 2000 || scrollVelocity < 0)
					scrollVelocity = 2000;
			}
			else if (touches[0].phase == TouchPhase.Ended)
			{
				timeTouchPhaseEnded = Time.time;
			}
		}
	}

	void LateUpdate ()
	{
		Vector3 limitedCameraPosition = _camera.transform.position;

		if (limitedCameraPosition.y > -8 && limitedCameraPosition.y <= -3 && limitedCameraPosition.x >= 9 && limitedCameraPosition.x <= 10) {
			minX = 9f;
			maxX = 9f;
			minY = -8f;
			maxY = -3f;
		}
		else if (limitedCameraPosition.y == -8 && limitedCameraPosition.x > 9 && limitedCameraPosition.x < 30) {
			minX = 9f;
			maxX = 30f;
			minY = -8f;
			maxY = -8f;
		}
		else if (limitedCameraPosition.y >= -8 && limitedCameraPosition.y <= -7 && limitedCameraPosition.x >= 9 && limitedCameraPosition.x <= 10) {
			minX = 9f;
			maxX = 10f;
			minY = -8f;
			maxY = -7f;
		}
		else if (limitedCameraPosition.y > -20 && limitedCameraPosition.y < -8 && limitedCameraPosition.x >= 29 && limitedCameraPosition.x <= 30) {
			minX = 30f;
			maxX = 30f;
			minY = -20f;
			maxY = -8f;
		}
		if (limitedCameraPosition.y == -8 && limitedCameraPosition.x == 30) {
			minX = 29f;
			maxX = 30f;
			minY = -9f;
			maxY = -8f;
		}

		limitedCameraPosition.x = Mathf.Clamp (limitedCameraPosition.x, minX, maxX);
		limitedCameraPosition.y = Mathf.Clamp (limitedCameraPosition.y, minY, maxY);
		_camera.transform.position = limitedCameraPosition;
	}
    
}
