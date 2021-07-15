using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudEmpleados
{
    class EmplModel
    {
        public int IdEmpleado { set; get; }
        public int? IdEmpresa { set; get; }
        public string Nombre { set; get; }
        public long? Telefono { set; get; }
        public string Direccion { set; get; }
        public string FechaIngreso { set; get; }

        public List<EmplModel> EmplGet()
        {
            using(LOGISTICAEntities db = new LOGISTICAEntities())
            {
             return (from Empl in db.CatEmpleados
                 select new EmplModel()
                 {
                     IdEmpleado = Empl.IdEmpleado,
                     IdEmpresa =  Empl.IdEmpresa,
                     Nombre =     Empl.Nombre,
                     Telefono =   Empl.Telefono,
                     Direccion =  Empl.Direccion,
                     FechaIngreso = FechaIngreso

                 }).ToList();
            }
        }

        public void  EmplInsert(EmplModel NewEmpl)
        {
            using (LOGISTICAEntities db = new LOGISTICAEntities())
            {
                db.CatEmpleados.Add(new CatEmpleado() {IdEmpresa = NewEmpl.IdEmpresa, Nombre = NewEmpl.Nombre,Telefono = NewEmpl.Telefono ,Direccion = NewEmpl.Direccion ,FechaIngreso= new DateTime()});
                db.SaveChanges();
            }
        }

        public void EmplUpdate(EmplModel UpdateEmpl)
        {
            using (LOGISTICAEntities db = new LOGISTICAEntities()) {
                var ToUpdateObject = (from obj in db.CatEmpleados
                                      where obj.IdEmpleado == UpdateEmpl.IdEmpleado
                                      select obj).FirstOrDefault();

                ToUpdateObject.IdEmpresa = UpdateEmpl.IdEmpresa;
                ToUpdateObject.Nombre = UpdateEmpl.Nombre;
                ToUpdateObject.Direccion = UpdateEmpl.Direccion;
                ToUpdateObject.Telefono = UpdateEmpl.Telefono;
            }
        }
    }
}
