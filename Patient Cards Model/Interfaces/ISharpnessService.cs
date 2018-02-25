using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Patient_Cards_Model.DTO;

namespace Patient_Cards_Model.Interfaces
{
    public interface ISharpnessService
    {
        IList<GLSharpnessDTO> GetGLSharpnesses(int? cardId = null);
        IList<CLSharpnessDTO> GetCLSharpnesses(int? cardId = null);
    }
}
