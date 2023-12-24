using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeAdministrationTool.Models.ViewModels
{
    public class ActionResponse<T>
    {
        public bool ActionSuccess { get; set; }
        public T ActionData { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }
}
