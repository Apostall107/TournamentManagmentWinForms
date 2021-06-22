﻿namespace AppLibrary.Models
{
    public class PersonModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }


        public string FullName
        {
            get
            {
                return $"{ FirstName } { LastName }";
            }
        }


    }
}
