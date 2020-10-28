using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Slash.Unity.DataBind.Core;
using Slash.Unity.DataBind.Core.Data;

public class UpgradeHUDContext : Context
{
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

    private Property<string> beforeTextProperty = new Property<string>();
    public string BeforeText {
        get => beforeTextProperty.Value;
        set => beforeTextProperty.Value = value;
    }
    
    private Property<string> afterTextProperty = new Property<string>();
    public string AfterText {
        get => afterTextProperty.Value;
        set => afterTextProperty.Value = value;
    }

    private Item selectItem;

    public UpgradeHUDContext() {
        ChangeTap(0);
        
        selectItem = null;
        BeforeText = "선택된 값\n없음";
        AfterText = "선택된 값\n없음";
    }

    public void ChangeTap(Single index) {
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

    public void SelectItem(Item itemData) {
        if ( itemData.ItemLevel + 1 > 2 ) {
            BeforeText = "최대 레벨 입니다.";
            AfterText = "최대 레벨 입니다.";
            return;
        }

        selectItem = itemData;
        BeforeText = $"현재 레벨\nLv.{itemData.ItemLevel}\n초당/금액\n1초당/{itemData.Value[itemData.ItemLevel].ToKorean()}원";
        AfterText = $"다음 레벨업비용\n{itemData.Cost[itemData.ItemLevel + 1]}원\n초당/금액\n1초당/{itemData.Value[itemData.ItemLevel + 1].ToKorean()}원";
    }

    public void Upgrade() {
        if (selectItem == null) {
            "The selected item is at the maximum level or no item is selected.".Log();
            return;
        }

        $"{selectItem.Key} level up success!!".Log();
        
        UpgradeItemElement.CurrentSelectElement.ChangeColor(Color.white);

        selectItem.LevelUP();
        selectItem = null;
        BeforeText = "선택된 값\n없음";
        AfterText = "선택된 값\n없음";
    }
    
    public void CloseStore() {
        UIManager.Instance.OpenUI<MainUI>();
        UIManager.Instance.CloseUI<UpgradeHUD>();
    }
}
