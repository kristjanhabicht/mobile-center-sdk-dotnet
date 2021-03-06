﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.Azure.Mobile.Ingestion.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Azure.Mobile.Test.Windows.Ingestion.Http
{
    [TestClass]
    public class HttpNetworkAdapterTest
    {
        private readonly HttpNetworkAdapter _adapter = new HttpNetworkAdapter();

        /// <summary>
        /// Verify that adapter create request correctly.
        /// </summary>
        [TestMethod]
        public void CreateRequest()
        {
            var uri = "https://test";
            var appSecret = Guid.NewGuid().ToString();
            var installId = Guid.NewGuid().ToString();
            var headers = new Dictionary<string, string>
            {
                { IngestionHttp.AppSecret, appSecret },
                { IngestionHttp.InstallId, installId }
            };
            var jsonContent = "{}";
            var request = _adapter.CreateRequest(uri, HttpMethod.Post, headers, jsonContent);

            Assert.AreEqual(request.Method, HttpMethod.Post);
            Assert.IsTrue(request.Headers.Contains(IngestionHttp.AppSecret));
            Assert.IsTrue(request.Headers.Contains(IngestionHttp.InstallId));
            Assert.IsInstanceOfType(request.Content, typeof(StringContent));
        }
    }
}
