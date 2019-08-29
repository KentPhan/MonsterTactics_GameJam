﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Characters;
using System;
using Assets.Scripts.Inventory_System.Items;

namespace Assets.Scripts.Classes.Actions
{
    public class SwapWeaponAction : AbstractAction
    {
        AbstractItem playersweapon;
        AbstractItem inventoryweapon;

        public SwapWeaponAction(ref Player player,int actionPointCost) : base(actionPointCost)
        {
            if (player.WeaponSlot.GetComponent<AbstractItem>() != null)
            {
                playersweapon = player.WeaponSlot.GetComponent<AbstractItem>();
            }

            if (Inventory_System.InventorySystem.Instance.WeaponSlot.GetComponent<AbstractItem>() != null)
            {
                inventoryweapon = Inventory_System.InventorySystem.Instance.WeaponSlot.GetComponent<AbstractItem>();
            }
        }

        protected override event EventHandler actionEnded;

        public override void PlayAction(AbstractCharacter character)
        {
            if(playersweapon != null)
            {
                CopyComponent(playersweapon, Inventory_System.InventorySystem.Instance.WeaponSlot);
            }
            if(inventoryweapon != null)
            {
                CopyComponent(inventoryweapon, ((Player)character).WeaponSlot);
            }

            actionEnded?.Invoke(this, null);
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