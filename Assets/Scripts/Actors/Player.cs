using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.Characters.FirstPerson;
using Vector3 = UnityEngine.Vector3;

[RequireComponent(typeof(FirstPersonController))]
public class Player : Actor
{
    private Camera camera;

    private Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponentInChildren<Camera>();
        inventory = GetComponentInChildren<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           inventory.UseObjectInHand(this);
        }
        
        if(Input.mouseScrollDelta.y >= 1)
            inventory.MoveUp();
        else if(Input.mouseScrollDelta.y <= -1)
            inventory.MoveDown();
            
    }

    public override void OnDie()
    {
        GameManager.Instance.Lose();
    }
}
