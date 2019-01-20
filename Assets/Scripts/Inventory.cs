using System.Collections;
using System.Collections.Generic;
using Objects;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<BringableObject> objs;

    private int index;

    private void Start()
    {
        index = 0;
        
        var objects = GetComponentsInChildren<BringableObject>(true);
        objs.AddRange(objects);
    }
    
    public void AddObj(BringableObject obj)
    {
        objs.Add(obj);
    }

    public void UseObjectInHand(Actor actor)
    {
        objs[index].Use(actor);
    }

    public void MoveUp()
    {
        objs[index].gameObject.SetActive(false);
        //TODO: this crashed when objs == 0
        index = (index + 1) % objs.Count;
        
        objs[index].gameObject.SetActive(true);
    }

    public void MoveDown()
    {
        objs[index].gameObject.SetActive(false);
        if (index == 0)
            index = objs.Count - 1;
        else
            index = (index - 1) % objs.Count;
        
        objs[index].gameObject.SetActive(true);
    }
}
