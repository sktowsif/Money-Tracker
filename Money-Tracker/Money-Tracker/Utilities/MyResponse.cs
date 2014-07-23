using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Money_Tracker.Utilities
{
    public class MyResponse
    {
        public int Id { get; set; }

        public string UserMessage { get; set; }

        public string ExceptionMessage { get; set; }

        public MyResponse(int intId)
        {
            this.Id = intId;
        }

        public MyResponse(int intId, string strMessage)
        {
            this.Id = intId;
            this.UserMessage = strMessage;
        }

        public MyResponse(int intId, string strMessage, string strExtendedMessage)
        {
            this.Id = intId;
            this.UserMessage = strMessage;
            this.ExceptionMessage = strExtendedMessage;
        }

    }
}