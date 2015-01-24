using UnityEngine;
using System.Collections;
public class InputManager : MonoBehaviour
{
	public static float mmDistanceThreshold = 2.5f;
	public static float autoPlayInterval = 0.02f;
	public static bool autoPlay = false;
	float distanceThreshold;
	float countdown;
	float? initialMoveTime;
	Vector3? start = null, end = null;
	int? direction = null;
	int previousDirection = 0;
	Gameplay _gameplay;

	
	void Start ()
	{
		distanceThreshold = Screen.dpi / 25.4f * mmDistanceThreshold;
		_gameplay = GameObject.Find ("Gameplay").GetComponent<Gameplay> ();
		Input.simulateMouseWithTouches = true;
		countdown = autoPlayInterval;
	}
	
	int? CheckInput ()
	{
		int? direction = null;
		
		if (Input.GetMouseButtonDown (0)) {
			start = Input.mousePosition;
		} else if (Input.GetMouseButton (0) && start.HasValue) {
			end = Input.mousePosition;
			if (Mathf.Abs (end.Value.x - start.Value.x) > Mathf.Abs (end.Value.y - start.Value.y)) {
				if (end.Value.x - start.Value.x > distanceThreshold)
					direction = 1;
				else if (start.Value.x - end.Value.x > distanceThreshold)
					direction = 3;
			} else {
				if (end.Value.y - start.Value.y > distanceThreshold)
					direction = 0;
				else if (start.Value.y - end.Value.y > distanceThreshold)
					direction = 2;
			}
		}
		
		if (Input.GetKeyDown (KeyCode.UpArrow))
			direction = 0;
		else if (Input.GetKeyDown (KeyCode.RightArrow))
			direction = 1;
		else if (Input.GetKeyDown (KeyCode.DownArrow))
			direction = 2;
		else if (Input.GetKeyDown (KeyCode.LeftArrow))
			direction = 3;

		
		return direction;
	}
	
	void Update ()
	{
		Input.simulateMouseWithTouches = true;
		direction = CheckInput ();
		if(_gameplay.state == (int)Gameplay.State.Normal && _gameplay.isWin == false){
			if (direction.HasValue) {
				_gameplay.checkMoveAble (direction.Value);
				direction = null;
				start = null;
			}
		}

	}
	

}
