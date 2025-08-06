using System;

namespace Hiky.Services;

public abstract class ServiceBase(IHttpClientFactory httpClientFactory)    
{
    public HttpClient HttpClient => httpClientFactory.CreateClient(Constants.DefaultHttpClient);   
}
