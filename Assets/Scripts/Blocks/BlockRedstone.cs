using UnityEngine;
using System.Collections;
using System;
[Serializable]

public class BlockRedstone : Block
{

    public BlockRedstone() : base()
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