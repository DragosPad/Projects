using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clasa
{
    class Contact
    {
           private string firstName;
           private string lastName;
           private DateTime dateOfBirth;
       // public int age;

        //public DateTime DateOfBirth
        //{
        //    get
        //    {
        //        return dateOfBirth;
        //    }

        //    set
        //    {
        //        dateOfBirth = value;
        //    }
        //}
           public string FirstName
           {
               get
               {
                   return this.firstName;
               }
               set
               {
                   this.firstName = value;
               }
           }
           public string LastName
           {
               get
               {
                   return this.lastName;
               }
               set
               {
                   this.lastName = value;
               }
           }

           public string FullName
           {
               get
               {
                   return firstName + " " + lastName;
               }
           }
        public bool VerifyEmailAddress(string emailAddress)
        {

           return true;
        }

        //public void Search(float latitude, float longitude)
        //{
        //    Search(latitude, longitude, 10, "en-US");
        //}

        //public void Search(float latitude, float longitude, int distance)
        //{
        //    Search(latitude, longitude, distance, "en-US");
        //}
        public void Search(float latitude, float longitude, int distance = 10, string culture = "en-US")
        {
            Console.WriteLine("Latitude {0}, longitude {1}, distance {2}, culture {3}", latitude, longitude, distance, culture);
        }

        public Contact()
        {

        }
        public Contact(string firstName, string lastName, DateTime dateOfBirth)
            : this()
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
        }

        //public void F()
        //{
        //    age = 18;
        //}

        //public void G()
        //{
        //    //int age;
        //    age = 21;
        //    //Console.WriteLine(age);
          
        //}
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("Name: {0} \r\n", FullName);
            //stringBuilder.AppendFormat("Date of Birth: {0}\r\n", this.dateofBirth);
            return stringBuilder.ToString();
        }

    }
}
