using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private int timer;

	private float hp;
	private float armor;
	private float hunger;
	private Inventory[] playerInventory;

	public float HP {
		get { return this.hp; }
		set { this.hp = value; }
	}

	public float Armor {
		get { return this.armor; }
		set { this.armor = value; }
	}

	public float Hunger {
		get { return this.hunger; }
		set { this.hunger = value; }
	}

	public Inventory[] PlayerInventory{
		get { return this.playerInventory; }
		set { this.playerInventory = value; }
	}


	public void GetDamage(float multiplier){
		float coef = 1f;

		if (Armor != 0)
			coef = 1f / Armor;

		HP -= 0.5f * (multiplier * coef);
	}

	public void GetHunger(float multiplier){
		Hunger -= 0.5f * multiplier; 
	}

	public void Eat(float multiplier){
		Hunger += 0.5f * multiplier;
	}

	public void RegenHP(){
		if (Hunger >= 20f) {
			if (timer == 30) {
				HP += 1f;
				timer = 0;
			}
			timer++;
		}
	}



	// Use this for initialization
	void Start () {
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
