using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplodocus.Models
{
    interface IDalItf: IDisposable
    {

        List<SchoolSubject> RecupererSubjectsList();
    }
}
