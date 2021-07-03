using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using DL;
using System.Data;

namespace UI
{
    public partial class Category : System.Web.UI.Page
    {
        CategoryBL objBL = new CategoryBL();
        CategoryDL objDL = new CategoryDL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                GetData();
                Reset();
            }

        }
        private void GetData()
        {
            gridCategory.DataSource = objDL.GetAllCategories();
            gridCategory.DataBind();
        }
        private void Reset()
        {
            lblCode.Text = "Auto Code";
            txtname.Text = string.Empty;
            rbstatus.SelectedValue = "0";
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }
        private void FillBL()
        {
            objBL.catcode = lblCode.Text;
            objBL.catname = txtname.Text;
            objBL.catstatus = rbstatus.SelectedValue;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            FillBL();

            if (objDL.IsCategoryExists(objBL))
            {
                ShowMessage("Category Aready Exists!");
            }
               
            else
            {
                objDL.SaveCategory(objBL);
                GetData();
                Reset();
            }

        }
        private void ShowMessage(string Msg)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('" + Msg + "')", true);
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            FillBL();
            //if (objDL.IsCategoryExists(objBL))
            //{
            //  objDL.SaveCategory(objBL);
            //   ShowMessage("Category already exist!");
            //}
            //else {
            objDL.UpdateCategory(objBL);
            GetData();
            Reset();
            //}
            }
            private string GetText(string control, int index)
            {
                return ((Label)gridCategory.Rows[index].FindControl(control)).Text;
            }
            protected void gridCategory_RowEditing(Object sender, GridViewEditEventArgs e)
            {
                int index = e.NewEditIndex;
                lblCode.Text = GetText("lblcode", index);
                txtname.Text = GetText("lblname", index);
                string status = GetText("lblstatus", index);
                rbstatus.SelectedValue = "1";
                if (status=="False")
                {
                    rbstatus.SelectedValue = "0";
                }
                btnSave.Visible = false;
                btnUpdate.Visible = true;

            }

        }
    }


