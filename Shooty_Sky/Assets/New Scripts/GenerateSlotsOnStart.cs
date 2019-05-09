using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class GenerateSlotsOnStart : MonoBehaviour
{
    public int shipType;
    public int verticalSlots;
    public int horizontalSlots;
    public float shipSize;

    public SpawnEnemyOnFrames spawner;
    
    // Start is called before the first frame update
    private void Start()
    {
        var slots = new[]
        {
            GenerateSlotRow(true),
            GenerateSlotColumn(true),
            GenerateSlotRow(false),
            GenerateSlotColumn(false)
        };

        switch (shipType)
        {
            case 0:
                spawner.type0Slots = slots;
                break;
            case 1:
                spawner.type1Slots = slots;
                break;
            case 2:
                spawner.type2Slots = slots;
                break;
        }
    }


    private Transform[] GenerateSlotRow(bool top)
    {
        var slots = new Transform[verticalSlots];
        for (var i = 0; i < verticalSlots; i++)
        {
            slots[i] = new GameObject("slot" + i).transform;
            slots[i].SetParent(gameObject.transform);
            slots[i].localPosition = RowSlotPosition(top, i);
        }
        return slots;
    }

    private Transform[] GenerateSlotColumn(bool left)
    {
        var slots = new Transform[horizontalSlots];
        for (var i = 0; i < horizontalSlots; i++)
        {
            slots[i] = new GameObject("slot" + i).transform;
            slots[i].SetParent(gameObject.transform);
            slots[i].localPosition = ColumnSlotPosition(left, i);
        }

        return slots;
    }

    private Vector3 RowSlotPosition(bool top, int index)
    {
        var screenMax = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        var screenMin = Camera.main.ScreenToWorldPoint(Vector3.zero);
        var posY = top ? screenMax.y + shipSize / 2 : screenMin.y - shipSize / 2;
        var posX = screenMin.x + (screenMax.x - screenMin.x) * (index + 1) / (verticalSlots + 1);
        return new Vector3(posX, posY);
    }

    private Vector3 ColumnSlotPosition(bool left, int index)
    {
        var screenMax = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        var screenMin = Camera.main.ScreenToWorldPoint(Vector3.zero);
        var posX = left ? screenMin.x - shipSize / 2 : screenMax.x + shipSize / 2;
        var posY = screenMax.y - (screenMax.y - screenMin.y) * (index + 1) / (horizontalSlots + 1);
        return new Vector3(posX, posY);
    }
}
