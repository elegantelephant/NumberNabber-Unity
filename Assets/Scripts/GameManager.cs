using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public BoardManager boardMgr;
	private int level = 1;

	// Use this for initialization
	void Awake () {
		boardMgr = GetComponent<BoardManager> ();
		InitGame ();
	}

	void InitGame() {
		boardMgr.SceneSetup (level);
	}

}
