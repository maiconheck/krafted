using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Krafted.Api;
using Krafted.IntegrationTest.FooBar.Application;
using Krafted.IntegrationTest.FooBar.Domain;
using Krafted.Test;
using Xunit;

namespace Krafted.IntegrationTest.FooBar
{
    [Trait(nameof(IntegrationTest), nameof(Foo))]
    public partial class FooControllerTest : IntegrationTest<Startup>, IClassFixture<ProviderStateApiFactory<Startup>>
    {
        public FooControllerTest(ProviderStateApiFactory<Startup> factory)
            : base(factory, "http://localhost:5001/api/v1")
        {
        }

        [Fact]
        public async Task GetById_ExistentId_SuccessAndCorrectContentType()
        {
            var createResponse = await CreateAsync();
            var result = await DeserializeResponseAsync(createResponse);

            var response = await Client.GetAsync($"{EndPoint}/foo/{result.Id}");

            EnsureSuccessStatusCode(response);
            Assert.Equal(CorrectContentType, response.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public async Task GetAll_SuccessAndCorrectContentType()
        {
            var createResponse = await CreateAsync();
            var result = await DeserializeResponseAsync(createResponse);

            var response = await Client.GetAsync($"{EndPoint}/foo");

            EnsureSuccessStatusCode(response);
            Assert.Equal(CorrectContentType, response.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public async Task Post_SuccessAndCorrectContentType()
        {
            var createResponse = await CreateAsync();
            var result = await DeserializeResponseAsync(createResponse);

            EnsureSuccessStatusCode(createResponse);
            Assert.Equal(CorrectContentType, createResponse.Content.Headers.ContentType.ToString());
            Assert.Equal("Foo criado com sucesso.", result.Message);
            Assert.True(result.Success);
        }

        [Fact]
        public async Task Post_FailAndCorrectContentType()
        {
            var createResponse = await CreateAsync(nameof(Foo), new DateTime(1970, 1, 1), new DateTime(1970, 1, 1));
            var result = await DeserializeDeleteResponseAsync(createResponse);

            EnsureSuccessStatusCode(createResponse);
            Assert.Equal(CorrectContentType, createResponse.Content.Headers.ContentType.ToString());
            Assert.Equal("Falha ao criar o registro. Verifique as mensagens de erro.", result.Message);
            Assert.False(result.Success);
        }

        [Fact]
        public async Task Put_ExistentId_SuccessAndCorrectContentType()
        {
            var createResponse = await CreateAsync("Foo 2");
            var result = await DeserializeResponseAsync(createResponse);

            var command = new ChangeScheduleFooCommand
            {
                StartDate = new DateTime(2017, 10, 01),
                EndDate = new DateTime(2018, 12, 20),
            };

            var response = await Client.PutAsync($"{EndPoint}/foo/{result.Id}", command, new JsonMediaTypeFormatter());
            var resultPut = await DeserializeResponseAsync(response);

            EnsureSuccessStatusCode(response);
            Assert.Equal(CorrectContentType, response.Content.Headers.ContentType.ToString());
            Assert.Equal("Foo Foo 2 atualizado com sucesso.", resultPut.Message);
            Assert.True(resultPut.Success);
        }

        [Fact]
        public async Task Delete_ExistentId_SuccessAndCorrectContentType()
        {
            var createResponse = await CreateAsync();
            var result = await DeserializeResponseAsync(createResponse);

            var response = await Client.DeleteAsync($"{EndPoint}/foo/{result.Id}");
            var resultDelete = await DeserializeDeleteResponseAsync(response);

            Assert.Equal("Foo Foo 1 excluido com sucesso.", resultDelete.Message);
            Assert.True(resultDelete.Success);
        }

        [Fact]
        public async Task Delete_NonExistentId_SuccessAndCorrectContentType()
        {
            var response = await Client.DeleteAsync($"{EndPoint}/foo/{Guid.NewGuid()}");
            var result = await DeserializeDeleteResponseAsync(response);

            EnsureSuccessStatusCode(response);
            Assert.Equal(CorrectContentType, response.Content.Headers.ContentType.ToString());
            Assert.Equal("Registro não encontrado.", result.Message);
            Assert.False(result.Success);
        }

        private async Task<HttpResponseMessage> CreateAsync(string name = "Foo 1", DateTime? startDate = null, DateTime? endDate = null)
        {
            var command = new CreateFooCommand
            {
                StartDate = startDate ?? new DateTime(2018, 11, 12),
                EndDate = endDate ?? new DateTime(2018, 11, 16),
                Name = name
            };

            return await Client.PostAsync($"{EndPoint}/foo", command, new JsonMediaTypeFormatter());
        }
    }
}