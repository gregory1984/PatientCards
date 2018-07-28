using Patient_Cards_Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Cards_Model.Interfaces
{
    public interface IPersonalInterviewService
    {
        PersonalInterviewDTO GetPersonalInterview(int id);
    }
}
