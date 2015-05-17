using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using Willowsoft.WillowLib.Data.Entity;
using Willowsoft.WillowLib.Data.Misc;
using Willowsoft.Ordering.Core.Entities;
using Willowsoft.Ordering.Core.Repositories;

namespace Willowsoft.Ordering.UI.Reports
{
    public abstract class OrderReportWriter : ReportWriterBase, IOrderReportWriter
    {
        private string mTitle;
        private PurOrder mOrder;
        private Vendor mVendor;
        
        #region IOrderReportWriter Members

        public void Init(string title, PurOrder order, Vendor vendor, TextWriter textWriter)
        {
            mTitle = title;
            mOrder = order;
            mVendor = vendor;
            Init(textWriter);
        }

        protected PurOrder Order
        {
            get { return mOrder; }
        }

        protected Vendor Vendor
        {
            get { return mVendor; }
        }

        public virtual void StartBody()
        {
            WriteLine("<h2>");
            WriteLine(mTitle);
            WriteLine("</h2>");
            WriteLine("<table border='0'><tr><td valign='top'>");
            WriteLine("<table border='0' cellpadding='2'>");
            StartBodyOurCompany();
            WriteLine("</table>");
            WriteLine("</td><td style='width: 1.0in;'></td><td valign='top'>");
            WriteLine("<table border='0' cellpadding='2'>");
            StartBodyDetails();
            WriteLine("</table>");
            WriteLine("</td></tr></table><br><br>");
        }

        protected abstract void StartBodyDetails();

        protected void StartBodyOurCompany()
        {
            StartBodyDetail("Customer:", ConfigurationSettings.AppSettings["CompanyName"]);
            StartBodyDetail("", ConfigurationSettings.AppSettings["CompanyAddress"]);
            StartBodyDetail("", ConfigurationSettings.AppSettings["CompanyCityStateZip"]);
            StartBodyDetail("", ConfigurationSettings.AppSettings["CompanyPhone"] + " (phone)");
            StartBodyDetail("", ConfigurationSettings.AppSettings["CompanyFax"] + " (fax)");
            StartBodyDetail("", ConfigurationSettings.AppSettings["CompanyEmail"]);
        }

        protected void StartBodyVendor(Vendor vendor)
        {
            StartBodyDetail("Vendor:", Vendor.VendorName);
            if (!string.IsNullOrEmpty(Vendor.Notes))
                StartBodyDetail("Notes:", Vendor.Notes);
            StartBodyContact(vendor.RepContactId, "Sales:");
            StartBodyContact(vendor.OrdContactId, "Orders:");
            StartBodyContact(vendor.ShpContactId, "Shipping:");
        }

        protected void StartBodyContact(ContactId contactId, string contactType)
        {
            if (contactId.IsNull)
                return;
            Contact contact;
            using (Ambient.DbSession.Activate())
            {
                contact = OrderingRepositories.Contact.Get(contactId);
            }
            StartBodyDetail(contactType, contact.ContactName);
            if (!string.IsNullOrEmpty(contact.PhoneNumber))
                StartBodyDetail("", contact.PhoneNumber);
            if (!string.IsNullOrEmpty(contact.CellNumber))
                StartBodyDetail("", contact.CellNumber + " (cell)");
            if (!string.IsNullOrEmpty(contact.FaxNumber))
                StartBodyDetail("", contact.FaxNumber + " (fax)");
            if (!string.IsNullOrEmpty(contact.EmailAddress))
                StartBodyDetail("", contact.EmailAddress);
        }

        protected void StartBodyDetail(string label, string value)
        {
            WriteLine("<tr>");
            WriteLine("<td><span style='font-size: 10pt; font-weight: bold;'>" + label + "</span></td>");
            WriteLine("<td><span style='font-size: 10pt; font-weight: bold;'>" + value + "</span></td>");
            WriteLine("</tr>");
        }

        public abstract void OutputTableHeader();

        public abstract void OutputLine(JoinPlToVpToProd line);

        #endregion
    }
}
