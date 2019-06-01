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
using System.Data.Entity;

namespace AppWPF.ModelView
{
    enum ACCION
    {
        NINGUNO,
        NUEVO,
        GUARDAR,
        ACTUALIZAR

    };
    public class DepartmentViewModel : INotifyPropertyChanged,ICommand 
    {

        //Enlaze a la base de datos
        private SchoolDataContext db = new SchoolDataContext();
        #region Campos
        private ACCION accion = ACCION.NINGUNO;
        private Boolean _IsReadOnlyName = true;
        private Boolean _IsReadOnlyBudget = true;
        private Boolean _IsReadOnlyAdmin = true;
        private DepartmentViewModel _Instancia;
        private bool _IsEnabledAdd = true;
        private bool _IsEnabledDelete = true;
        private bool _IsEnableUpdate = true;
        private bool _IsEnableSave = false;
        private bool _IsEnableCancel = false;
        private string _Name;
        private string _Budget;
        private string _Admin;
        private Department _SelectDepartment;
        #endregion
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

        public Department SelectDepartment {
            get { return this._SelectDepartment; }
            set
            {
                if (value != null) { 
                    this._SelectDepartment = value;
                    this.Name = value.Name;
                    this.Budget = value.Budget.ToString();
                    this.Admin = value.Administrator.ToString();
                    ChangeNotify("SelectDepartment");
                }
            }
        }


        public Boolean IsEnabledAdd
        {
            get
            {
                return this._IsEnabledAdd;
            }
            set
            {
                this._IsEnabledAdd = value;
                ChangeNotify("IsEnabledAdd");
            }
        }
        public Boolean IsEnabledDelete
        {
            get
            {
                return this._IsEnabledDelete;
            }
            set
            {
                this._IsEnabledDelete = value;
                ChangeNotify("IsEnabledDelete");
            }
        }

        public Boolean IsEnableUpdate
        {
            get
            {
                return this._IsEnableUpdate;
            }
            set
            {
                this._IsEnableUpdate = value;
                ChangeNotify("IsEnableUpdate");
            }
        }

        public Boolean IsEnableSave
        {
            get
            {
                return this._IsEnableSave;
            }
            set
            {
                this._IsEnableSave = value;
                ChangeNotify("IsEnableSave");
            }
        }

        public Boolean IsEnableCancel
        {
            get
            {
                return this._IsEnableCancel;
            }
            set
            {
                this._IsEnableCancel = value;
                ChangeNotify("IsEnableCancel");
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
                this.accion = ACCION.NUEVO;
                this.IsEnabledAdd = false;
                this.IsEnabledDelete = false;
                this.IsEnableUpdate = false;
                this.IsEnableSave = true;
                this.IsEnableCancel = true;
            }
            if (parameter.Equals("Save"))
            {
                switch(this.accion)
                {
                    case ACCION.NUEVO:
                        Department nuevo = new Department();
                        nuevo.Name = this.Name;
                        nuevo.Budget = Convert.ToDecimal(this.Budget);
                        nuevo.Administrator = Convert.ToInt16(this.Admin);
                        nuevo.StartDate = DateTime.Now;
                        db.Departments.Add(nuevo);
                        db.SaveChanges();
                        this.Departments.Add(nuevo);
                        MessageBox.Show("Registro Almacenado");
                        break;
                    case ACCION.ACTUALIZAR:
                        try {
                            int posicion = this.Departments.IndexOf(this.SelectDepartment);
                            var updatDepartment = this.db.Departments.Find(this.SelectDepartment.DepartmentID);
                            updatDepartment.Name = this.Name;
                            updatDepartment.Budget = Convert.ToDecimal(this.Budget);
                            updatDepartment.Administrator = Convert.ToInt16(this.Admin);
                            this.db.Entry(updatDepartment).State = EntityState.Modified;
                            this.db.SaveChanges();
                            this.Departments.RemoveAt(posicion);
                            this.Departments.Insert(posicion, updatDepartment);
                            MessageBox.Show("Registro Actualizado");
                        }
                        catch(Exception e)
                        {
                            MessageBox.Show(e.Message);
                        }
                        break;
                }
                
            }
            else if (parameter.Equals("Update"))
            {
                this.accion = ACCION.ACTUALIZAR;
                this.IsReadOnlyName = false;
                this.IsReadOnlyBudget = false;
                this.IsReadOnlyAdmin = false;

                this.IsEnabledAdd = false;
                this.IsEnabledDelete = false;
                this.IsEnableUpdate = false;
                this.IsEnableSave = true;
                this.IsEnableCancel = true;
            }
            else if (parameter.Equals("Delete"))
            {
                if (this.SelectDepartment != null)
                {
                    var respuesta = MessageBox.Show("Esta seguro de eliminar el registro", "Eliminar", MessageBoxButton.YesNo);
                    if(respuesta == MessageBoxResult.Yes)
                    {
                        try
                        {
                            db.Departments.Remove(this.SelectDepartment);
                            db.SaveChanges();
                            this.Departments.Remove(this.SelectDepartment);
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message);
                        }
                       
                        MessageBox.Show("Registro eliminado Correctamente");
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar un registro", "Eliminar", MessageBoxButton.OK,MessageBoxImage.Error);
                    }
                }
             

            }
        }
    }
}
