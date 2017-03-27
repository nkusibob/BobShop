using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    public class ShoppingCart
    {
        public Dictionary<int, CartItem> CartLine { get; set; }
        private List<int> list;

        public ShoppingCart()
        {
            CartLine = new Dictionary<int, CartItem>();
            list=new List<int>();//liste de clés
        }

        /// <summary>
        /// Total du Panier
        /// </summary>
        public decimal CartTotal {
            get
            {
                decimal total = 0;
                foreach (KeyValuePair<int, CartItem> keyAndValue in this.CartLine.ToList())
                {
                    total = total + keyAndValue.Value.price*keyAndValue.Value.quantity;
                }

                return total;
            }
        }

        public int CartTotalItems
        {
            get
            {
                int total = 0;
                foreach (KeyValuePair<int, CartItem> keyAndValue in this.CartLine.ToList())
                {
                    total = total + keyAndValue.Value.quantity;
                }

                return total;
            }
        }

        
        //genere un id pour le cart line; (on append le gen id au cart Item pour creer une cartline)
        //private int generatedId()
        //{
        //    Random rand=new Random();
        //    bool isUnique=true;
        //    int temp;
        //    do
        //    {
        //        temp = rand.Next(100);
        //            for(int i=0;i< list.Count && isUnique;i++)
        //        {
        //            if(list[i]==temp)
        //            {
        //                isUnique=false;
        //            }
        //        }
        //    }while(!isUnique);
        //    return temp;
        //}
        public void AddCartLine(CartItem ci)
        {
            int key = ci.productid;
            list.Add(key);
            if (!CartLine.ContainsKey(key))
            {
                CartLine.Add(key, ci);
            }

        }
        public void RemoveToCartLine(CartItem ci)

        {
            int key = ci.productid;
            list.Remove(key);
            if (!CartLine.ContainsKey(key))
            {
                CartLine.Remove(key);
            }

        }

        public void modifyCartLine(int id, int newqty)
        {
            if (CartLine.ContainsKey(id))
            {
                CartItem t;
                CartLine.TryGetValue(id, out t);
                t.quantity=newqty;
                CartLine[id] = t;
            }
            // Traitement supplémentaire ?
        }

        //gives quantity of a given product in the cart . 0 o.w.
        public int GetQuantityOf(int productId)
        {
            return CartLine.Values.First(a => a.productid == productId).quantity;
        }

    }

    public partial class CartItem
    {
        public int productid { get { return this.product.ProductID; } }
        public string productname { get { return this.product.ProductName; } }
        public decimal price { get; set; }
        public int quantity { get; set; }
        public Product product { get; set; }
    }

    /*ajouté partial quand on a eu besoin de validations (Models/CartMetaData/CartMetaData) faites
     * Je usppose qu'on aurait pu mettre les validations ici, mais ainsi elles sont toutes regroupées dans Models/MetaData
     */

    public class CartLine
    {
        public CartLine(int b, CartItem t)
        {
            id =b ;
            item=t;
        }
        public int id { get; set; }
        public CartItem item {get;set;}

    }
}
