using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using AppWPF.Model;
using System.Windows.Input;
using System.Windows;

namespace AppWPF.ModelView
{
    public class DepartmentViewModel : INotifyPropertyChanged,ICommand 
    {

        //Enlaze a la base de datos
        private SchoolDataContext db = new SchoolDataContext();
        private Boolean _IsReadOnlyName = true;
        private Boolean _IsReadOnlyBudget = true;
        private Boolean _IsReadOnlyAdmin = true;
        private DepartmentViewModel _Instancia;
        private string _Name;
        private string _Budget;
        private string _Admin;

        public DepartmentViewModel()
        {
            this.Titulo = "Lista de Departamentos";
            this.Instancia = this;
        }

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
                ChangeNotify("IsReadOnlyName");
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
                ChangeNotify("IsReadOnlyBudget");
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
                ChangeNotify("IsReadOnlyAdmin");
            }
        }

        public DepartmentViewModel Instancia
        {
            get
            {
                return this._Instancia;
            }
            set
            {
                this._Instancia = value;
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

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                this._Name = value;
                ChangeNotify("Name");
            }
        }

        public string Budget
        {
            get
            {
                return _Budget;
            }
            set
            {
                this._Budget = value;
                ChangeNotify("Budget");
            }
        }

        public string Admin
        {
            get
            {
                return _Admin;
            }
            set
            {
                this._Admin = value;
                ChangeNotify("Admin");
            }
        }



        public string Titulo {get; set;}
        public event PropertyChangedEventHandler PropertyChanged;
        public void ChangeNotify(string propertie)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertie));
            }
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.Equals("Add"))
            {
                MessageBox.Show("Agregar Departamento");
                this.IsReadOnlyName = false;
                this.IsReadOnlyBudget = false;
                this.IsReadOnlyAdmin = false;
            }
            if (parameter.Equals("Save"))
            {
                Department nuevo = new Department();
                nuevo.Name = this.Name;
                nuevo.Budget = Convert.ToDecimal(this.Budget);
                nuevo.Administrator = Convert.ToInt16(this.Admin);
                nuevo.StartDate = DateTime.Now;
                db.Departments.Add(nuevo);
                db.SaveChanges();
                this.Departments.Add(nuevo);
                MessageBox.Show("Registro Almacenado");
            }
        }
    }
}
