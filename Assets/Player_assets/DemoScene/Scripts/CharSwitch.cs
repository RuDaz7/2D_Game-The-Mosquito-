using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSwitch : MonoBehaviour {
	public static GameObject Character;
	public static GameObject CharacterDef;

	public GameObject[] characters = new GameObject[6];

	public static int health;
	/*public static int healthD;

	public bool readyToCheck = true;
	public bool readyToCheckD = true;*/

	public int currentPlayer = 0;
	public GameObject respawnPoint;

	// Use this for initialization
	void Start () {
		respawnPoint = GameObject.Find ("Attack_1");
		Character = characters[currentPlayer];

		for(int x = 0; x<6; x++){
			if(Character != characters[x]){
				characters [x].SetActive (false);
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		Character.SetActive (true);

        if (Input.GetKeyDown(KeyCode.Space)) {
            characters[currentPlayer].SetActive(false);
            currentPlayer += 1;
            if (currentPlayer == 6) {
                currentPlayer = 0;
            }
            characters[currentPlayer].transform.position = respawnPoint.transform.position;
            Character = characters[currentPlayer];

        }
        /*if(health < 0){
			spyBullet.freezePlayer = false;
			characters [currentPlayer].SetActive (false);
			currentPlayer += 1;
			if(currentPlayer == 9){
				currentPlayer = 0;
			}
			characters	[currentPlayer].transform.position = respawnPoint.transform.position;
			Character = characters[currentPlayer];
			readyToCheck = true;
		}
		if(healthD < 0){
			spyBullet.freezePlayerD = false;
			charactersDef [currentPlayerDef].SetActive (false);
			currentPlayerDef += 1;
			if(currentPlayerDef == 9){
				currentPlayerDef = 0;
			}
			charactersDef	[currentPlayerDef].transform.position = respawnPointD.transform.position;
			CharacterDef = charactersDef[currentPlayerDef];
			readyToCheckD = true;
		}
		///////////////
		/// 
		/// 
		/// 

		if(readyToCheck){
			if(Character == characters[0]){
				health = 125;
			}
			if(Character == characters[1]){
				health = 200;
			}
			if(Character == characters[2]){
				health = 175;
			}
			if(Character == characters[3]){
				health = 175;
			}
			if(Character == characters[4]){
				health = 300;
			}
			if(Character == characters[5]){
				health = 125;
			}
			if(Character == characters[6]){
				health = 150;
			}
			if(Character == characters[7]){
				health = 125;
			}
			if(Character == characters[8]){
				health = 125;
			}
			readyToCheck = false;
		}

		if(readyToCheckD){
			if(CharacterDef == charactersDef[0]){
				healthD = 125;
			}
			if(CharacterDef == charactersDef[1]){
				healthD = 200;
			}
			if(CharacterDef == charactersDef[2]){
				healthD = 175;
			}
			if(CharacterDef == charactersDef[3]){
				healthD = 175;
			}
			if(Character == characters[4]){
				health = 300;
			}
			if(CharacterDef == charactersDef[5]){
				healthD = 125;
			}
			if(CharacterDef == charactersDef[6]){
				healthD = 150;
			}
			if(CharacterDef == charactersDef[7]){
				healthD = 125;
			}
			if(CharacterDef == charactersDef[8]){
				healthD = 125;
			}
			readyToCheckD = false;
		}*/

    }
}
