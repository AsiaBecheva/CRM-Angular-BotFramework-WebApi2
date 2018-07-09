using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using CRMSystem.Bot.Common;
using CRMSystem.Bot.FormDialogs.Base;
using CRMSystem.Data.Repository;
using CRMSystem.Models;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;

namespace CRMSystem.Bot.FormDialogs
{
    [Serializable]
    public class AddCustomerForm : BaseForm<AddCustomerForm>
    {
        [MaxLength(100)]
        [Prompt("Please enter Company")]
        public string Company { get; set; }

        [Required]
        [MaxLength(100)]
        [Prompt("Please enter Username")]
        public string Username { get; set; }

        [MaxLength(100)]
        [Prompt("Please enter First name.")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        [Prompt("Please enter Last name")]
        public string LastName { get; set; }

        [MaxLength(100)]
        [Prompt("Please enter Address.")]
        public string Address { get; set; }

        [MaxLength(100)]
        [Prompt("Please enter City.")]
        public string City { get; set; }

        [Prompt("Please enter Client Status.")]
        public Status Status { get; set; }

        [MaxLength(20)]
        [Prompt("Please enter Client phone number.")]
        public string Phone { get; set; }

        [MaxLength(40)]
        [Prompt("Please enter Client Email.")]
        public string Email { get; set; }

        public override IForm<AddCustomerForm> BuildForm()
        {

            async Task onProcessAddCustomer(IDialogContext context, AddCustomerForm state)
            {
                GenericRepository<Customer> db = new GenericRepository<Customer>(GetDatabase.GetContext());

                Customer customer = new Customer
                {
                    Company = state.Company,
                    FirstName = state.FirstName,
                    LastName = state.LastName,
                    Address = state.Address,
                    Username = state.Username,
                    Phone = state.Phone,
                    Status = state.Status,
                    Email = state.Email,
                    AddedOn = DateTime.Now
                };

                db.Add(customer);
                db.SaveChanges();
            }

            return new FormBuilder<AddCustomerForm>()
                .Field(nameof(Username))
                .Field(nameof(Company))
                .Field(nameof(FirstName))
                .Field(nameof(LastName))
                .Field(nameof(Address))
                .Field(nameof(Phone))
                .Field(nameof(Email))
                .Field(nameof(Status))
                .OnCompletion(onProcessAddCustomer)
                .Build();
        }

    }
}