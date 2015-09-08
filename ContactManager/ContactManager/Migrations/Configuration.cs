namespace ContactManager.Migrations
{
    using ContactManager.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ContactManager.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ContactManager.Models.ApplicationDbContext context)
        {
            var contacts = new Contact[]
            {
                new Contact{FirstName= "Jay", LastName="Schultz",PhoneNumber="111-222-3333", FavColor="green"},
                new Contact{FirstName= "Jake", LastName="Lee",PhoneNumber="222-333-3333", FavColor="Purple"},
                new Contact{FirstName= "Stephen", LastName="Walther",PhoneNumber="444-222-3333", FavColor="Green"}
            };
            context.Contacts.AddOrUpdate(c => c.FirstName, contacts);
        }
    }
}
