using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRMSystem.Bot.Common;
using CRMSystem.Bot.FormDialogs.Base;
using CRMSystem.Models;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;

namespace CRMSystem.Bot.FormDialogs
{
    [Serializable]
    public class GetInfoForm : BaseForm<GetInfoForm>
    {
        [Prompt("Please enter Username for information.")]
        public string ClientName { get; set; }

        public override IForm<GetInfoForm> BuildForm()
        {
            async Task onProcessGetInfo(IDialogContext context, GetInfoForm state)
            {
                var customer = GetDatabase.GetContext().Customers.Where(c => c.Username == state.ClientName)
                 .FirstOrDefault();

                StringBuilder sb = new StringBuilder();

                var id = customer.Id;
                var username = customer.Username;
                var company = customer.Company;
                var firstName = customer.FirstName;
                var lastName = customer.LastName;
                var address = customer.Address;
                var phone = customer.Phone;
                var email = customer.Email;
                DateTime addedOn = customer.AddedOn;
                var status = customer.Status;

                sb.AppendLine($"ID: {id};  ");
                sb.AppendLine($"Username: {username};   ");
                sb.AppendLine($"Company: {company};   ");
                sb.AppendLine($"Name: {firstName + " " + lastName};   ");
                sb.AppendLine($"Address: {address};   ");
                sb.AppendLine($"Phone: {phone};  ");
                sb.AppendLine($"Email: {email};  ");
                sb.AppendLine($"Added On: {addedOn};  ");
                sb.AppendLine($"Status: {status};  ");

                var customerProducts = GetDatabase.GetContext().CustomerProducts.ToList();

                var salProd = customerProducts.Where(p => p.CustomerId == customer.Id).ToList();

                var products = GetProducts(customer);

                for (int i = 0; i < products.Count; i++)
                {
                    sb.AppendLine($"Product {i + 1}: {products[i].Name}.    ");
                }


                await context.PostAsync(sb.ToString());
            }

            return new FormBuilder<GetInfoForm>()
               .Field(nameof(ClientName))
               .OnCompletion(onProcessGetInfo)
               .Build();
        }

        private List<Product> GetProducts(Customer customer)
        {
            var products = GetDatabase.GetContext().Customers
                    .Where(c => c.Id == customer.Id)
                    .SelectMany(c => c.SalledProducts)
                    .Select(cp => cp.Product)
                    .ToList();

            return products;
        }
    }
}