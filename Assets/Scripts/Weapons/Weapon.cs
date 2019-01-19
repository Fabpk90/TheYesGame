using System.Collections;
using System.Collections.Generic;
using Objects;
using UnityEngine;

public class Weapon : BringableObject
{
    public int atk;
    
    private Mesh model;

    private MeshFilter renderer;
    // Start is called before the first frame update
    private ResourceRequest loaderDelegate;
    private void Awake()
    {
        renderer = GetComponentInChildren<MeshFilter>();
        
       // loaderDelegate = Resources.LoadAsync<GameObject>("Weapon/test");
       // loaderDelegate.completed += LoadOnCompleted;
       
       model = renderer.mesh;
       renderer.mesh = model;
    }

    private void LoadOnCompleted(AsyncOperation obj)
    {
        model = (Mesh) loaderDelegate.asset;
        renderer.mesh = model;
    }

    public override void Use(Actor actor)
    {
        var transform1 = actor.hand.transform;
        RaycastHit[] hits = Physics.RaycastAll
            (transform1.position, transform1.forward);
           
        foreach (var hit in hits)
        {
            if (!hit.collider.isTrigger)
            {
                Enemy enemy = hit.transform.GetComponent<Enemy>();
                
                if(enemy)
                    enemy.TakeDamage(atk);
            }
        }
    }
}
