using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using BL;

namespace DL
{
    public class CategoryDL
    {
        DBManager objDb = new DBManager();
        public DataTable GetAllCategories()
        {
            return objDb.ExecuteDatatable("select *  from category");
        }
        public void SaveCategory(CategoryBL objBL)
        {
            objDb.ExecuteNoneQuery("insert into category (catname, catstatus) values ('" + objBL.catname + "', '" + objBL.catstatus + "')");
        }
        public void UpdateCategory(CategoryBL objBL)
        {
            objDb.ExecuteNoneQuery("update category set catname='" + objBL.catname + "', catstatus='" + objBL.catstatus + "' where catcode=" + objBL.catcode + "");
        }
        public bool IsCategoryExists(CategoryBL objBL)
        {
            return objDb.ExecuteScalar("if exists (select catname from category where catname='" + objBL.catname + "') select 'True'");
        }

    }
}