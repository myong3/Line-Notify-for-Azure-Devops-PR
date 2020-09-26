using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LineNotifyProject.Models
{
    public class MessageModel
    {
        public string subscriptionId { get; set; }
        public int notificationId { get; set; }
        public string id { get; set; }
        public string eventType { get; set; }
        public string publisherId { get; set; }
        public Message message { get; set; }
        public Message detailedMessage { get; set; }
        
        public Resource resource { get; set; }
        //public string resourceVersion { get; set; }
        //public string resourceContainers { get; set; }
        //public string createdDate { get; set; }
    }

    public class Message
    {
        public string text { get; set; }
        public string html { get; set; }
        public string markdown { get; set; }
    }

    public class Resource
    {
        public CreatedBy createdBy { get; set; }
        public string creationDate { get; set; }
        public string url { get; set; }
        public Links _links { get; set; }

    }

    public class CreatedBy
    {
        public string displayName { get; set; }
    }

    public class Links
    {
        public Web web { get; set; }
    }

    public class Web
    {
        public string href { get; set; }
    }
}
