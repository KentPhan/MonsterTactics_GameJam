﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Characters;
using System;
using Assets.Scripts.Inventory_System.Items;

namespace Assets.Scripts.Classes.Actions
{
    public class PickUpAndStore : AbstractAction
    {
        private AbstractItem item;

        public PickUpAndStore(ref Square itemSquare, int actionPointCost) : base(actionPointCost)
        {
            GameObject itemslotforgrid = itemSquare.gameObject.transform.GetChild(1).gameObject;
            item = itemslotforgrid.GetComponent<AbstractItem>();
        }

        protected override event EventHandler actionEnded;

        public override void PlayAction(AbstractCharacter character)
        {
            Debug.Log(item.GetType().ToString());
            if (true)
            {

            }
            //CopyComponent(item, ((Player)player).WeaponSLot);
            item.Destroythis();
            //Inventory_System.InventorySystem.
        }

        Component CopyComponent(Component original, GameObject destination)
        {
            System.Type type = original.GetType();
            Component copy = destination.AddComponent(type);
            // Copied fields can be restricted with BindingFlags
            System.Reflection.FieldInfo[] fields = type.GetFields();
            foreach (System.Reflection.FieldInfo field in fields)
            {
                field.SetValue(copy, field.GetValue(original));
            }
            return copy;
        }
    }
}
