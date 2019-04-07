using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using reservations_data.Models;
using reservations_tests.IntegrationTests.Model;
using reservations_web;
using Xunit;

namespace reservations_tests.IntegrationTests.Tests
{
    public class TestIntegration
    {
        private readonly HttpClient _client;
 
        public TestIntegration()
        {
            TestsWebFactory<Startup> factory = new TestsWebFactory<Startup>();
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        [Fact]
        public void TestRooms()
        {
            var response = _client.GetAsync("/api/rooms/?date=" + DateTime.Today.ToString("dd.MM.yyyy")).Result;
            response.EnsureSuccessStatusCode();
 
            //Please don't force me to actually validate the json...
            string responseString = response.Content.ReadAsStringAsync().Result;
 
            foreach (Room room in TestDbInitializer.GetTestRooms())
            {
                Assert.Contains(room.Name, responseString);
            }
        }
    }
}