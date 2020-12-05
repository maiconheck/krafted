using Krafted.Localization.Abstractions;
using Krafted.Rfc.ProblemDetails;
using Krafted.Rfc.ProblemDetails.Abstractions;
using Krafted.Rfc.ProblemDetails.Types;
using Xunit;

namespace Krafted.UnitTest.Krafted.Rfc.ProblemDetails
{
    [Trait(nameof(UnitTest), nameof(Rfc))]
    public class ResponseTest
    {
        private readonly ILocalizerService _localizerService;

        public ResponseTest()
        {
            _localizerService = new LocalizerServiceStub();

            Response.Configure(_localizerService);
            TitleOk.Configure(_localizerService);
        }

        [Fact]
        public void ResponseOk_Data_ProperReturned()
        {
            var data = new DtoDummy();
            SuccessResponse response = Response.Ok(data);

            Assert.Equal(data, response.Data);
            Assert.Equal(string.Empty, response.Detail);
            Assert.Equal(StatusCodes.Status200OK, response.Status);
            Assert.Equal(string.Empty, response.Title);
            Assert.Equal(ResponseType.Ok, response.Type);
        }

        [Fact]
        public void ResponseOk_TitleAndData_ProperReturned()
        {
            var data = new DtoDummy();
            SuccessResponse response1 = Response.Ok(new TitleOk("RowDelete", HttpMethod.Delete), data);

            Assert.Equal(data, response1.Data);
            Assert.Equal(string.Empty, response1.Detail);
            Assert.Equal(StatusCodes.Status200OK, response1.Status);
            Assert.Equal("RowDelete message.", response1.Title);
            Assert.Equal(ResponseType.Ok, response1.Type);

            SuccessResponse response2 = Response.Ok(new TitleOk("RowDelete", HttpMethod.Put), data);

            Assert.Equal(data, response2.Data);
            Assert.Equal("Please refer to the data property for additional details.", response2.Detail);
            Assert.Equal(StatusCodes.Status200OK, response2.Status);
            Assert.Equal("RowDelete message.", response2.Title);
            Assert.Equal(ResponseType.Ok, response2.Type);
        }

        [Fact]
        public void ResponseCreatedAtAction_MessageAndData_ProperReturned()
        {
            var data = new DtoDummy();
            SuccessResponse response = Response.CreatedAtAction("RowDelete", data);

            Assert.Equal(data, response.Data);
            Assert.Equal(string.Empty, response.Detail);
            Assert.Equal(StatusCodes.Status201Created, response.Status);
            Assert.Equal("RowDelete message.", response.Title);
            Assert.Equal(ResponseType.CreatedAtAction, response.Type);
        }

        [Fact]
        public void ResponseCreatedAtAction_MessageResourceNameAndData_ProperReturned()
        {
            var data = new DtoDummy();
            SuccessResponse response = Response.CreatedAtAction("RowDelete", "Customer", data);

            Assert.Equal(data, response.Data);
            Assert.Equal(string.Empty, response.Detail);
            Assert.Equal(StatusCodes.Status201Created, response.Status);
            Assert.Equal("RowDelete message.", response.Title);
            Assert.Equal(ResponseType.CreatedAtAction, response.Type);
        }

        [Fact]
        public void ResponseNotFound_ResourceNameAndId_ProperReturned()
        {
            FailResponse response = Response.NotFound("Customer", 5);

            Assert.Null(response.Data);
            Assert.Equal("Please refer to the errors property for additional details", response.Detail);
            Assert.Equal(StatusCodes.Status404NotFound, response.Status);
            Assert.Equal("Customer 5 does not exist.", response.Title);
            Assert.Equal(ResponseType.NotFound, response.Type);
        }

        [Fact]
        public void ResponseNotFound_ResourceName_ProperReturned()
        {
            FailResponse response = Response.NotFound("Customer");

            Assert.Null(response.Data);
            Assert.Equal("Please refer to the errors property for additional details", response.Detail);
            Assert.Equal(StatusCodes.Status404NotFound, response.Status);
            Assert.Equal("Customer does not exist.", response.Title);
            Assert.Equal(ResponseType.NotFound, response.Type);
        }

        [Fact]
        public void ResponseBadRequest_ProperReturned()
        {
            FailResponse response = Response.BadRequest();

            Assert.Null(response.Data);
            Assert.Equal("Please refer to the errors property for additional details", response.Detail);
            Assert.Equal(StatusCodes.Status400BadRequest, response.Status);
            Assert.Equal("One or more validation errors occurred.", response.Title);
            Assert.Equal(ResponseType.BadRequest, response.Type);
        }
    }
}
