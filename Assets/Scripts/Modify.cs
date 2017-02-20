using UnityEngine;
using System.Collections;

public class Modify : MonoBehaviour
{

   // Vector2 rot;

    void Update()
    {

        
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2.0f, Screen.height / 2.0f, 0));
			if (Physics.Raycast(ray, out hit, 5f))
            {
                EditTerrain.SetBlock(hit, new BlockAir());
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2.0f, Screen.height / 2.0f, 0));
            if (Physics.Raycast(ray, out hit, 5f))
            {
               
                EditTerrain.SetBlockPlayer(hit, ray, new BlockCobbleStone(), transform.position);
            }
        }
    }
}