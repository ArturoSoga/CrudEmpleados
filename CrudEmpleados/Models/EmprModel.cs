using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudEmpleados.Models
{
    class EmprModel
    {
       public int empr_id { set; get; }
       public string empr_nombre { set; get; }

      public List<EmprModel> GetEmpr()
        {
            using(LOGISTICAEntities db = new LOGISTICAEntities())
            {
                return (from empr in db.CatEmpresas
                        select new EmprModel()
                        {
                            empr_id = empr.IdEmpresa,
                            empr_nombre = empr.RazonSocial
                        }).ToList();
            }
        }

    }
}
