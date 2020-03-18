using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
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
        public void DeserializeAsync_SuccessResponseContent_Deserialized()
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

            var result = response.DeserializeAsync().Result;

            Assert.True(result.Success);
            Assert.Equal("fa2e01ff-6d76-422a-ab9e-a002b5bef66d", result.Id.ToString());
            Assert.Equal("Conta teste criada com sucesso.", result.Message);
        }

        [Fact]
        public void DeserializeAsync_FailureResponseContent_Deserialized()
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

            var result = response.DeserializeAsync().Result;

            var notification = result.Data.First();

            Assert.True(result.Failure);
            Assert.Equal("Erro ao executar a requisição. Verifique a lista de notificações.", result.Message);
            Assert.Equal("Name", notification.Property);
            Assert.Equal("Informe a conta.", notification.Message);
        }

        [Fact]
        public void DeserializeDeleteAsync_SuccessResponseContent_Deserialized()
        {
            var content = @"{'success':true, 'message':'Conta teste deletada com sucesso.'}";
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(content, Encoding.GetEncoding("UTF-8"), "application/json")
            };

            var result = response.DeserializeDeleteAsync().Result;

            Assert.True(result.Success);
            Assert.Equal("Conta teste deletada com sucesso.", result.Message);
        }
    }
}