using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class FormManager : IFormService
    {
        IFormDal formDal;
        public FormManager(IFormDal formDal)
        {
            this.formDal = formDal;
        }

        public void Delete(Form form)
        {
            formDal.Delete(form);
        }

        public void Add(Form form)
        {
            formDal.Insert(form);
        }

        public List<Form> List()
        {
            return formDal.GetAll();
        }

        public void Edit(Form form)
        {
            formDal.Update(form);
        }
        public Form GetById(int id)
        {
            return formDal.Get(x => x.FormId == id);
        }
    }
}
