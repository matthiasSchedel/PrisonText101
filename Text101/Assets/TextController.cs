using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*
Author: Matthias Schedel 

*/
public class TextController : MonoBehaviour {
	public Text text;
	
	private enum States {start, cell, bed_0, bed_1, sheet, door_0,door_1, lock_0, lock_1, outside};
	private States myState;
	private States doorState;
	private States lockState;
	private States bedState;
	// Use this for initialization
	void Start () {
	
		text.text = "Welcome Player One, press the spacebar.";
		bedState = States.bed_0;
		myState = States.start;
		doorState =  States.door_0;
		lockState = States.lock_0;
	}

	
	void state_start ()
	{		
		if (Input.GetKeyDown (KeyCode.Space)) {
			text.text = "You wake up and you realize that you are locked in a small prison cell " + 
				"the only objects in your room are a wooden bed " + 
					", a locked door with an iron lock " + 
					"and a sheet of paper on the floor." + 
					"\n\n" + 
					"What do you want to do? \n" + 
					"Press d to go look at the door. \n" + 
					"Press b to look at the bed. \n" + 
					"Press s to look at the sheet of paper. \n";
			
		}
		if (Input.GetKeyDown (KeyCode.D)) { 
			myState = doorState;
		} else if (Input.GetKeyDown (KeyCode.B)) { 
			myState = bedState;
		} else if (Input.GetKeyDown (KeyCode.S)) { 
			myState = States.sheet;
		}
		
	}

	void state_cell ()
	{		
			text.text = "You wake up and you realize that you are locked in a small prison cell " + 
			"the only objects in your room are a wooden bed " + 
			", a locked door with an iron lock " + 
			"and a sheet of paper on the floor." + 
			"\n\n" + 
			"What do you want to do? \n" + 
			"Press d to go look at the door. \n" + 
			"Press b to look at the bed. \n" + 
			"Press s to look at the sheet of paper. \n";
			
	
		if (Input.GetKeyDown (KeyCode.D)) { 
			myState = doorState;
		} else if (Input.GetKeyDown (KeyCode.B)) { 
			myState = bedState;
		} else if (Input.GetKeyDown (KeyCode.S)) { 
			myState = States.sheet;
		}
		
	}
	
	void state_bed_0() {
		text.text = "You look under the bed and you find a key ... you put the key in your inventory \n" + 
			"press b to go back";
		if (Input.GetKeyDown (KeyCode.B)) { 
			text.text = "b pressed";
			bedState = States.bed_1;
			myState = States.cell;
			lockState = States.lock_1;
		}
	}
	
	void state_bed_1() {
		text.text = "You look under the bed ... there is nothing \n" + 
			"press b to go back";
		if (Input.GetKeyDown (KeyCode.B)) { 
			text.text = "b pressed";
			myState = States.cell;
		}
	}
	
	void state_door_0(){
		text.text = "The door is locked, you need a key to unlock it \n" + 
			"press b to go back \n"
			+ "press l to take a look at the lock";
		if (Input.GetKeyDown (KeyCode.B)) { 
			text.text = "b pressed";
			myState = States.cell;
		} else if (Input.GetKeyDown (KeyCode.L)) { 
			text.text = "l pressed";
			myState = lockState;
			}
	}
	
	void state_sheet() {
		text.text = "you look at a piece of paper \n" + 
		"press b to go back";
		if (Input.GetKeyDown (KeyCode.B)) { 
			text.text = "b pressed";
			myState = States.cell;
		}
	}
	void state_door_1(){
		if (Input.GetKeyDown (KeyCode.B)) { 
			text.text = "b pressed";
			myState = States.cell;
		}
	} 
	
	void state_lock_0(){
		text.text = "you need a key here... \n" + 
			"press b to go back";
		if (Input.GetKeyDown (KeyCode.B)) { 
			text.text = "b pressed";
			myState = doorState;
		}
	}
	
	void state_lock_1() {
		text.text = "you unlocked the door, it hopens with a loud screeeeeetch loud \n" +
			"press o to go outside";
		if (Input.GetKeyDown (KeyCode.O)) {
			text.text = "o pressed";
			doorState = States.door_1;
			myState = States.outside;
		}
	}
	void state_outside() {
		text.text = "congratulations you won your freedom enjoy it + press r to restart the game";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.start;
		}
	}
	// Update is called once per frame
	void Update () {
	if (myState == States.cell) {
	 		state_cell ();
	 	} else if (myState == States.start) {
	 		state_start();
	 	}else if (myState == States.bed_0) {
			state_bed_0();
		} else if (myState == States.bed_1) {
	 		state_bed_1();
		} else if (myState == States.door_0) {
			state_door_0();
		} else if (myState == States.door_1) {
			state_door_1();		
		} else if (myState == States.lock_0) {
			state_lock_0();	
		} else if (myState == States.lock_1) {
			state_lock_1();
		} else if (myState == States.sheet) {
			state_sheet();
		} 
		else if (myState == States.outside) {		
			state_outside();	
		}	 	 
	}		
}