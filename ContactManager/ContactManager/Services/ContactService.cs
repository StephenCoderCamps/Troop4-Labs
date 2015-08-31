using CoderCamps;
using ContactManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactManager.Services
{
    public class ContactService : ContactManager.Services.IContactService
    {
        private IGenericRepository _repo;

        public ContactService(IGenericRepository repo)
        {
            _repo = repo;

        }
    
        public IList<Contact> ListContacts()
        {
         return _repo.Query<Contact>().ToList();
        }
        
        public Contact FindContact(int id) 
        {
            return _repo.Find<Contact>(id);
        }
        public void CreateContact(Contact contact)
        {
            _repo.Add<Contact>(contact);
            _repo.SaveChanges();

        }
       

    }
}