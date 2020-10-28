using System.Collections;
using System.Collections.Generic;
using Slash.Unity.DataBind.Core.Data;
using UnityEngine.UI;
using UnityEngine;

public class UpgradeItemElement : MonoBehaviour {
    private Item information;

    [SerializeField]
    private Image eyeCatch;

    [SerializeField]
    private Button buttonCommand;
    
    private UIBase parent;

    public void Initialize(UIBase parent, Item itemData) {
        this.parent = parent;
        information = itemData;
        eyeCatch.sprite = itemData.ItemSprite;

        buttonCommand.onClick.AddListener(() => {
            var upgradeHUD = parent as UpgradeHUD;
     
            if (upgradeHUD.ContextHolder?.Context is UpgradeHUDContext context) {
                context?.SelectItem(information);
            }
        });
    }

    public void Upgrade() {
        
    }
}