using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using DL;
using System.Data;
using System.IO;

namespace UI
{
    public partial class Product : System.Web.UI.Page
    {
        ProductBL objBL = new ProductBL();
        ProductDL objDL = new ProductDL();
        CategoryDL objCatDL = new CategoryDL();

        protected void Page_Load(object sender, EventArgs e)
        {


            this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {

                GetData();
                Reset();
                PopulateCategory();
            }
        }
        private void GetData()
        {
            gridProduct.DataSource = objDL.GetAllProducts();
            gridProduct.DataBind();
        }
        private void Reset()
        {
            lblcode.Text = "Auto Code";
            txtname.Text = string.Empty;
            txtprice.Text = string.Empty;
            rbstatus.SelectedValue = "1";
            ddlCategory.SelectedIndex = 0;
            btnSave.Visible = true;
            btnUpdate.Visible = false;


        }
        private void FillBL()
        {
            objBL.procode = lblcode.Text;
            objBL.proname = txtname.Text;
            objBL.procat = ddlCategory.SelectedValue;
            objBL.proprice = txtprice.Text;
            objBL.prostatus = rbstatus.SelectedValue;
            objBL.proimage = fuimage.FileName;
        }
        private void PopulateCategory()
        {
            ddlCategory.DataSource = objCatDL.GetAllCategories();
            ddlCategory.DataTextField = "catname";
            ddlCategory.DataValueField = "catcode";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem ("--Select Category--", "0"));
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Reset();

        }
        private void ShowMessage(string Msg)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('" + Msg + "')", true);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ddlCategory.SelectedIndex == 0)
            {
                ShowMessage("Select a Category!");
            }
            else
            {

                UploadFile("ProductImages", fuimage);
                FillBL();
                objDL.SaveProduct(objBL);
                GetData();
                Reset();
            }
        }
        private void UploadFile(string FolderName, FileUpload fu)
        {
            if (fu.HasFile)
            {
                string FolderPath = "~\\" + FolderName;
                DirectoryInfo FolderDir = new DirectoryInfo (Server.MapPath(FolderPath));
                if (!FolderDir.Exists)
                {
                    FolderDir.Create();
                }
                string FilePath =Path.Combine(Server.MapPath(FolderPath), fu.FileName);
                if (!File.Exists(FilePath))
                {
                    fu.SaveAs(FilePath);
                }
            }

        }
        private void DeleteFile()
        {
            string filepath = Server.MapPath(imgpath.Text);
            if (!File.Exists(filepath))
            {
                File.Delete(filepath);
            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ddlCategory.SelectedIndex == 0)
            {
                ShowMessage("Select a Category!");
            }
            else
            {

                UploadFile("ProductImages", fuimage);
                FillBL();
                if (fuimage.HasFile)
                {
                    DeleteFile();
                    objDL.UpdateProduct(objBL, true);
                }
                else
                {
                    objDL.UpdateProduct(objBL, false);
                }

                GetData();
                Reset();
            }
        }

        private string GetText(string control, int index)
        {
            return ((Label)gridProduct.Rows[index].FindControl(control)).Text;
        }

        protected void gridProduct_RowEditing(Object sender, GridViewEditEventArgs e)
        {
            int index = e.NewEditIndex;
            lblcode.Text = GetText("lblcode", index);
            txtname.Text = GetText("lblname", index);
            string status = GetText("lblstatus", index);
            txtprice.Text = GetText("lblprice", index);
            string catname = GetText("lblcat", index);
            imgpath.Text = ((Image)gridProduct.Rows[index].FindControl("img")).ImageUrl;
            rbstatus.SelectedValue = "1";
            if (status == "False")
            {
                rbstatus.SelectedValue = "0";
            }
            ddlCategory.SelectedItem.Text = catname;
            btnSave.Visible = false;
            btnUpdate.Visible = true;
        }
    }
}

