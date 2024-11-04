namespace Content.WebApi.Controllers.Content.Actions.Edit
{
    using System.Threading.Tasks;
    using Api.Requests.Hierarchic.Abstractions;

    public abstract class ContentEditHierarchicRequestHandler<TConcreteContentHierarchicRequest> : AsyncHierarchicRequestHandlerBase<TConcreteContentHierarchicRequest>
        where TConcreteContentHierarchicRequest : ContentEditHierarchicRequest
    {

        protected ContentEditHierarchicRequestHandler()
        {
        }

        protected override async Task ExecuteAsync(TConcreteContentHierarchicRequest request)
        {
            await EditContentAsync(
                name: request.Name?.Trim(),
                request: request);
        }

        protected abstract Task EditContentAsync(
            string name,
            TConcreteContentHierarchicRequest request);
    }
}