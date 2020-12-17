using Firebase.Database;
using foodOrder.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace foodOrder.services
{
    public class postCategoriesToFire
    {
        FirebaseClient firbaseClient;



        public postCategoriesToFire ()
        {
            firbaseClient = new FirebaseClient("https://tryingsecondtime-d3862-default-rtdb.firebaseio.com/");
        }



        //methods
        public async Task<ObservableCollection<category>> getCategorFromFire ()
        {
            ObservableCollection<category> allCategories = new ObservableCollection<category>();
            var returned = await firbaseClient.Child("Categories").OnceAsync<category>();

            foreach (var item in returned)
            {
                allCategories.Add(new category
                {
                    categoryId = item.Object.categoryId,
                    categoryName = item.Object.categoryName,
                    categoryPoster = item.Object.categoryPoster

                }) ; 
            }

            return allCategories;
        }








    }
}
