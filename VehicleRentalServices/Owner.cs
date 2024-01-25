using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRentalServices
{
    public class Owner : Person
    {
        #region CONSTRUCTOR AND DESTRUCTOR
        public Owner()
        {
            this.feedbackHistory = new List<Feedback>();
        }
        public Owner(string fullName, string id, DateTime dateOfBirth, string phoneNumber)
        : base(fullName, id, dateOfBirth, phoneNumber)
        {
            this.feedbackHistory = new List<Feedback>();
        }
        ~Owner() {}
        #endregion

        public override void OutputInformation()
        {
            Console.WriteLine($"Full Name : {this.fullName}");
            Console.WriteLine($"ID : {this.id}");
            Console.WriteLine($"Date of Birth : {this.dateOfBirth}");
            Console.WriteLine($"Phone Number : {this.phoneNumber}");
        }
    }
}
