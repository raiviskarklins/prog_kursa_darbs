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

    public static Vector3 GetBlockPosVector(RaycastHit hit)
    {
        Vector3 pos = new Vector3(
            hit.point.x,
            hit.point.y,
            hit.point.z);

        return pos;
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

        return pos;
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

    public static bool SetBlockPlayer(RaycastHit hit, Ray ray, Block block, Vector3 playerPos, bool adjacent = false)
    {
        Chunk chunk = hit.collider.GetComponent<Chunk>();
        if (chunk == null)
            return false;
        WorldPos pos = GetBlockPos(hit, adjacent);

        Vector3 blockPosition = new Vector3(pos.x, pos.y, pos.z);
        Vector3 hitVector = blockPosition - hit.point;

        hitVector.x = Mathf.Abs(hitVector.x);
        hitVector.y = Mathf.Abs(hitVector.y);
        hitVector.z = Mathf.Abs(hitVector.z);

      //  Debug.Log("X: " + blockPosition.x);
      //  Debug.Log("Y: " + blockPosition.y);
    //    Debug.Log("Z: " + blockPosition.z);
    //    Debug.Log("------------------------------------------------------------");

   //     Debug.Log("X: " + hitVector.x);
    //    Debug.Log("Y: " + hitVector.y);
   //     Debug.Log("Z: " + hitVector.z);
   //     Debug.Log("------------------------------------------------------------");

        if (hitVector.x > hitVector.z && hitVector.x > hitVector.y)
        {
            if (ray.direction.x > 0)
            {
                blockPosition.x -= 1;
            }
            if (ray.direction.x < 0)
            {
                blockPosition.x += 1;
            }
        }
        else if (hitVector.y > hitVector.x && hitVector.y > hitVector.z)
        {
            if (ray.direction.y > 0)
            {
                blockPosition.y -= 1;
            }
            if (ray.direction.y < 0)
            {
                blockPosition.y += 1;
            }
        }
        else
        {
            if (ray.direction.z > 0)
            {
                blockPosition.z -= 1;
            }
            if (ray.direction.z < 0)
            {
                blockPosition.z += 1;
            }
        }

    //    Debug.Log("------------------------------------------------------------");
   //     Debug.Log("X: " + blockPosition.x);
   //     Debug.Log("Y: " + blockPosition.y);
    //    Debug.Log("Z: " + blockPosition.z);
    //    Debug.Log("------------------------------------------------------------");

        Block test = chunk.world.GetBlock(blockPosition);
        playerPos.x = Mathf.RoundToInt(playerPos.x);
        playerPos.y = Mathf.RoundToInt(playerPos.y);
        playerPos.z = Mathf.RoundToInt(playerPos.z);
        Vector3 playerPos_y = playerPos;
        playerPos_y.y += 1;

        if (test.blockType == Block.BlockType.Air && playerPos != blockPosition && playerPos_y != blockPosition)
        {
            chunk.world.SetBlock(blockPosition, block);
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