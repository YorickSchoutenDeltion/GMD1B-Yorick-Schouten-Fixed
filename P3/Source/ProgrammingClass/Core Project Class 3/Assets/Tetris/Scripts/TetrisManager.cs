using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisManager : MonoBehaviour {

    public GameObject prefab;
    public GameObject actPrefab;

    public List<GameObject> gridList = new List<GameObject>();
    public List<GameObject> actGrid = new List<GameObject>();

    public int gridSquares;
    public int maxGridWidth;

    public float dropdownTimer;
    private float dropdownMaxTimer;

    public Vector3 instPos;
    public Vector3 actInstPos;

    void Start()
    {
        SpawnGrid();
        dropdownMaxTimer = dropdownTimer;
    }

    void Update()
    {
        CubeDropDown();
    }

    void CubeDropDown()
    {
        dropdownTimer -= Time.deltaTime;
        if (FitsInRange(actGrid[-4]))
        {
            if (dropdownTimer < 0)
            {
                for (int i = 0; i < gridSquares - 1; i++)
                {
                    if (actGrid[i] != null)
                    {

                    }
                }
                dropdownTimer = dropdownMaxTimer;
            }
        }
       if (Input.GetButtonDown("Jump"))
        {
            actGrid[38] = ((GameObject)Instantiate(actPrefab, (gridList[38].transform.position) + new Vector3(0, 0, 1), Quaternion.identity));
        }
    }

    void SpawnGrid()
    {
        actInstPos.z = 1;
        for (int i = 0; i < gridSquares; i++)
        {
            gridList.Add((GameObject)Instantiate(prefab, instPos, Quaternion.identity));
            if (instPos.x < maxGridWidth - 1)
            {
                instPos.x++;
            }
            else
            {
                instPos.x = 0;
                instPos.y++;
            }
        }
    }

    bool FitsInRange(int i)
    {
        if(((i - maxGridWidth) > -1) && (i < gridList.Count))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
