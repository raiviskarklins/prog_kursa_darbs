using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDirt : Block {


	public BlockDirt():base(){
		blockType = BlockType.Grass;
	}
	public override Tile TexturePosition(Direction direction)
	{
		Tile tile = new Tile();
		tile.x = 1;
		tile.y = 0;
		return tile;
	}
}
