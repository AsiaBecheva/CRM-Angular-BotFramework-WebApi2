using System;
using Microsoft.Bot.Builder.FormFlow;

namespace CRMSystem.Bot.FormDialogs.Base
{
    [Serializable]
    public abstract class BaseForm<T> : IBaseForm<T> where T : class
    {
        public abstract IForm<T> BuildForm();
    }
}