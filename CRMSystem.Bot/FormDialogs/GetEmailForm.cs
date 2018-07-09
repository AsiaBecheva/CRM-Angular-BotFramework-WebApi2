using System;
using System.Linq;
using System.Threading.Tasks;
using CRMSystem.Bot.Common;
using CRMSystem.Bot.FormDialogs.Base;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;

namespace CRMSystem.Bot.FormDialogs
{
    [Serializable]
    public class GetEmailForm : BaseForm<GetEmailForm>
    {
        [Prompt("Please enter Username for email.")]
        public string ClientName { get; set; }

        public override IForm<GetEmailForm> BuildForm()
        {

            async Task onProcessGetEmail(IDialogContext context, GetEmailForm state)
            {
                var customer = GetDatabase.GetContext().Customers.Where(c => c.Username == state.ClientName)
                .FirstOrDefault();

                var id = customer.Id;
                var email = customer.Email;
                await context.PostAsync($"Client with ID: {id};" + $" Email: {email}");
            }

            return new FormBuilder<GetEmailForm>()
                .Field(nameof(ClientName))
                .OnCompletion(onProcessGetEmail)
                .Build();
        }
    }
}