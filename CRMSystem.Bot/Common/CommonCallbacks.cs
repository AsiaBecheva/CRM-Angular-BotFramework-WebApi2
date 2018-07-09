using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;

namespace CRMSystem.Bot.Common
{
    [Serializable]
    public class CommonCallbacks : LuisDialog<object>
    {
        public async Task CallbackGlobal<T>(IDialogContext context, IAwaitable<T> result)
        {
            await context.PostAsync("May I help you with something else?");
            context.Wait(MessageReceived);
            context.Done("");
        }
    }
}