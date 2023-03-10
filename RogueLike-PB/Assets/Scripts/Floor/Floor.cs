using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Floor
{

#region Variables & Properties

[SerializeField] public bool bossFloor;
[SerializeField] public bool encounterRoom;

[SerializeField] public List<ScriptableRoom> allPossibleEnemiesRooms;
[SerializeField] public List<ScriptableRoom> allPossibleLootRoom;

[SerializeField] public ScriptableRoom startingRoom;
[SerializeField] public ScriptableRoom endRoom;
[SerializeField] public ScriptableRoom bossRoom;
[SerializeField] public int maxNumberRoom;
[SerializeField] public int minNumberRoom;
[SerializeField] public int percentageRoomsWithEnemiesAtLeast;

private List<ScriptableRoom> roomList = new List<ScriptableRoom>();
private ScriptableRoom currentRoom;

//TODO for setting every room scene
[SerializeField] private Sprite BackGorundsprite;

private int roomNumbers;
private int enemyRoomNumber;
private int lootRoomNumber;

#endregion

#region MonoBehaviour

    // Awake is called when the script instance is being loaded
    void Awake()
    {
	
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

#endregion

#region Methods

public void GenerateFloor()
{
    GenerateRoomNumbers();
    GenerateRoomSequence();
}

private void GenerateRoomNumbers()
{
    //DON'T TOUCH
    int roomNumbers = Random.Range(minNumberRoom, maxNumberRoom + 1);
    int roomWithEnemiesMinimun = Mathf.CeilToInt(roomNumbers * percentageRoomsWithEnemiesAtLeast / 100);
    enemyRoomNumber = roomWithEnemiesMinimun + Random.Range(0, roomNumbers - roomWithEnemiesMinimun + 1);
    lootRoomNumber = roomNumbers - enemyRoomNumber;
    
    //TODO
    if (encounterRoom)
    {
        
    }
}

private void GenerateRoomSequence()
{
    roomList.Add(startingRoom);

    for (int i = 0; i < roomNumbers; i++)
    {
        if (enemyRoomNumber > 0 && lootRoomNumber > 0)
        {
            if (UnityEngine.Random.Range(0, 2) == 0)
            {
                enemyRoomNumber--;
                roomList.Add(allPossibleEnemiesRooms[Random.Range(0, allPossibleEnemiesRooms.Count)]);
            }
            else
            {
                lootRoomNumber--;
                roomList.Add(allPossibleLootRoom[Random.Range(0,allPossibleLootRoom.Count)]);
            }
        }
        else
        {
            if (enemyRoomNumber > 0)
            {
                enemyRoomNumber--;
                roomList.Add(allPossibleEnemiesRooms[Random.Range(0, allPossibleEnemiesRooms.Count)]);
            }
            else if (lootRoomNumber > 0)
            {
                lootRoomNumber--;
                roomList.Add(allPossibleLootRoom[Random.Range(0,allPossibleLootRoom.Count)]);
            }
        }
    }

    //For Debugging
    if (lootRoomNumber != 0 || enemyRoomNumber != 0)
    {
        Debug.Log("Error");
    }

    if (bossFloor)
    {
        roomList.Add(bossRoom);
    }
    roomList.Add(endRoom);
}

public ScriptableRoom GetCurrentRoom()
{
    return currentRoom;
}

#endregion

}
