using Firebase.Database;
using foodOrder.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace foodOrder.services
{
   public class postItemsToFire
    {
        FirebaseClient firbaseClient;
       

        public postItemsToFire ()
        {
            firbaseClient = new FirebaseClient("https://tryingsecondtime-d3862-default-rtdb.firebaseio.com/");
            
                
                
                
                
                
                
                
                
                
                
                
               
        }





    //methods
  public async Task<ObservableCollection<items>> getItemsFromFire ()
    {
        ObservableCollection<items> allitmes = new ObservableCollection<items>();
            var returned = await firbaseClient.Child("items").OnceAsync<items>();

         foreach(var item in returned)
            {
                allitmes.Add(new items
                {
                    categoryId = item.Object.categoryId,
                    description = item.Object.description,
                    itemId = item.Object.itemId,
                    itemImageUrl = item.Object.itemImageUrl,
                    itemName = item.Object.itemName,
                    price = item.Object.price,
                    rating = item.Object.rating
                }); ;
            }

            return allitmes;
    }

















    }//end class
}
