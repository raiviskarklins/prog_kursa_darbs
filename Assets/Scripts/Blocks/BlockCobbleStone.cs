using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCobbleStone : Block {

public BlockCobbleStone() : base()
    {

    }

    public override Tile TexturePosition(Direction direction)
    {
        Tile tile = new Tile();
        tile.x = 0;
        tile.y = 2;
        return tile;
    }
}
