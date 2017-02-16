using UnityEngine;
using System.Collections;

public static class EditTerrain
{
    public static WorldPos GetBlockPos(Vector3 pos)
    {
        WorldPos blockPos = new WorldPos(
            Mathf.RoundToInt(pos.x),
            Mathf.RoundToInt(pos.y),
            Mathf.RoundToInt(pos.z)
            );

        return blockPos;
    }

    public static WorldPos GetBlockPos(RaycastHit hit, bool adjacent = false)
    {
        Vector3 pos = new Vector3(
            MoveWithinBlock(hit.point.x, hit.normal.x, adjacent),
            MoveWithinBlock(hit.point.y, hit.normal.y, adjacent),
            MoveWithinBlock(hit.point.z, hit.normal.z, adjacent)
            );

        return GetBlockPos(pos);
    }

    static float MoveWithinBlock(float pos, float norm, bool adjacent = false)
    {
        if (pos - (int)pos == 0.5f || pos - (int)pos == -0.5f)
        {
            if (adjacent)
            {
                pos += (norm / 2);
            }
            else
            {
                pos -= (norm / 2);
            }
        }

        return (float)pos;
    }

    public static bool SetBlock(RaycastHit hit, Block block, bool adjacent = false)
    {
        Chunk chunk = hit.collider.GetComponent<Chunk>();
        if (chunk == null)
            return false;

        WorldPos pos = GetBlockPos(hit, adjacent);

        chunk.world.SetBlock(pos.x, pos.y, pos.z, block);

        return true;
    }

    public static bool SetBlockPlayer(RaycastHit hit, Ray ray, Block block, bool adjacent = false)
    {
        Chunk chunk = hit.collider.GetComponent<Chunk>();
        if (chunk == null)
            return false;
        WorldPos pos = GetBlockPos(hit, adjacent);

        int x = 0;
        int y = 0;
        int z = 0;

        if (Mathf.Abs(ray.direction.x) > Mathf.Abs(ray.direction.y) && Mathf.Abs(ray.direction.x) > Mathf.Abs(ray.direction.z))
        {
            if (ray.direction.x > 0)
            {
                x = -1;
            }
            if (ray.direction.x < 0)
            {
                x = 1;
            }
        }
        if (Mathf.Abs(ray.direction.y) > Mathf.Abs(ray.direction.x) && Mathf.Abs(ray.direction.y) > Mathf.Abs(ray.direction.z))
        {
            if (ray.direction.y > 0)
            {
                y = -1;
            }
            if (ray.direction.y < 0)
            {
                y = 1;
            }
        }
        if (Mathf.Abs(ray.direction.z) > Mathf.Abs(ray.direction.x) && Mathf.Abs(ray.direction.z) > Mathf.Abs(ray.direction.y))
        {
            if (ray.direction.z > 0)
            {
                z = -1;
            }
            if (ray.direction.z < 0)
            {
                z = 1;
            }
        }

        Block test = chunk.world.GetBlock(pos.x + x, pos.y + y, pos.z + z);


        Debug.Log("X: " + Mathf.Abs(ray.direction.x));
        Debug.Log("Y: " + Mathf.Abs(ray.direction.y));
        Debug.Log("Z: " + Mathf.Abs(ray.direction.z));
        Debug.Log("------------------------------------------------------------");

        if (test.blockType == Block.BlockType.Air)
        {
            chunk.world.SetBlock(pos.x + x, pos.y + y, pos.z + z, block);
            return true;
        }
        return false;
    }

    public static Block GetBlock(RaycastHit hit, bool adjacent = false)
    {
        Chunk chunk = hit.collider.GetComponent<Chunk>();
        if (chunk == null)
            return null;

        WorldPos pos = GetBlockPos(hit, adjacent);

        Block block = chunk.world.GetBlock(pos.x, pos.y, pos.z);

        return block;
    }
}