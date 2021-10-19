using System.Collections.Generic;

namespace MyClassLibrary
{
    public class Messages
    {
        public string userName { get; set; }
        public string dataMessage { get; set; }

        public Messages(string userName, string dataMessage)
        {
            this.userName = userName;
            this.dataMessage = dataMessage;
        }
       
    }
}
