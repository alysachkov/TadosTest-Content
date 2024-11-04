namespace Content.WebApi.Controllers.Country
{
    using System;
    using System.Threading.Tasks;
    using Actions.Create;
    using Actions.Edit;
    using Actions.Get;
    using Actions.GetList;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using AspnetCore.ApiControllers.Extensions;
    using Api.Requests.Abstractions;
    using Api.Requests.Hierarchic.Abstractions;
    using global::Persistence.Transactions.Behaviors;

    [ApiController]
    [Route("api/country")]
    public class CountryController : ContentApiControllerBase
    {
        public CountryController(
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
        [ProducesResponseType(typeof(CountryCreateResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Create(CountryCreateRequest request) =>
            this.RequestAsync()
                .For<CountryCreateResponse>()
                .With(request);

        [HttpPatch]
        [Route("edit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Edit(CountryEditRequest request) =>
            this.RequestAsync(request);

        [HttpGet]
        [Route("get")]
        [ProducesResponseType(typeof(CountryGetResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Get(CountryGetRequest request) =>
            this.RequestAsync()
                .For<CountryGetResponse>()
                .With(request);

        [HttpGet]
        [Route("getList")]
        [ProducesResponseType(typeof(CountryGetListResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Get(CountryGetListRequest request) =>
            this.RequestAsync()
                .For<CountryGetListResponse>()
                .With(request);
    }
}