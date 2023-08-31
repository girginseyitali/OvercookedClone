using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    public event EventHandler<OnIngredientAddedEventArgs> OnIngredientAdded;

    public class OnIngredientAddedEventArgs : EventArgs
    {
        public KitchenObjectSO KitchenObjectSO;
    }
    
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
            OnIngredientAdded?.Invoke(this, new OnIngredientAddedEventArgs
            {
                KitchenObjectSO = kitchenObjectSO
            });
            return true;
        }
        
    }

    public List<KitchenObjectSO> GetKitchenObjectSOList()
    {
        return _kitchenObjectSOList;
    }
}
