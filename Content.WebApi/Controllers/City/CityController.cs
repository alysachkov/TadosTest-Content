namespace Content.WebApi.Controllers.City
{
    using System.Threading.Tasks;
    using Actions.Create;
    using Actions.Edit;
    using Actions.Get;
    using Actions.GetList;
    using Api.Requests.Abstractions;
    using Api.Requests.Hierarchic.Abstractions;
    using AspnetCore.ApiControllers.Extensions;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using global::Persistence.Transactions.Behaviors;

    [ApiController]
    [Route("api/city")]
    public class CityController : ContentApiControllerBase
    {
        public CityController(
            IAsyncRequestBuilder asyncRequestBuilder,
            IAsyncHierarchicRequestBuilder asyncHierarchicRequestBuilder,
            IExpectCommit commitPerformer)
            : base(
                asyncRequestBuilder,
                asyncHierarchicRequestBuilder,
                commitPerformer)
        {
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(CityCreateResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Create(CityCreateRequest request) =>
            this.RequestAsync()
                .For<CityCreateResponse>()
                .With(request);

        [HttpPatch]
        [Route("edit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Edit(CityEditRequest request) =>
            this.RequestAsync(request);

        [HttpGet]
        [Route("get")]
        [ProducesResponseType(typeof(CityGetResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Get(CityGetRequest request)
            => this.RequestAsync()
                .For<CityGetResponse>()
                .With(request);

        [HttpGet]
        [Route("getList")]
        [ProducesResponseType(typeof(CityGetListResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Get(CityGetListRequest request) =>
            this.RequestAsync()
                .For<CityGetListResponse>()
                .With(request);
    }
}