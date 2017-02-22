using UnityEngine;
using System.Collections;

public class Inventory
{
    public Block block;
    public int amount;
}

public class Modify : MonoBehaviour
{

    Inventory[] playerInventory;

    int inventoryIndex;

    void Start()
    {
        playerInventory = new Inventory[2];
        inventoryIndex = 0;

        for (int i = 0; i< playerInventory.Length; i++)
        {
            playerInventory[i] = new Inventory();
            playerInventory[i].block = new BlockAir();
            playerInventory[i].amount = 0;
        }
    }

   // Vector2 rot;

    void Update()
    {

        foreach (Inventory slot in playerInventory)
        {
            if (slot.amount == 0)
            {
                slot.block = new BlockAir();
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2.0f, Screen.height / 2.0f, 0));
			if (Physics.Raycast(ray, out hit, 5f))
            {

             Block temp = EditTerrain.GetBlock(hit);

                foreach(Inventory slot in playerInventory)
                {
                    if(slot.block.blockType == Block.BlockType.Air || slot.block.blockType == temp.blockType)
                    {
                        slot.block = temp;
                        slot.amount++;
                        Debug.Log(slot.amount);
                        break;
                    }
                }
                EditTerrain.SetBlock(hit, new BlockAir());
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2.0f, Screen.height / 2.0f, 0));
            if (Physics.Raycast(ray, out hit, 5f))
            {
               if (playerInventory[inventoryIndex].amount > 0)
                {
                    EditTerrain.SetBlockPlayer(hit, ray, playerInventory[inventoryIndex].block, transform.position);
                    playerInventory[inventoryIndex].amount--;
                    Debug.Log(playerInventory[inventoryIndex].amount);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            inventoryIndex = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            inventoryIndex = 1;
        }
    }
}