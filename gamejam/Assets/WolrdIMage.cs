using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WolrdIMage : MonoBehaviour
{

		private Gameplay _gameplay;
		private Image _image;
		private Sprite secondWorld;
		private Sprite thirdWorld;
		private RotateControl _rotate;

		void Awake ()
		{
				_gameplay = GameObject.Find ("Gameplay").GetComponent<Gameplay> ();
		}

		// Use this for initialization
		void Start ()
		{
				_image = GetComponent<Image> ();
				_rotate = GetComponent<RotateControl> ();
				secondWorld = Resources.Load <Sprite> ("Image/UI_GamePlay/World_02");
				thirdWorld = Resources.Load <Sprite> ("Image/UI_GamePlay/World_03");

		}
	
		// Update is called once per frame
		void Update ()
		{
				if (_gameplay.GetTimeLeft > 0) {
						//Debug.Log (_gameplay.GetTimeLeft);
						if (_gameplay.GetTimeLeft < (Config.timeGamePlay [GameEngine.Instance.gameStage - 1] * 0.3)) {
								_image.sprite = thirdWorld;
								_rotate.time = 10F;
						} else if (_gameplay.GetTimeLeft < (Config.timeGamePlay [GameEngine.Instance.gameStage - 1] * 0.7)) {
								_image.sprite = secondWorld;
				_rotate.time = 20F;
						}
				}
		}
}
