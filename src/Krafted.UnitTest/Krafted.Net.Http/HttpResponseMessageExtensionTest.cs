using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Krafted.Net.Http;
using Xunit;
using Assert = Krafted.Test.UnitTest.Xunit.AssertExtension;

namespace Krafted.UnitTest.Krafted.Net.Http
{
    [Trait(nameof(UnitTest), nameof(Http))]
    public class HttpResponseMessageExtensionTest
    {
        [Fact]
        public void EnsureContentType_DefaultContentType_DoesNotThrowsException()
        {
            var response1 = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(string.Empty, Encoding.UTF8, "application/json") };
            Assert.DoesNotThrows(() => response1.EnsureContentType());

            var response2 = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(string.Empty, Encoding.ASCII, "text/html") };
            Assert.DoesNotThrows(() => response2.EnsureContentType("text/html; charset=us-ascii"));
        }

        [Theory]
        [InlineData("ASCII", "application/json")]
        [InlineData("UTF-8", "text/html")]
        public void EnsureContentType_NotUtf8ApplicationJson_ThrowsException(string encoding, string mediaType)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(string.Empty, Encoding.GetEncoding(encoding), mediaType)
            };

            Assert.Throws<HttpRequestException>(() => response.EnsureContentType());
        }

        [Fact]
        public async Task DeserializeAsync_SuccessResponseContent_DeserializedAsync()
        {
            var content = @"{
	            'data':{'id':'fa2e01ff-6d76-422a-ab9e-a002b5bef66d','name':'teste','amount':1250.12,'active':true,'icon':0},
                'success':true,
	            'failure':false,
	            'message':'Conta teste criada com sucesso.'
            }";

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(content, Encoding.GetEncoding("UTF-8"), "application/json")
            };

            var result = await response.DeserializeAsync().ConfigureAwait(false);

            Assert.True(result.Success);
            Assert.Equal("fa2e01ff-6d76-422a-ab9e-a002b5bef66d", result.Id.ToString());
            Assert.Equal("Conta teste criada com sucesso.", result.Message);
        }

        [Fact]
        public async Task DeserializeAsync_FailureResponseContent_DeserializedAsync()
        {
            var content = @"{
	            'data':[
		            {'property':'Name','message':'Informe a conta.'}
	            ],
	            'success':false,
	            'failure':true,
	            'message':'Erro ao executar a requisição. Verifique a lista de notificações.'
            }";

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(content, Encoding.GetEncoding("UTF-8"), "application/json")
            };

            var result = await response.DeserializeAsync().ConfigureAwait(false);

            var notification = result.Data.First();

            Assert.True(result.Failure);
            Assert.Equal("Erro ao executar a requisição. Verifique a lista de notificações.", result.Message);
            Assert.Equal("Name", notification.Property);
            Assert.Equal("Informe a conta.", notification.Message);
        }

        [Fact]
        public async Task DeserializeDeleteAsync_SuccessResponseContent_DeserializedAsync()
        {
            var content = @"{'success':true, 'message':'Conta teste deletada com sucesso.'}";
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(content, Encoding.GetEncoding("UTF-8"), "application/json")
            };

            var result = await response.DeserializeDeleteAsync().ConfigureAwait(false);

            Assert.True(result.Success);
            Assert.Equal("Conta teste deletada com sucesso.", result.Message);
        }

        [Fact]
        public async Task DeserializeAnonymousTypeAsync_AnonymousTypeContent_DeserializedAsync()
        {
            var content = @"{
	            'data':
                {
                    'id':'fa2e01ff-6d76-422a-ab9e-a002b5bef66d',
                    'name':'teste',
                    'amount':1250.12,
                    'active':true,
                    'icon':3
                },
                'success':true,
	            'failure':false,
	            'message':'Conta teste criada com sucesso.'
            }";

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(content, Encoding.GetEncoding("UTF-8"), "application/json")
            };

            var result = await response.DeserializeAnonymousTypeAsync(new
            {
                Data = new
                {
                    Id = default(string),
                    Name = default(string),
                    Amount = default(decimal),
                    Active = default(bool),
                    Icon = default(int),
                },
                Success = default(bool),
                Failure = default(bool),
                Message = default(string)
            }).ConfigureAwait(false);

            Assert.Equal("fa2e01ff-6d76-422a-ab9e-a002b5bef66d", result.Data.Id);
            Assert.Equal("teste", result.Data.Name);
            Assert.Equal(1250.12m, result.Data.Amount);
            Assert.True(result.Data.Active);
            Assert.Equal(3, result.Data.Icon);
            Assert.True(result.Success);
            Assert.False(result.Failure);
            Assert.Equal("Conta teste criada com sucesso.", result.Message);
        }
    }
}