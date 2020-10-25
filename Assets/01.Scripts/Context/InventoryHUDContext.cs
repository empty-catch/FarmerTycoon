using System;
using System.Collections;
using System.Collections.Generic;
using Slash.Unity.DataBind.Core.Data;
using UnityEngine;

public class InventoryHUDContext : Context {
    private Property<bool> isCurrentTapClosetProperty = new Property<bool>();

    public bool IsCurrentTapCloset {
        get => isCurrentTapClosetProperty.Value;
        set => isCurrentTapClosetProperty.Value = value;
    }

    private Property<bool> isCurrentTapAnimalProperty = new Property<bool>();

    public bool IsCurrentTapAnimal {
        get => isCurrentTapAnimalProperty.Value;
        set => isCurrentTapAnimalProperty.Value = value;
    }

    private Property<bool> isCurrentTapPlantProperty = new Property<bool>();

    public bool IsCurrentTapPlant {
        get => isCurrentTapPlantProperty.Value;
        set => isCurrentTapPlantProperty.Value = value;
    }

    private Property<bool> isCurrentTapToolProperty = new Property<bool>();

    public bool IsCurrentTapTool {
        get => isCurrentTapToolProperty.Value;
        set => isCurrentTapToolProperty.Value = value;
    }

    public InventoryHUDContext() {
        ChangeTap(0);
    }

    public void ChangeTap(Single index) {
        // TODO : 이거 리스트에 담고 해도 안되는데 좀 개극혐이라 추후 수정 
        IsCurrentTapCloset = false;
        IsCurrentTapAnimal = false;
        IsCurrentTapPlant = false;
        IsCurrentTapTool = false;

        switch (index) {
            case 0:
                IsCurrentTapCloset = true;
                break;
            case 1:
                IsCurrentTapAnimal = true;
                break;
            case 2:
                IsCurrentTapPlant = true;
                break;
            case 3:
                IsCurrentTapTool = true;
                break;
            default:
                throw new ArgumentException("Invalid format argument.");
                break;
        }
    }

    public void CloseStore() {
        UIManager.Instance.OpenUI<MainUI>();
        UIManager.Instance.CloseUI<InventoryHUD>();
    }
}