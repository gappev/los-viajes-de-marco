using UnityEngine;
using System.Collections;

public class GameConstants : MonoBehaviour {

	public static class GameEvents {
		public const string PLAYER_COLLISION_HAZARD = "playerCollisionHazard";
		public const string TRIGGER_POLICE = "triggerPolice";
		public const string GAME_OVER = "gameOver";
		public const string GAME_PAUSE = "gamePause";
		public const string SPEED_UP = "SpeedUp";
	}

	public static class Tags {
		public const string HAZARD = "Hazard";
		public const string POLICE_CONE = "Police Cone";
	}

	public enum GameStates {
		Playing,
		Paused,
		GameOver
	}
}
