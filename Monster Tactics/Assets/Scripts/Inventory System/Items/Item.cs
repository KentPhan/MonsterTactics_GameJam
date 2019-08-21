﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [HideInInspector]
    public int MaxStack = 0;
    [HideInInspector]
    public Sprite Icon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Equip()
    { 
    }
}