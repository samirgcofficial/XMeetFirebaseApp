using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FireBaseLoginApp.Admin.Models
{
    public class TasksModel
    {
        public Guid TaskId { get; set; }
        public Guid ClientID { get; set; }
        public string TaskTitle { get; set; }
        public List<ClientTask> clientTasks { get; set; }
    }

    public class ClientTask
    {
        public string TaskName { get; set; }

    }

}
