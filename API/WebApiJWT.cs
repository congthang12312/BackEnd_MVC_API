using API.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.Results;

namespace API
{
    public class WebApiJWT : AuthorizeAttribute, IAuthenticationFilter
    {

        public bool AllowMultiple {
            get { return false; }
        }

        string role;
        string roleJWT;

        public WebApiJWT(string role = "user")
        {
            this.role = role;
        }

        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            string authParameter = string.Empty;
            HttpRequestMessage request = context.Request;
            AuthenticationHeaderValue authorization = request.Headers.Authorization;
            if (authorization == null)
            {
                context.ErrorResult = new AuthenticationFailResult(reasonPhrase: "Miss Authorization Header", request);
            }
            else {
                if (String.Equals(this.role, "ADMIN") == true)
                {
                    ClaimsPrincipal userToken = TokenManager.GetPrincipal(authorization.Parameter);

                    Debug.WriteLine("authorization.Parameter   " + authorization.Parameter);

                    if (userToken != null)
                    {
                        if (Int32.Parse(userToken.FindFirst("ROLE").Value) == 0)
                        {
                            context.Principal = userToken;
                        }
                    }
                    else {
                        context.ErrorResult = new AuthenticationFailResult(reasonPhrase: "Miss Authorization Header", request);
                    }
                }
                // context.ErrorResult = new AuthenticationFailResult(reasonPhrase: "Missing token", request);
            }



            //     if(authorization.Scheme != "Bearer")
            //   {
            //        context.ErrorResult = new AuthenticationFailResult(reasonPhrase: "Invalid Authorization Header", request);
            //   }

            // if(String.IsNullOrEmpty(authorization.Parameter))
            //     {
            //        context.ErrorResult = new AuthenticationFailResult(reasonPhrase: "Missing token", request);
            //    }


        }

        public async Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            Debug.WriteLine("authen 2");
            var result = await context.Result.ExecuteAsync(cancellationToken);
            Debug.WriteLine("authen 2 - 1");
            if (result.StatusCode == HttpStatusCode.Unauthorized)
            {
                Debug.WriteLine("authen 2 - 2");
                result.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue(scheme: "Basic", parameter: "realm=localhost"));
            }
            Debug.WriteLine("authen 2 - 3");
            
        }
    }

    public class AuthenticationFailResult : IHttpActionResult
    {
        
        public string ReasonPhrase;

        public HttpRequestMessage Request { get; set; }

        public AuthenticationFailResult(string reasonPhrase, HttpRequestMessage request)
        {
            Debug.WriteLine("authen 3");

            ReasonPhrase = reasonPhrase;
            Request = request;
        }


       // public HttpResponseMessage Register()
       // {
       
         //   Debug.WriteLine("==============================");
        //    var response = Request.CreateResponse(HttpStatusCode.Moved);
         //   response.Headers.Location = new Uri("http://www.abcmvc.com");
         //   return response;
        //}

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            Debug.WriteLine("authen 4");
            return Task.FromResult(Execute());
        }

        public HttpResponseMessage Execute()
        {
            Debug.WriteLine("authen 5");
            HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            responseMessage.RequestMessage = Request;
            responseMessage.ReasonPhrase = ReasonPhrase;
            return responseMessage;
        }

  

         public void shi(HttpActionContext actionContext) {
            actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
         }
    }

}