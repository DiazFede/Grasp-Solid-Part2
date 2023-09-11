//-------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;
using Full_GRASP_And_SOLID.Library;

namespace Full_GRASP_And_SOLID
{
    public class Program
    {
        private static ArrayList productCatalog = new ArrayList();
        private static ArrayList equipmentCatalog = new ArrayList();

        public static void Main(string[] args)
        {
            PopulateCatalogs();

            Recipe recipe = new Recipe();
            recipe.FinalProduct = GetProduct("Café con leche");
            recipe.AddStep(new Step(GetProduct("Café"), 100, GetEquipment("Cafetera"), 120));
            recipe.AddStep(new Step(GetProduct("Leche"), 200, GetEquipment("Hervidor"), 60));

            PrintRecipe printRecipe = new PrintRecipe();
            printRecipe.RecipePrint(recipe);
        }

        private static void PopulateCatalogs()
        {
            AddProductToCatalog("Café", 100);
            AddProductToCatalog("Leche", 200);
            AddProductToCatalog("Café con leche", 300);

            AddEquipmentToCatalog("Cafetera", 1000);
            AddEquipmentToCatalog("Hervidor", 2000);
        }

        private static void AddProductToCatalog(string description, double unitCost)
        {
            productCatalog.Add(new Product(description, unitCost));
        }

        private static void AddEquipmentToCatalog(string description, double hourlyCost)
        {
            equipmentCatalog.Add(new Equipment(description, hourlyCost));
        }

        private static Product GetProduct(string description)
        {
            foreach (Product product in productCatalog)
            {
                if (product.Description == description)
                {
                    return product;
                }
            }
            return null;
        }

        private static Equipment GetEquipment(string description)
        {
            foreach (Equipment equipment in equipmentCatalog)
            {
                if (equipment.Description == description)
                {
                    return equipment;
                }
            }
            return null;
        }
    }
}
