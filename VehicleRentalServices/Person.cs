using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRentalServices
{
    public class Person
    {
        protected string fullName;
        protected string id;
        protected DateTime dateOfBirth;
        protected string phoneNumber;
        protected List<Feedback> feedbackHistory;

        #region CONSTRUCTOR AND DESTRUCTOR
        public Person()
        {
            this.fullName = "";
            this.id = "";
            this.dateOfBirth = DateTime.Now;
            this.phoneNumber = "";
            this.feedbackHistory = new List<Feedback>();
        }
        public Person(string fullName, string id, DateTime dateOfBirth, string phoneNumber)
        {
            this.fullName = fullName;
            this.id = id;
            this.dateOfBirth = dateOfBirth;
            this.phoneNumber = phoneNumber;
            this.feedbackHistory = new List<Feedback>();
        }
        ~Person() {}
        #endregion

        #region PROPERTY
        public string FullName
        {
            get { return this.fullName; }
        }
        public string ID
        {
            get {  return this.id; }
        }
        public DateTime DateOfBirth
        { 
            get { return this.dateOfBirth; } 
        }
        public string PhoneNumber
        {
            get { return this.phoneNumber; }
        }
        public List<Feedback> FeedbackHistory
        {
            get { return this.feedbackHistory; }
        }
        #endregion

        #region METHOD
        public void AddFeedback(Feedback feedback)
        {
            this.feedbackHistory.Add(feedback);
        }
        #endregion

        public virtual void OutputInformation() {}
    }
}
