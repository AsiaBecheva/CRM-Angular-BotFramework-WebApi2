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
    public class GetStatusForm : BaseForm<GetStatusForm>
    {
        [Prompt("Please enter Username for status")]
        public string ClientName { get; set; }

        public override IForm<GetStatusForm> BuildForm()
        {
            async Task onProcessGetStatus(IDialogContext context, GetStatusForm state)
            {
                var customer = GetDatabase.GetContext().Customers.Where(c => c.Username == state.ClientName)
                .FirstOrDefault();

                var id = customer.Id;
                var status = customer.Status;
                await context.PostAsync($"Client with ID: {id};" + $" Status: {status}");
            }

            return new FormBuilder<GetStatusForm>()
                .Field(nameof(ClientName))
                .OnCompletion(onProcessGetStatus)
                .Build();
        }
    }
}