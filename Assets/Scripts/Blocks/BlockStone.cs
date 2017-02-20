using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockStone : Block {

	public BlockStone():base()
	{
		blockType = BlockType.Stone;	
	}

	public override Tile TexturePosition(Direction direction)
	{
		Tile tile = new Tile();
		tile.x = 3;
		tile.y = 1;
		return tile;
	}
}
