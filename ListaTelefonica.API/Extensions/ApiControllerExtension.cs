using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ListaTelefonica.API.Models;
using ListaTelefonica.Domain.Utils;

namespace ListaTelefonica.API.Extensions
{
    public static class ApiControllerExtension
    {
        private static HttpResponseMessage CreateResponseMessage(ApiController apiController, HttpStatusCode httpStatus, IList<Message> mensagens, Object obj, String objectUrl = null)
        {
            var responseObject = new ResponseObject(mensagens, obj, objectUrl);
            return apiController.Request.CreateResponse(httpStatus, responseObject);
        }

        public static HttpResponseMessage OkResponse(this ApiController apiController, IList<Message> mensagens, Object obj, String objectUrl = null)
        {                       
            return CreateResponseMessage(apiController, HttpStatusCode.OK, mensagens, obj, objectUrl);
        }

        public static HttpResponseMessage CreatedResponse(this ApiController apiController, IList<Message> mensagens, Object obj, String objectUrl = null)
        {
            return CreateResponseMessage(apiController, HttpStatusCode.Created, mensagens, obj, objectUrl);
        }

        public static HttpResponseMessage NotFoundResponse(this ApiController apiController, IList<Message> mensagens = null, Object obj = null, String objectUrl = null)
        {
            if (mensagens == null) mensagens = new List<Message>();
            
            return CreateResponseMessage(apiController, HttpStatusCode.NotFound, mensagens, obj, objectUrl);
        }

        public static HttpResponseMessage BadRequestResponse(this ApiController apiController, IList<Message> mensagens, Object obj, String objectUrl = null)
        {
            return CreateResponseMessage(apiController, HttpStatusCode.BadRequest, mensagens, obj, objectUrl);
        }
    }
}