using UnityEngine;
using System.Collections;

public class GameConstants : MonoBehaviour {

	public static class GameEvents {
		public const string PLAYER_COLLISION_HAZARD = "playerCollisionHazard";
		public const string GAME_OVER = "gameOver";
	}

	public static class Tags {
		public const string HAZARD = "Hazard";
	}

	public enum GameStates {
		Playing,
		Paused,
		GameOver
	}
}
