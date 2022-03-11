﻿using Microsoft.Extensions.Options;
using SkuVaultApiWrapper.Models;
using SkuVaultApiWrapper.RequestMethods;
using SkuVaultApiWrapper.Validators;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SkuVaultApiWrapper
{
	public class SkuVaultApiClient : ISkuVaultApiClient
	{
		internal HttpClient HttpClient;
		internal SkuVaultApiClientConfig ApiClientConfig;

		/// <summary>
		/// Constructor for use with injection (View ExampleConsoleApp to see pattern in use)
		/// </summary>
		public SkuVaultApiClient(HttpClient httpClient, IOptions<SkuVaultApiClientConfig> config)
		{
			var validator = new SkuVaultApiClientValidator();
			validator.ValidateOptions(httpClient, config.Value);

			HttpClient = httpClient;
			HttpClient.BaseAddress = new Uri("https://app.skuvault.com/");
			HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			ApiClientConfig = config.Value;
			return;
		}

		/// <summary>
		/// Optional method of sending a specific request/response object.
		/// </summary>
		/// <typeparam name="T">A Request model inheriting from the BaseRequestModel</typeparam>
		/// <typeparam name="D">A Response model inheriting from the BaseResponseModel</typeparam>
		public async Task<D> Post<T, D>(T request) where T : BaseRequestModel where D : BaseResponseModel
		{
			return await PostRequest.PostAsync<D>(this, request, request.Endpoint());
		}

		/// <summary>
		/// Optional method of sending a specific request object while receiving a json string response back.
		/// This is useful in the case that the response objects have changed.
		/// </summary>
		/// <typeparam name="T">A Request model inheriting from the BaseRequestModel</typeparam>
		public async Task<HttpResponseMessage> Post<T>(T request) where T : BaseRequestModel
		{
			return await PostRequest.PostAsync(this, request, request.Endpoint());
		}
	}
}
