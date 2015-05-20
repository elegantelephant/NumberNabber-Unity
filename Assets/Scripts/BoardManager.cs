using UnityEngine;
using System.Collections;

public class BoardManager : MonoBehaviour {

	public SpriteRenderer tilePrefab; 

	// Notice: Initializer for public values in unity are only "suggestions" 
	// and can be overwritten by the editor.  This help with tweaking the values.
	public int   width  = 3;
	public int   height = 4;
	// percentage of the smaller display axis the board should take up.
	public float displayPercentage = 1.0f;  

	private Transform boardHolder;
	private SpriteRenderer[,] tiles;
	private float tileToDisplayRatio = 1.0f;

	private float GetTileToDisplayRatio() {
		Camera cam = Camera.main;
		float camHeight = 2.0f * cam.orthographicSize;
		float camWidth = camHeight * cam.aspect;
		//TODO: Current hardcode to a portrait aspect ratio.  FIX THAT!
		float boardsize = camWidth * displayPercentage;
		float size = boardsize / width;
		return size;
	}

	private void BoardSetup() {
		tileToDisplayRatio = GetTileToDisplayRatio ();
		tilePrefab.transform.localScale = Vector3.one * tileToDisplayRatio;
		tiles = new SpriteRenderer[width,height];
		// create and initalized a container object.  This is solely for 
		// editor organization.
		boardHolder = new GameObject ("Board").transform;
		for (int x = 0; x < width; ++x) {
			for (int y = 0; y < height; ++y) {
				tiles[x,y] = Instantiate(
					tilePrefab, 
					new Vector2(x * tileToDisplayRatio, y * tileToDisplayRatio), 
					Quaternion.identity) 
				as SpriteRenderer;
				//SpriteRenderer tileClone = (SpriteRenderer) Instantiate(tile, transform.position, transform.rotation);
				tiles[x,y].transform.SetParent(boardHolder);
			}
		}
		boardHolder.position = new Vector2 (
			-(tileToDisplayRatio * width / 2),  // move the board holder to the left half the board width
			-(tileToDisplayRatio * height) / 2); // move the board holderd down hgalf the board height */

	}

	public void SceneSetup(int level) {
		BoardSetup();
	}

}
