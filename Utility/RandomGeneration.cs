using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.Utility
{
    public static class RandomGeneration
    {
        public static string Pin()
        {
            Random rnd = new Random();
            int one = rnd.Next(0, 9);
            int two = rnd.Next(3, 5);
            int three = rnd.Next(2, 9);
            int four = rnd.Next(4, 7);

            return $"{one}{two}{three}{four}";
        }

        public static string TempaReferralCode()
        {
            Random rnd = new Random();
            int one = rnd.Next(4, 7);
            int two = rnd.Next(1, 9);
            int three = rnd.Next(1, 5);
            int four = rnd.Next(1, 9);
           

            return $"{one}{two}{three}{four}";
        }

        public static string GenerateAccountNumber()
        {
            Random rnd = new Random();
            int one = rnd.Next(4, 7);
            int two = rnd.Next(1, 9);
            int three = rnd.Next(1, 5);
            int four = rnd.Next(1, 9);


            return $"{one}{two}{three}{four}";
        }

        public static string TransConcatenation()
        {
            Random rnd = new Random();
            int one = rnd.Next(0, 9);
            int two = rnd.Next(4, 5);


            return $"{one}{two}";
        }

    }
}