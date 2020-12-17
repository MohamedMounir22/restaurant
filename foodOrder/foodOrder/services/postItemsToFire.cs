using Firebase.Database;
using foodOrder.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace foodOrder.services
{
   public class postItemsToFire
    {
        FirebaseClient firbaseClient;
        ObservableCollection<items> allitmes;

        public postItemsToFire ()
        {
            firbaseClient = new FirebaseClient("https://tryingsecondtime-d3862-default-rtdb.firebaseio.com/");
            allitmes = new ObservableCollection<items>() {
                new items{}
                
                
                
                
                
                
                
                
                
                
                }
        }





        //methods


















    }//end class
}
