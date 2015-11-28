using UnityEngine;
using System.Collections;

public class TouchCameraControlCopy2 : MonoBehaviour 
{
	private float moveSensitivityX = 0.5f;
	private float moveSensitivityY = 0.5f;
	public bool invertMoveX = false;
	public bool invertMoveY = false;
	
	public float inertiaDuration = 0.2f;
	
	private Camera _camera;
	
	private float scrollVelocity = 0.0f;
	private float timeTouchPhaseEnded;
	private Vector2 scrollDirection = Vector2.zero;

	private float minX, maxX, minY, maxY;

	private Vector3[] cameraPath = new Vector3[4];
	private float pathIndex = 0;

	private bool isMoveY = false;



	void Start () 
	{
		cameraPath[0] = new Vector3(9f, -3f, -10f);
		cameraPath[1] = new Vector3(9f, -8f, -10f);
		cameraPath[2] = new Vector3(30f, -8f, -10f);
		cameraPath[3] = new Vector3(30f, -20f, -10f);

		_camera = Camera.main;
		_camera.transform.position = cameraPath[0];
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
				float v = frameVelocity *  0.005f * Time.deltaTime;
				//_camera.transform.position += -(Vector3)scrollDirection.normalized * (frameVelocity * 0.05f) * Time.deltaTime;
				if (isMoveY) {
					v *= scrollDirection.normalized.y;
				}
				else {
					v *= -scrollDirection.normalized.x;
				}
				moveCamera(v);
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

				if (Mathf.Abs(positionX) > Mathf.Abs(positionY)) {
					moveCamera(positionX);
					isMoveY = false;
				}
				else {
					moveCamera(-positionY);
					isMoveY = true;
				}
				//_camera.transform.position += new Vector3 (positionX, positionY, 0);


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

//	void LateUpdate ()
//	{
//		Vector3 currentCamPos = _camera.transform.position;
//		if (currentCamPos != cameraPath [pathIndex] || currentCamPos != cameraPath [pathIndex + 1]) {
//			currentCamPos.x = Mathf.Clamp (currentCamPos.x, cameraPath [pathIndex].x, cameraPath [pathIndex+1].x);
//			currentCamPos.y = Mathf.Clamp (currentCamPos.y, cameraPath [pathIndex].y, cameraPath [pathIndex+1].y);
//
//			_camera.transform.position = currentCamPos.x;
//	
//		}
//	}

	private void moveCamera(float swipeVal)
	{
		if (swipeVal > 1) 
			swipeVal = 1;
		else if (swipeVal < -1)
			swipeVal = -1;

		pathIndex += swipeVal;

		if (pathIndex < 0)
			pathIndex = 0;
		else if (pathIndex > 3)
			pathIndex = 3;

		int floored = Mathf.FloorToInt(pathIndex);
		int ceilinged = Mathf.CeilToInt(pathIndex);

		Vector3 newCamPos = _camera.transform.position;

		newCamPos.x = Mathf.Lerp (cameraPath [floored].x, cameraPath [ceilinged].x, pathIndex - floored);
		newCamPos.y = Mathf.Lerp (cameraPath [floored].y, cameraPath [ceilinged].y, pathIndex - floored);
		_camera.transform.position = newCamPos;
	}
}
					