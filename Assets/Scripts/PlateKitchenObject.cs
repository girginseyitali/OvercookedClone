using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    [SerializeField] private List<KitchenObjectSO> validKitchenObjectSOList = new List<KitchenObjectSO>();
    
    private List<KitchenObjectSO> _kitchenObjectSOList = new List<KitchenObjectSO>();
    
    public bool TryAddIngredient(KitchenObjectSO kitchenObjectSO)
    {
        if (!validKitchenObjectSOList.Contains(kitchenObjectSO))
        {
            //No valid ingredient
            return false;
        }
        
        if (_kitchenObjectSOList.Contains(kitchenObjectSO))
        {
            //Already has this type
            return false;
        }
        else
        {
            _kitchenObjectSOList.Add(kitchenObjectSO);
            return true;
        }
        
    }
}
