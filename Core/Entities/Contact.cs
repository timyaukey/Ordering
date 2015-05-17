using System;
using System.Collections.Generic;
using System.Text;
using Willowsoft.WillowLib.Data.Entity;
using Willowsoft.Ordering.Core.Repositories;
using Willowsoft.WillowLib.Data.Misc;

namespace Willowsoft.Ordering.Core.Entities
{
    public partial class Contact
    {
        public override void Validate(ErrorList errors)
        {
            base.Validate(errors);
            ValidateLength(mFirstName, errors, 1, 60, "First name");
            ValidateLength(mInitial, errors, 0, 1, "Initial");
            ValidateLength(mLastName, errors, 1, 60, "Last name");
            ValidateLength(mStreet1, errors, 0, 60, "Address line 1");
            ValidateLength(mStreet2, errors, 0, 60, "Address line 2");
            ValidateLength(mCity, errors, 0, 60, "City");
            ValidateLength(mStateProvince, errors, 0, 10, "State/province");
            ValidateLength(mPostalCode, errors, 0, 12, "Zip/postal code");
            ValidateLength(mCountry, errors, 0, 10, "Country");
            ValidateLength(mPhoneNumber, errors, 0, 25, "Phone number");
            ValidateLength(mCellNumber, errors, 0, 25, "Cell number");
            ValidateLength(mFaxNumber, errors, 0, 25, "Fax number");
            ValidateLength(mEmailAddress, errors, 0, 60, "Email address");
            ValidateLength(mNotes, errors, 0, 2048, "Notes");
        }

        public string ContactName
        {
            get { return ToString(); }
        }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }

    public class ContactBindingList : EntityBindingList<Contact, ContactId>
    {
        public ContactBindingList()
            : base(Ambient.DbSession, OrderingRepositories.Contact)
        {
        }

        public override string EntityDisplayName
        {
            get { return "contact"; }
        }
    }
}
