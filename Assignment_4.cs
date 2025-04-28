using System;

namespace EmployeeManagementSystem
{

    public sealed class AadharCard
    {
        private string AadharNumber;



        public string Nationality;

        
        public AadharCard(string AadharNumber, string Nationality)
        {
            this.AadharNumber = AadharNumber;
            this.Nationality= Nationality;  
        }

       
        public void AadharDetails()
        {


            Console.WriteLine($"Aadhar Number : {AadharNumber} ------Nationality:  {Nationality}");
        }
    }

 
    public class AadharGuide
    {
        public void AadharCenter()
        {

            AadharCard A = new AadharCard("1224354", "Indian");

            
           A.AadharDetails();
        }
    }
}
