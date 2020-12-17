using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using foodOrder.Models;
using Firebase.Database.Query;

namespace foodOrder.services
{
   public class userService
    {
        FirebaseClient firebaseClient;

        //ctor
        public userService ()
        {
            firebaseClient = new FirebaseClient("https://tryingsecondtime-d3862-default-rtdb.firebaseio.com/");
        }


        //check existing
       public async Task<bool> isUserExisting (string uname)
        {
            var user = (await firebaseClient.Child("users").OnceAsync<user>()).
                Where(u => u.Object.username == uname).FirstOrDefault();
            return (user != null);
        }

        //register
        public async Task<bool> registerNewUser (string uname , string pass)
        {
            if (await isUserExisting(uname) == false)
            {
                await firebaseClient.Child("users").PostAsync(new user() { username = uname, password = pass });
                return true;
            }
            else
                return false;

            
            
        }

        //login
        public async Task<bool> loginUser (string uname, string pass)
        {
            var User = (await firebaseClient.Child("users").OnceAsync<user>())
                .Where(u => u.Object.username == uname)
                .Where(u => u.Object.password == pass).FirstOrDefault();

            return (User != null);
        }



    }
}
