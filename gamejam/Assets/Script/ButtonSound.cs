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


	void Start() {
		alarm = (AudioClip) Resources.Load(Config.SOUND+Config.ALARM, typeof(AudioClip)) ;
		bgmGameplay = (AudioClip) Resources.Load(Config.SOUND+Config.GAMEPLAY_BGM, typeof(AudioClip)); 
		bgmMainMenu = (AudioClip) Resources.Load(Config.SOUND+Config.BGM_MAIN_MENU, typeof(AudioClip)); 
		errorMove = (AudioClip) Resources.Load(Config.SOUND+Config.ERROR_MOVE, typeof(AudioClip)); 
		closePopup = (AudioClip) Resources.Load(Config.SOUND+Config.CLOSE_POPUP, typeof(AudioClip)); 
		openPopup = (AudioClip) Resources.Load(Config.SOUND+Config.OPEN_POPUP, typeof(AudioClip)); 
		tileMove = (AudioClip) Resources.Load(Config.SOUND+Config.TILE_MOVE, typeof(AudioClip)); 
		tileMission = (AudioClip) Resources.Load(Config.SOUND+Config.TILE_MISSION, typeof(AudioClip)); 
		completeMission = (AudioClip) Resources.Load(Config.SOUND+Config.WIN_GAME, typeof(AudioClip)); 
		pressButton = (AudioClip) Resources.Load(Config.SOUND+Config.PRESS_BUTTON, typeof(AudioClip)); 
		gameOver = (AudioClip) Resources.Load(Config.SOUND+Config.GAMEOVER, typeof(AudioClip));

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
