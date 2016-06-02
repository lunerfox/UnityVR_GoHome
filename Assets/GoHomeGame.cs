using UnityEngine;
using System.Collections;

enum gameState { init, playing, done };

public class GoHomeGame : MonoBehaviour {
    gameState cur_gameState;
    Vector2 Player, Home, Distance;
    int turns = -1;

    int[,] map = new int[12, 12];

	// Use this for initialization
	void Start () {
        cur_gameState = gameState.init; 
        print("Welcome to Go Home. Your character is lost in a place a little bit away from its home.");
        print("Help your character find its way home by telling it which way to move :)");
    }
	
	// Update is called once per frame
	void Update () {
        bool moved = false;
        //Init State
        if (cur_gameState == gameState.init) {
            turns = -1;
            //Randomly generate locations for player and home
            Player = new Vector2(Random.Range(2, 10), Random.Range(2, 10));
            Home = new Vector2(Random.Range(2, 10), Random.Range(2, 10));

            cur_gameState = gameState.playing;
        }
        //Game State
        if (cur_gameState == gameState.playing) {
            if (Input.GetKeyDown(KeyCode.UpArrow)) { Player = Player + Vector2.up; moved = true; }
            else if (Input.GetKeyDown(KeyCode.DownArrow)) { Player = Player + Vector2.down; moved = true; }
            else if (Input.GetKeyDown(KeyCode.LeftArrow)) { Player = Player + Vector2.left; moved = true; }
            else if (Input.GetKeyDown(KeyCode.RightArrow)) { Player = Player + Vector2.right; moved = true; }

            if (moved || turns == -1) {
                Distance = Home - Player; 
                turns++;
                if (Distance.magnitude != 0) { print("After " + turns + " Steps, you are " + Distance.magnitude + " meters away from home."); }
                else {
                    print("You made it home in " + turns + " steps!");
                    print("Press R to restart game");
                    cur_gameState = gameState.done;
                }
            }
        }
        //Done State
        if (cur_gameState == gameState.done)
        {
            if (Input.GetKeyDown(KeyCode.R)) {
                print("Getting lost again...");
                cur_gameState = gameState.init;
            }
        }
    } 
}
