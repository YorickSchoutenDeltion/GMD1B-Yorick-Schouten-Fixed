using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisManager : MonoBehaviour {

    public GameObject prefab;
    public GameObject actPrefab;

    public List<GameObject> gridList = new List<GameObject>();
    public List<GameObject> actGrid = new List<GameObject>();
    public List<int> leftWall = new List<int>();
    public List<int> rightWall = new List<int>();

    public int gridSquares;
    public int maxGridWidth;

    public float dropdownTimer;
    private float dropdownMaxTimer;

    public Vector3 instPos;
    public Vector3 actInstPos;

    void Start()
    {
        SpawnGrid();
        CreateWallList();
        dropdownMaxTimer = dropdownTimer;
    }

    void Update()
    {
        CubeDropDown();
        PlayerMovement();
    }
    // Drops down the cubes every few seconds
    void CubeDropDown()
    {
        dropdownTimer -= Time.deltaTime;
            if (dropdownTimer < 0)
       {
            for (int i = 0; i < gridSquares - 1; i++)
           {
                if (actGrid[i] != null)
                {
                    if (DownRangeCheck(i))
                    {
                        actGrid[i - maxGridWidth] = actGrid[i];
                        actGrid[i].transform.position += new Vector3(0, -1, 0);
                        actGrid[i] = null;
                    }
                }
            }
            dropdownTimer = dropdownMaxTimer;
       }
       if (Input.GetButtonDown("Jump"))
        {
            actGrid[38] = ((GameObject)Instantiate(actPrefab, (gridList[38].transform.position) + new Vector3(0, 0, 1), Quaternion.identity));
        }
    }
    // Instantiates a grid to make it easier to understand the position of the cubes
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
    // Establishes a list that contains the index numbers of the outer walls
    void CreateWallList()
    {
       for (int i = 0; i < gridSquares + 1; i += maxGridWidth)
        {
            rightWall.Add(i);
        }
        for (int i = maxGridWidth -1; i < gridSquares + 1; i += maxGridWidth)
        {
            leftWall.Add(i);
        }
    }
    // Checks if the cube is allowed to move down
    bool DownRangeCheck(int i)
    {
        if (i - maxGridWidth > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    // Checks if the cube is allowed to move horizontally
    bool HorRangeCheck(int i, bool r)
    {
       bool rwb = false;
       if (r)
        {
            for(int rw = 0; rw < rightWall.Count; rw++)
            {
                if(i == rightWall[rw])
                {
                    rwb = true;
                }
            }
            return rwb;
        }
       else
        {
            for(int lw = 0; lw < leftWall.Count; lw++)
            {
                if(i == leftWall[lw])
                {
                    rwb = true;
                }
            }
            return rwb;
        }
    }
    // Allows the player to move the cubes manually
    void PlayerMovement()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            for(int i = 0; i < gridSquares - 1; i++)
            {
                if (actGrid[i] != null)
                {
                   if (!HorRangeCheck(i, false))
                    {
                        actGrid[i + 1] = actGrid[i];
                        actGrid[i].transform.position += new Vector3(1, 0, 0);
                        actGrid[i] = null;
                        break;
                    }
                }
            }
        }
        if (Input.GetButtonDown("Fire2"))
        {
            for (int i = 0; i < gridSquares - 1; i++)
            {
                if (actGrid[i] != null)
                {
                    if (!HorRangeCheck(i, true))
                    {
                        actGrid[i - 1] = actGrid[i];
                        actGrid[i].transform.position += new Vector3(-1, 0, 0);
                        actGrid[i] = null;
                        break;
                    }
                }
            }
        }
    }
}
