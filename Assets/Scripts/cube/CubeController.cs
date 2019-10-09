using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public GameObject trap;

    private bool isTrapped = false; 
    void Start()
    {
        string cubeThemeMate = Constants.cubeThemeMates[Random.Range(0, Constants.cubeThemeMates.Count)];
        Constants.cubeThemeMates.Remove(cubeThemeMate);
        GameObject wall = this.transform.GetChild(0).gameObject;
        for (int i = 0; i < wall.transform.childCount; i++)
        {
            GameObject planks = wall.transform.GetChild(i).GetChild(0).gameObject;
            for (int j = 0; j < planks.transform.childCount; j++)
                if (planks.transform.GetChild(j).tag == "plank")
                    planks.transform.GetChild(j).GetComponent<Renderer>().material = Resources.Load("materials/" + cubeThemeMate) as Material;

        }


    }
  
    public void instantiateTrap()
    {
        if (trap&& !isTrapped)
        {
            isTrapped = true;
            GameObject enemyGameObject = Instantiate(trap);
            enemyGameObject.transform.position = transform.GetChild(1).GetChild(1).transform.position;
        }
       
    }

    public void closeAllDoors()
    {
        GameObject wall = this.transform.GetChild(0).gameObject;
        for (int i = 0; i < wall.transform.childCount; i++)
        {
            GameObject cube = wall.transform.GetChild(i).GetComponent<WallCubeLinker>().cube;
            if (cube)
                cube.SetActive(false);

            GameObject planks = wall.transform.GetChild(i).GetChild(0).gameObject;
             planks.transform.GetChild(4).GetComponent<Door>().open = false;
            planks.transform.GetChild(4).GetComponent<Door>().close = true;

        }
    }
 
}
