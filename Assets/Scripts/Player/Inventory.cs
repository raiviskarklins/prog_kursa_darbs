using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	private Block block;
	private int amount;

	public Block Block{
		get { return this.block; }
		set { this.block = value; }
	}

	public int Amount {
		get { return this.amount; }
		set { this.amount = value; }
	}
}
