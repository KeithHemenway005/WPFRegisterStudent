using System;

namespace WPFRegisterStudent
{
    class Course
    {
        private string name;
        private const Int16 credit_hours = 3;
        private bool isRegisteredAlready = false;

        public Course()
        {
            this.name = "";
        }

        public Course (string name)
        {
            this.name = name;
        }

        public string Name
        {
            get
            {
                // TODO: here we could check a security rule
                // to see if the user has access to this information
                return this.name;
            }
            set
            {
                // TODO: Here we could check a validation rule to see
                // if the user is attempting to set the name to an invalid
                // value or to attempt to set it with some malicious scripting code
                this.name = value;
            }
        }

        public bool IsRegisteredAlready
        {
            get { return this.isRegisteredAlready; }
            set { this.isRegisteredAlready = value; }   
        }

        public void SetToRegistered()
        {
            isRegisteredAlready = true;
        }
        public Int16 Credit_hours
        {
            get { return credit_hours; }
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
