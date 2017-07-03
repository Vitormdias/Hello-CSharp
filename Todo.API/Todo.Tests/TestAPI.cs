using System;
using Xunit;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Todo.API;
using Todo.Data;
using Todo.Model;
using Todo.Security;
using Todo.Business;
using Todo.Data.Repositories;
using Todo.API.Controllers;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;

namespace Todo.Tests
{
    public class TestAPI
    {
        private readonly HttpClient _client;
        private readonly TestServer _server;

        public TestAPI()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async void memberTest_Get()
        {
            //Act
            var getResponse = await _client.GetAsync("/api/member/");
            getResponse.EnsureSuccessStatusCode();

            //Assert
            Assert.True(getResponse.IsSuccessStatusCode);
            //Assert.True(true);
        }
    }
}
