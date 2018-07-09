using Microsoft.Bot.Builder.FormFlow;

namespace CRMSystem.Bot.FormDialogs.Base
{
    public interface IBaseForm<T> where T : class
    {
        IForm<T> BuildForm();
    }
}