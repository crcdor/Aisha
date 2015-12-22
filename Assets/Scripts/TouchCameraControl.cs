using UnityEngine;
using System.Collections;

public class TouchCameraControl : MonoBehaviour 
{
	private float moveSensitivityX = 3f;
	private float moveSensitivityY = 3f;
	public bool invertMoveX = false;
	public bool invertMoveY = false;
	public static bool kunci = false;
	public float inertiaDuration = 0.2f;
	
	private Camera _camera;
	
	private float scrollVelocity = 0.0f;
	private float timeTouchPhaseEnded;
	private Vector2 scrollDirection = Vector2.zero;
	
	private float minX, maxX, minY, maxY;
	
	//private  Vector3[] cameraPath = new Vector3[12];
	private GameObject[] tes;
	public bool tesCreated = false;

	void Start () 
	{
		_camera = Camera.main;
		Vector3 startCameraPosition = _camera.transform.position;
		startCameraPosition.x = 0f; //248f; 248f; 102F;  202f;
		startCameraPosition.y = 0f; //-41.5f-26f; -26F;   -55f; 
		_camera.transform.position = startCameraPosition;

	}
	
	void Update () 
	{	
		Touch[] touches = Input.touches;
		if (!kunci) {
			if (touches.Length < 1) {
				//if the camera is currently scrolling
				if (scrollVelocity != 0.0f) {
					//slow down over time
					float t = (Time.time - timeTouchPhaseEnded) / inertiaDuration;
					float frameVelocity = Mathf.Lerp (scrollVelocity, 0.0f, t);
					_camera.transform.position += -(Vector3)scrollDirection.normalized * (frameVelocity * 0.05f) * Time.deltaTime;
				
					if (t >= 1.0f)
						scrollVelocity = 0.0f;
				}
			}
		
			if (touches.Length > 0) {
				if (touches [0].phase == TouchPhase.Began) {
					scrollVelocity = 0.0f;
				} else if (touches [0].phase == TouchPhase.Moved) {
					Vector2 delta = touches [0].deltaPosition;
				
					float positionX = delta.x * moveSensitivityX * Time.deltaTime;
					positionX = invertMoveX ? positionX : positionX * -1;
				
					float positionY = delta.y * moveSensitivityY * Time.deltaTime;
					positionY = invertMoveY ? positionY : positionY * -1;
					if (Mathf.Abs (positionX) > Mathf.Abs (positionY)) 
						positionY = 0;
					else if (Mathf.Abs (positionX) <= Mathf.Abs (positionY))
						positionX = 0;
					_camera.transform.position += new Vector3 (positionX, positionY, 0);
				
					scrollDirection = touches [0].deltaPosition.normalized;
					scrollVelocity = touches [0].deltaPosition.magnitude / touches [0].deltaTime;
				
				
					if (scrollVelocity <= 100)
						scrollVelocity = 0;
					else if (scrollVelocity > 1500 || scrollVelocity < 0)
						scrollVelocity = 1500;
				} else if (touches [0].phase == TouchPhase.Ended) {
					timeTouchPhaseEnded = Time.time;
				}
			}
		}
	}
	
	void LateUpdate ()
	{
		Vector3 limitedCameraPosition = _camera.transform.position;
		
		if (limitedCameraPosition.y > -32.5 && limitedCameraPosition.y <= -0 && limitedCameraPosition.x >= 0 && limitedCameraPosition.x <= 0) {
			minX = 0f;
			maxX = 0f;
			minY = -32.5f;
			maxY = 0f;
		}  if (limitedCameraPosition.y <= -32.5 && limitedCameraPosition.y >= -32.5 && limitedCameraPosition.x >= 0 && limitedCameraPosition.x <= 26) {
			minX = 0f;
			maxX = 26f;
			minY = -32.5f;
			maxY = -32.5f;
		}  if (limitedCameraPosition.y >= -32.5 && limitedCameraPosition.y <= -13 && limitedCameraPosition.x >= 26 && limitedCameraPosition.x <= 26) {
			minX = 26f;
			maxX = 26f;
			minY = -32.5f;
			maxY = -13f;
		}  if (limitedCameraPosition.y >= -13 && limitedCameraPosition.y <= -13 && limitedCameraPosition.x >= 26 && limitedCameraPosition.x <= 79) {
			minX = 26f;
			maxX = 79f;
			minY = -13f;
			maxY = -13f;
		} if (limitedCameraPosition.y >= -26 && limitedCameraPosition.y <= -13 && limitedCameraPosition.x >= 79 && limitedCameraPosition.x <= 79) {
			minX = 79f;
			maxX = 79f;
			minY = -26f;
			maxY = -13f;
		} //Dibawah adalah IF PUZZLE PLANET SOLVED   
		if ( ( limitedCameraPosition.y >= -37 && limitedCameraPosition.y <= -26 && limitedCameraPosition.x >= 95 && limitedCameraPosition.x <= 105 ) 
			&& StatusPlanet.SolvedPlanet) {
			minX = 95f;
			maxX = 105f;
			minY = -37f;
			maxY = -26f;
		} if (limitedCameraPosition.y >= -26 && limitedCameraPosition.y <= -26 && limitedCameraPosition.x >= 79 && limitedCameraPosition.x <= 248) {
			minX = 79f;
			maxX = 248f;
			minY = -26f;
			maxY = -26f;
		} //Dibawah adalah IF PUZZLE HURUF SOLVED 
		if ( (limitedCameraPosition.y >= -57 && limitedCameraPosition.y <= -55 && limitedCameraPosition.x >= 197 && limitedCameraPosition.x <= 202 ) 
		    && StatusHuruf.SolvedHuruf) {
			minX = 197f;
			maxX = 202f;
			minY = -57f;
			maxY = -55f;
		} if (limitedCameraPosition.y >= -55 && limitedCameraPosition.y <= -41 && limitedCameraPosition.x >= 200 && limitedCameraPosition.x <= 202) {
			minX = 200f;
			maxX = 202f;
			minY = -57f;
			maxY = -41f;
		} if (limitedCameraPosition.y >= -41 && limitedCameraPosition.y <= -30 && limitedCameraPosition.x >= 195 && limitedCameraPosition.x <= 202) {
			minX = 195f;
			maxX = 200f;
			minY = -41f;
			maxY = -30f;
		} if (limitedCameraPosition.y >= -30 && limitedCameraPosition.y <= -26 && limitedCameraPosition.x >= 190 && limitedCameraPosition.x <= 195) {
			minX = 190f;
			maxX = 202f;
			minY = -30f;
			maxY = -26f;
		} if (limitedCameraPosition.y >= -50 && limitedCameraPosition.y <= -26 && limitedCameraPosition.x >= 248 && limitedCameraPosition.x <= 248) {
			minX = 248f;
			maxX = 248f;
			minY = -50f;
			maxY = -26f;
			if (limitedCameraPosition.y <= - 46 && !StatusCermin.MirrorFlag) {
				StatusCermin.MirrorFlag = true;
			}
		}
		limitedCameraPosition.x = Mathf.Clamp (limitedCameraPosition.x, minX, maxX);
		limitedCameraPosition.y = Mathf.Clamp (limitedCameraPosition.y, minY, maxY);
		_camera.transform.position = limitedCameraPosition;
	}
	
}
