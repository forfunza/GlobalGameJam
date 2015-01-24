using UnityEngine;
using System.Collections;
public enum SoundType {
	Alarm, BgmMainMenu, BgmGamePlay, ErrorMove,
	ClosePopup, OpenPopup, TileMove, TileMission,
	CompleteMission,PressButton,GameOver
}
public class ButtonSound : MonoBehaviour {
	public SoundType soundType;
	public AudioClip alarm;
	public AudioClip bgmGameplay;
	public AudioClip bgmMainMenu;
	public AudioClip errorMove;
	public AudioClip closePopup;
	public AudioClip openPopup;
	public AudioClip tileMove;
	public AudioClip tileMission;
	public AudioClip completeMission;
	public AudioClip pressButton;
	public AudioClip gameOver;



	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void PlaySound() {
		switch (soundType){
		case SoundType.Alarm:
			SoundManager.Instance.PlaySound(alarm);
			break;
		case SoundType.BgmGamePlay :
			SoundManager.Instance.PlaySound(bgmGameplay);
			break;
		case SoundType.BgmMainMenu :
			SoundManager.Instance.PlaySound(bgmMainMenu);
			break;
		case SoundType.ClosePopup :
			SoundManager.Instance.PlaySound(closePopup);
			break;
		case SoundType.CompleteMission :
			SoundManager.Instance.PlaySound(completeMission);
			break;
		case SoundType.ErrorMove :
			SoundManager.Instance.PlaySound(errorMove);
			break;
		case SoundType.GameOver :
			SoundManager.Instance.PlaySound(gameOver);
			break;
		case SoundType.OpenPopup :
			SoundManager.Instance.PlaySound(openPopup);
			break;
		case SoundType.PressButton :
			SoundManager.Instance.PlaySound(pressButton);
			break;
		case SoundType.TileMission :
			SoundManager.Instance.PlaySound(tileMission);
			break;
		case SoundType.TileMove :
			SoundManager.Instance.PlaySound(tileMove);
			break;

		
		}
	}
}
