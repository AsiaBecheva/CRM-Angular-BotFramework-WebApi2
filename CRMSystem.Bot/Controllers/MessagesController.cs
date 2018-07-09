using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Autofac;
using CRMSystem.Bot.Dialogs;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Internals;
using Microsoft.Bot.Connector;

namespace CRMSystem.Bot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.ConversationUpdate)
            {
                IConversationUpdateActivity update = activity;
                using (var scope = DialogModule.BeginLifetimeScope(Conversation.Container, activity))
                {
                    var client = scope.Resolve<IConnectorClient>();
                    if (update.MembersAdded.Any())
                    {
                        foreach (var newMember in update.MembersAdded)
                        {
                            if (newMember.Id != activity.Recipient.Id)
                            {
                                //var reply = activity.CreateReply();
                                //reply.Text = $"Hello {newMember.Name}!";
                                //await client.Conversations.ReplyToActivityAsync(reply);
                            }
                        }
                    }
                }
            }
            if (activity.Type == ActivityTypes.Message)
            {
                await Conversation.SendAsync(activity, MakeRootDialog);
            }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            //else if (message.Type == ActivityTypes.ConversationUpdate)
            //{
            //    if (message is IConversationUpdateActivity iConversationUpdated)
            //    {
            //        ConnectorClient connector = new ConnectorClient(new System.Uri(message.ServiceUrl));

            //        foreach (var member in iConversationUpdated.MembersAdded ?? System.Array.Empty<ChannelAccount>())
            //        {
            //            // if the bot is added, then
            //            if (member.Id == iConversationUpdated.Recipient.Id)
            //            {

            //                var reply = ((Activity)iConversationUpdated).CreateReply(
            //                    $"Hi! I'm Botty.");
            //                await connector.Conversations.ReplyToActivityAsync(reply);
            //            }
            //        }
            //    }
            //}
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }

        internal static IDialog<object> MakeRootDialog()
        {
            return Chain.From(() => new LUISDialog());
        }
    }
}