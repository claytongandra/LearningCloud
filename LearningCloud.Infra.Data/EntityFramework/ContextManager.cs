using System.Web;
using System.Data.Entity;
using LearningCloud.Infra.Data.Context;

namespace LearningCloud.Infra.Data.EntityFramework
{
    public class ContextManager<TContext> where TContext : DbContext, new()
    {
        private string ContextKey = "ContextManager.Context";


        public ContextManager()
        {
            ContextKey = "ContextKey." + typeof(TContext).Name;
        }

        public DbContext GetContext
        {
            get
            {
                if (HttpContext.Current.Items[ContextKey] == null)
                {
                    HttpContext.Current.Items[ContextKey] = new TContext();
                }

                //return (LearningCloudContext)HttpContext.Current.Items[ContextKey];

                return HttpContext.Current.Items[ContextKey] as DbContext;
            }
        }
    }
}
