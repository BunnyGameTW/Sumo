using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FoodSystem : MonoBehaviour {
    public Queue<GameObject> food_Unused;
    public GameObject[] food;
	
	// Update is called once per frame
	void Update () {
	
	}
    public void setup()
    {
        food_Unused = new Queue<GameObject>();
        for (int i = 0; i < 200; i++)
        {
            //create
            GameObject obj = Instantiate(food[i % 3]);
            obj.SetActive(false);
            food_Unused.Enqueue(obj);
        }
    }
    public void ShowFood()
    {
        float x_min = GameManager.game.LB.position.x + 2;
        float x_max = GameManager.game.RT.position.x - 2;
        float y_min = GameManager.game.LB.position.y + 2;
        float y_max = GameManager.game.RT.position.y - 2;
       

        for (int i = 0; i < 10; i++)
        {
            GameObject pop = food_Unused.Dequeue();
            float x_pos = Random.Range(x_min, x_max);
            float y_pos = Random.Range(y_min, y_max);
            pop.transform.position = new Vector3(x_pos, y_pos, 0);
            pop.SetActive(true);
        }       
    }
}
