using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private float hp;
	private float armor;
	private Inventory[] playerInventory;

	public float HP {
		get { return this.hp; }
		set { this.hp = value; }
	}

	public float Armor {
		get { return this.armor; }
		set { this.armor = value; }
	}

	public Inventory[] PlayerInventory{
		get { return this.playerInventory; }
		set { this.playerInventory = value; }
	}




	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
