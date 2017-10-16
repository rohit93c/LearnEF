using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ClearEmpForm();
            PopulateEmpList();
        }
    }

    /// <summary>
    /// To save the employee information
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //Gets employee id using command argument
        Int32 empId = Convert.ToInt32(btnSave.CommandArgument);

        //if empId==0 insert
        if (empId == 0)
        {
            //INSERT
            //Creates object of entities
            LearnEFEntities db = new LearnEFEntities();

            //Employee object
            Employee objEmp = new Employee();

            //Assigns value to each model in object
            objEmp.HREmpId = txtHREmpId.Text;
            objEmp.FirstName = txtFirstName.Text;
            objEmp.LastName = txtLastName.Text;
            objEmp.Address = txtAddress.Text;
            objEmp.City = txtCity.Text;

            //adds all assigned values to employee object using Add() method
            db.Employees.Add(objEmp);

            //calls db context's save method
            db.SaveChanges();
        }
        else
        {
            //UPDATE if exists
            LearnEFEntities db = new LearnEFEntities();

            //LINQ update syntax
            var empQuery = from emp in db.Employees
                           where emp.EmpId == empId
                           select emp;

            //only one record
            Employee objEmp = empQuery.Single();

            //assigns values
            objEmp.HREmpId = txtHREmpId.Text;
            objEmp.FirstName = txtFirstName.Text;
            objEmp.LastName = txtLastName.Text;
            objEmp.Address = txtAddress.Text;
            objEmp.City = txtCity.Text;

            //calls db context's save method
            db.SaveChanges();

        }

        ClearEmpForm();
        PopulateEmpList();
    }


    /// <summary>
    /// To search employee based on name and/or city
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        PopulateEmpList();
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        Int32 empId = Convert.ToInt32(btnSave.CommandArgument);
        if (empId != 0)
        {
            LearnEFEntities db = new LearnEFEntities();

            Employee objEmp = new Employee() { EmpId = empId };
            db.Employees.Attach(objEmp);
            db.Employees.Remove(objEmp);
            db.SaveChanges();

            //reset the form and grid
            ClearEmpForm();
            PopulateEmpList();
        }
    }

    protected void ddlEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int32 empId = Convert.ToInt32(ddlEmployee.SelectedValue);

        if (empId == 0)
        {
            ClearEmpForm();
            return;
        }

        btnSave.CommandArgument = empId.ToString();
        btnSave.Text = "UPDATE";
        btnDelete.CommandArgument = empId.ToString();

        LearnEFEntities db = new LearnEFEntities();

        var empQuery = from emp in db.Employees
                       where emp.EmpId == empId
                       select emp;

        Employee objEmp = empQuery.Single();

        txtHREmpId.Text = objEmp.HREmpId;
        txtFirstName.Text = objEmp.FirstName;
        txtLastName.Text = objEmp.LastName;
        txtAddress.Text = objEmp.Address;
        txtCity.Text = objEmp.City;
    }

    private void PopulateEmpList()
    {
        LearnEFEntities db = new LearnEFEntities();
        //string ab = txtSrchFirstName.Text;
        //string ac = txtSrchCity.Text;

        //gets list of all employees from emp object
        List<Employee> empList = db.SearchEmployee(txtSrchFirstName.Text, txtSrchCity.Text).ToList();

        ddlEmployee.DataSource = empList;
        ddlEmployee.DataValueField = "EmpId";
        ddlEmployee.DataTextField = "FirstName";
        ddlEmployee.DataBind();

        ddlEmployee.Items.Insert(0, new ListItem("--Add New--", "0"));

        //bind grid
        grdEmployees.DataSource = empList;
        grdEmployees.DataBind();
    }

    /// <summary>
    /// To clear the form fields
    /// </summary>
    private void ClearEmpForm()
    {
        txtHREmpId.Text = "";
        txtFirstName.Text = "";
        txtLastName.Text = "";
        txtAddress.Text = "";
        txtCity.Text = "";

        btnSave.CommandArgument = "0";
        btnSave.Text = "SAVE";
    }
}