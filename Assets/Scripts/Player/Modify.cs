using UnityEngine;
using System.Collections;

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
            playerInventory[i].Block = new BlockAir();
            playerInventory[i].Amount = 0;
        }
    }

   // Vector2 rot;

    void Update()
    {

        foreach (Inventory slot in playerInventory)
        {
            if (slot.Amount == 0)
            {
                slot.Block = new BlockAir();
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
                    if(slot.Block.blockType == Block.BlockType.Air || slot.Block.blockType == temp.blockType)
                    {
                        slot.Block = temp;
                        slot.Amount++;
                        Debug.Log(slot.Amount);
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
               if (playerInventory[inventoryIndex].Amount > 0)
                {
                    EditTerrain.SetBlockPlayer(hit, ray, playerInventory[inventoryIndex].Block, transform.position);
                    playerInventory[inventoryIndex].Amount--;
                    Debug.Log(playerInventory[inventoryIndex].Amount);
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