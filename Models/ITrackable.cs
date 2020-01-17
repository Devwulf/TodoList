using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Models
{
    public interface ITrackable
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
