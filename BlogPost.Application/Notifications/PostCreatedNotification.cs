using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Application.Notifications
{
    public class PostCreatedNotification : INotification
    {
        public int Id { get; set; }
    }


    public class PostCreatedNotificationHandler1 : INotificationHandler<PostCreatedNotification>
    {
        public async Task Handle(PostCreatedNotification notification, CancellationToken cancellationToken)
        {
            Debug.Print($"1 - Notification handler = {notification.Id.ToString()}");
        }
    }
}
