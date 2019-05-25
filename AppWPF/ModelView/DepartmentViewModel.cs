using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using AppWPF.Model;

namespace AppWPF.ModelView
{
    public class DepartmentViewModel : INotifyPropertyChanged
    {

        //Enlaze a la base de datos
        private SchoolDataContext db = new SchoolDataContext();
        private Boolean _IsReadOnlyName = true;
        private Boolean _IsReadOnlyBudget = true;
        private Boolean _IsReadOnlyAdmin = true;

        private ObservableCollection<Department> _Department;

        public Boolean IsReadOnlyName
        {
            get
            {
                return this._IsReadOnlyName;
            }
            set
            {
                this._IsReadOnlyName = value;
            }
        }

        public Boolean IsReadOnlyBudget
        {
            get
            {
                return this._IsReadOnlyBudget;
            }
            set
            {
                this._IsReadOnlyBudget = value;
            }
        }

        public Boolean IsReadOnlyAdmin
        {
            get
            {
                return this._IsReadOnlyAdmin;
            }
            set
            {
                this._IsReadOnlyAdmin = value;
            }
        }

        public ObservableCollection<Department> Departments
        {
            get {
                if (this._Department == null)
                {
                    this._Department = new ObservableCollection<Department>();
                    foreach(Department elemento in db.Departments.ToList())
                    {
                        this._Department.Add(elemento);
                    }
                }
               
                return this._Department;
               }
            set { this._Department = value; }

        }


        public DepartmentViewModel()
        {
            this.Titulo = "Departmanetos";
        }
        public string Titulo {get; set;}
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
