using System;
namespace ContactManager.Services
{
   public interface IContactService
    {
        void CreateContact(ContactManager.Models.Contact contact);
        ContactManager.Models.Contact FindContact(int id);
        System.Collections.Generic.IList<ContactManager.Models.Contact> ListContacts();
    }
}
