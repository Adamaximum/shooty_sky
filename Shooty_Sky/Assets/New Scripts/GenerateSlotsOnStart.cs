using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GenerateSlotsOnStart : MonoBehaviour
{

    public bool killSlots;
    public int verticalSlots;
    public int horizontalSlots;
    public float slotSize;

    public SpawnEnemyOnFrames spawner;
    
    // Start is called before the first frame update
    private void Start()
    {
        if (killSlots)
        {
            spawner.killSlots = new Transform[verticalSlots + horizontalSlots];
        }
        else
        {
            spawner.spawnSlots = new Transform[verticalSlots + horizontalSlots];
        }
        
        for (var i = 0; i < verticalSlots + horizontalSlots; i++)
        {
            if (killSlots)
            {
                spawner.killSlots[i] = new GameObject("Slot" + i).transform;
                spawner.killSlots[i].position = SlotPosition(i);
                spawner.killSlots[i].SetParent(gameObject.transform);
            }
            else
            {
                spawner.spawnSlots[i] = new GameObject("Slot" + i).transform;
                spawner.spawnSlots[i].position = SlotPosition(i);
                spawner.spawnSlots[i].SetParent(gameObject.transform);
            }
        }
    }

    private Vector3 SlotPosition(int currentSlot)
    {
        float posX;
        float posY;

        var s2WMax = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        var s2WMin = Camera.main.ScreenToWorldPoint(Vector3.zero);
        
        if (currentSlot < verticalSlots / 2)
        {
            posX = killSlots 
                ? s2WMax.x + slotSize 
                : s2WMin.x - slotSize;
            posY = killSlots 
                ? s2WMin.y * (currentSlot + 1) / (verticalSlots / 2f + 1) 
                : s2WMax.y * (currentSlot + 1) / (verticalSlots / 2f + 1);
        }
        else if (currentSlot >= horizontalSlots + verticalSlots / 2)
        {
            posX = killSlots
                ? s2WMin.x - slotSize
                : s2WMax.x + slotSize;
            posY = killSlots
                ? s2WMin.y * ((verticalSlots + horizontalSlots) - (currentSlot)) / (verticalSlots / 2f + 1)
                : s2WMax.y * ((verticalSlots + horizontalSlots) - (currentSlot)) / (verticalSlots / 2f + 1);
        }
        else
        {
            posY = killSlots
                ? s2WMin.y - slotSize
                : s2WMax.y + slotSize;
            posX = killSlots
                ? s2WMax.x - s2WMax.x * 2 * (currentSlot - verticalSlots / 2 + 1) / (horizontalSlots + 1)
                : s2WMin.x + s2WMax.x * 2 * (currentSlot - verticalSlots / 2 + 1) / (horizontalSlots + 1);
        }
        return new Vector3(posX, posY);
    }
}
