using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityUnit : Unit
{
    // Variables
    private ResourcePile m_CurrentPile = null;
    public float productivityMultiplier = 2;

    protected override void BuildingInRange()
    {
        if (m_CurrentPile == null)
        {
            ResourcePile pile = m_Target as ResourcePile;
            if (pile != null)
            {
                m_CurrentPile = pile;
                m_CurrentPile.ProductionSpeed += productivityMultiplier;
            }
        }
    }

}
