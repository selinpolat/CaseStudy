using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System.Net;
using System.Threading.Tasks;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace CaseMockAPI
{
    public class Tests
    {
        private WireMockServer server;

        [SetUp]
        public void StartServer()
        {
            server = WireMockServer.Start(9090);
        }

        private void CreateProdutsStub()
        {

            server.Given(
                Request.Create().WithPath("/products").UsingGet()
            )
            .RespondWith(
                Response.Create()
                    .WithStatusCode(200)
                    .WithHeader("Content-Type", "application/json").WithBody(@"{
                                                                                ""getProducts"": [
                                                                                {
                                                                                    ""id"": 1,
                                                                                    ""title"": ""Hepsi Home Pasta Tekli Sarkıt Avize Ahşap"",
                                                                                    ""description"": ""Avize"",
                                                                                    ""price"": 110,
                                                                                    ""isBasketDiscount"": true,
                                                                                    ""basketDiscountPercentage"": 4,
                                                                                    ""rating"": 2.19,
                                                                                    ""stock"": 1,
                                                                                    ""isActive"": false,
                                                                                    ""brand"": ""Apple"",
                                                                                    ""category"": ""ipad"",
                                                                                    ""images"": [
                                                                                    ""https://productimages.hepsiburada.net/s/4/500/9655454531634.jpg"",
                                                                                    ""https://productimages.hepsiburada.net/s/58/1100/11339580801074.jpg/format:webp""
                                                                                    ]
                                                                                },
                                                                                {
                                                                                    ""id"": 2,
                                                                                    ""title"": ""Apple iPhone 12 64 GB"",
                                                                                    ""description"": ""Apple"",
                                                                                    ""price"": 15000,
                                                                                    ""isBasketDiscount"": false,
                                                                                    ""rating"": 3.2,
                                                                                    ""stock"": 2000,
                                                                                    ""brand"": ""Apple"",
                                                                                    ""category"": ""smartphones"",
                                                                                    ""images"": [
                                                                                    ""https://productimages.hepsiburada.net/s/76/1500/110000018213454.jpg""
                                                                                    ]
                                                                                }
                                                                                ]
                                                                            }")

            );
        }

        [TearDown]
        public void StopServer()
        {
            server.Stop();
        }

        private RestClient client;

        [Test]
        public async Task TestGetProductsStubs()
        {
            CreateProdutsStub();


            client = new RestClient("http://localhost:9090");

            RestRequest request = new RestRequest("/products", Method.Get);


            RestResponse response = await client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.ContentType, Is.EqualTo("application/json"));
            Assert.That(response.Content, Is.Not.Null);
            dynamic data = JsonConvert.DeserializeObject(response.Content);
            Assert.That(data, Is.Not.Null);
            Assert.That(data.getProducts.Count, Is.EqualTo(2));
        }
    }
}